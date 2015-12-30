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

using System.Reflection;

using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	using System;

	public class InterfaceMembersOnClassCollector : MembersCollector
	{
		#region Constructors/Destructors

		public InterfaceMembersOnClassCollector(Type type, bool onlyProxyVirtual, InterfaceMapping map)
			: base(type)
		{
			this.onlyProxyVirtual = onlyProxyVirtual;
			this.map = map;
		}

		#endregion

		#region Fields/Constants

		private readonly InterfaceMapping map;
		private readonly bool onlyProxyVirtual;

		#endregion

		#region Methods/Operators

		private MethodInfo GetMethodOnTarget(MethodInfo method)
		{
			var index = Array.IndexOf(this.map.InterfaceMethods, method);
			if (index == -1)
				return null;

			return this.map.TargetMethods[index];
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (method.IsAccessible() == false)
				return null;

			if (this.onlyProxyVirtual && this.IsVirtuallyImplementedInterfaceMethod(method))
				return null;

			var methodOnTarget = this.GetMethodOnTarget(method);

			var proxyable = this.AcceptMethod(method, this.onlyProxyVirtual, hook);
			return new MetaMethod(method, methodOnTarget, isStandalone, proxyable, methodOnTarget.IsPrivate == false);
		}

		private bool IsVirtuallyImplementedInterfaceMethod(MethodInfo method)
		{
			var info = this.GetMethodOnTarget(method);
			return info != null && info.IsFinal == false;
		}

		#endregion
	}
}