// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	using System;

	public class ClassProxyWithTargetTargetContributor : CompositeTypeContributor
	{
		#region Constructors/Destructors

		public ClassProxyWithTargetTargetContributor(Type targetType, IList<MethodInfo> methodsToSkip,
			INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
			this.methodsToSkip = methodsToSkip;
		}

		#endregion

		#region Fields/Constants

		private readonly IList<MethodInfo> methodsToSkip;
		private readonly Type targetType;

		#endregion

		#region Methods/Operators

		private Type BuildInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			if (!method.HasTarget)
			{
				return new InheritanceInvocationTypeGenerator(this.targetType,
					method,
					null, null)
					.Generate(@class, options, this.namingScope)
					.BuildType();
			}
			return new CompositionInvocationTypeGenerator(method.Method.DeclaringType,
				method,
				method.Method,
				false,
				null)
				.Generate(@class, options, this.namingScope)
				.BuildType();
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			Debug.Assert(hook != null, "hook != null");

			var targetItem = new WrappedClassMembersCollector(this.targetType) { Logger = this.Logger };
			targetItem.CollectMembersToProxy(hook);
			yield return targetItem;

			foreach (var @interface in this.interfaces)
			{
				var item = new InterfaceMembersOnClassCollector(@interface,
					true,
#if NETCORE
					this.targetType.GetTypeInfo().GetRuntimeInterfaceMap(@interface)) { Logger = this.Logger };
#else
				                                                targetType.GetInterfaceMap(@interface)) { Logger = Logger };
#endif
				item.CollectMembersToProxy(hook);
				yield return item;
			}
		}

		private IInvocationCreationContributor GetContributor(Type @delegate, MetaMethod method)
		{
			if (@delegate.GetTypeInfo().IsGenericType == false)
				return new InvocationWithDelegateContributor(@delegate, this.targetType, method, this.namingScope);
			return new InvocationWithGenericDelegateContributor(@delegate,
				method,
				new FieldReference(InvocationMethods.Target));
		}

		private Type GetDelegateType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			var scope = @class.ModuleScope;
			var key = new CacheKey(
#if NETCORE
				typeof(Delegate).GetTypeInfo(),
#else
				typeof(Delegate),
#endif
				this.targetType,
				new[] { method.MethodOnTarget.ReturnType }
					.Concat(ArgumentsUtil.GetTypes(method.MethodOnTarget.GetParameters())).
					ToArray(),
				null);

			var type = scope.GetFromCache(key);
			if (type != null)
				return type;

			type = new DelegateTypeGenerator(method, this.targetType)
				.Generate(@class, options, this.namingScope)
				.BuildType();

			scope.RegisterInCache(key, type);

			return type;
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			var scope = @class.ModuleScope;
			var invocationInterfaces = new[] { typeof(IInvocation) };

			var key = new CacheKey(method.Method, CompositionInvocationTypeGenerator.BaseType, invocationInterfaces, null);

			// no locking required as we're already within a lock

			var invocation = scope.GetFromCache(key);
			if (invocation != null)
				return invocation;
			invocation = this.BuildInvocationType(method, @class, options);

			scope.RegisterInCache(key, invocation);

			return invocation;
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class,
			ProxyGenerationOptions options,
			OverrideMethodDelegate overrideMethod)
		{
			if (this.methodsToSkip.Contains(method.Method))
				return null;

			if (!method.Proxyable)
			{
				return new MinimialisticMethodGenerator(method,
					overrideMethod);
			}

			if (this.IsDirectlyAccessible(method) == false)
				return this.IndirectlyCalledMethodGenerator(method, @class, options, overrideMethod);

			var invocation = this.GetInvocationType(method, @class, options);

			return new MethodWithInvocationGenerator(method,
				@class.GetField("__interceptors"),
				invocation,
				(c, m) => c.GetField("__target").ToExpression(),
				overrideMethod,
				null);
		}

		private MethodGenerator IndirectlyCalledMethodGenerator(MetaMethod method, ClassEmitter proxy,
			ProxyGenerationOptions options,
			OverrideMethodDelegate overrideMethod)
		{
			var @delegate = this.GetDelegateType(method, proxy, options);
			var contributor = this.GetContributor(@delegate, method);
			var invocation = new CompositionInvocationTypeGenerator(this.targetType, method, null, false, contributor)
				.Generate(proxy, options, this.namingScope)
				.BuildType();
			return new MethodWithInvocationGenerator(method,
				proxy.GetField("__interceptors"),
				invocation,
				(c, m) => c.GetField("__target").ToExpression(),
				overrideMethod,
				contributor);
		}

		private bool IsDirectlyAccessible(MetaMethod method)
		{
			return method.MethodOnTarget.IsPublic;
		}

		#endregion
	}
}