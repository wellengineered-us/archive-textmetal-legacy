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
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	using System;

	public class ClassEmitter : AbstractTypeEmitter
	{
		#region Constructors/Destructors

		public ClassEmitter(ModuleScope modulescope, String name, Type baseType, IEnumerable<Type> interfaces)
			: this(modulescope, name, baseType, interfaces, DefaultAttributes, ShouldForceUnsigned())
		{
		}

		public ClassEmitter(ModuleScope modulescope, String name, Type baseType, IEnumerable<Type> interfaces,
			TypeAttributes flags)
			: this(modulescope, name, baseType, interfaces, flags, ShouldForceUnsigned())
		{
		}

		public ClassEmitter(ModuleScope modulescope, String name, Type baseType, IEnumerable<Type> interfaces,
			TypeAttributes flags,
			bool forceUnsigned)
			: this(CreateTypeBuilder(modulescope, name, baseType, interfaces, flags, forceUnsigned))
		{
			interfaces = this.InitializeGenericArgumentsFromBases(ref baseType, interfaces);

			if (interfaces != null)
			{
				foreach (var inter in interfaces)
					this.TypeBuilder.AddInterfaceImplementation(inter);
			}

			this.TypeBuilder.SetParent(baseType);
			this.moduleScope = modulescope;
		}

		public ClassEmitter(TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
		}

		#endregion

		#region Fields/Constants

		private const TypeAttributes DefaultAttributes =
			TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Serializable;

		private readonly ModuleScope moduleScope;

		#endregion

		#region Properties/Indexers/Events

		public ModuleScope ModuleScope
		{
			get
			{
				return this.moduleScope;
			}
		}

		#endregion

		#region Methods/Operators

		private static TypeBuilder CreateTypeBuilder(ModuleScope modulescope, string name, Type baseType,
			IEnumerable<Type> interfaces,
			TypeAttributes flags, bool forceUnsigned)
		{
			var isAssemblySigned = !forceUnsigned && !StrongNameUtil.IsAnyTypeFromUnsignedAssembly(baseType, interfaces);
			return modulescope.DefineType(isAssemblySigned, name, flags);
		}

		private static bool ShouldForceUnsigned()
		{
			return StrongNameUtil.CanStrongNameAssembly == false;
		}

		protected virtual IEnumerable<Type> InitializeGenericArgumentsFromBases(ref Type baseType,
			IEnumerable<Type> interfaces)
		{
			if (baseType != null && baseType.GetTypeInfo().IsGenericTypeDefinition)
				throw new NotSupportedException("ClassEmitter does not support open generic base types. Type: " + baseType.FullName);

			if (interfaces == null)
				return interfaces;

			foreach (var inter in interfaces)
			{
				if (inter.GetTypeInfo().IsGenericTypeDefinition)
					throw new NotSupportedException("ClassEmitter does not support open generic interfaces. Type: " + inter.FullName);
			}
			return interfaces;
		}

		#endregion
	}
}