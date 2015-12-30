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
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	using System;

	public class NestedClassEmitter : AbstractTypeEmitter
	{
		#region Constructors/Destructors

		public NestedClassEmitter(AbstractTypeEmitter maintype, String name, Type baseType, Type[] interfaces)
			: this(
				maintype,
				CreateTypeBuilder(maintype, name, TypeAttributes.Sealed | TypeAttributes.NestedPublic | TypeAttributes.Class,
					baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter maintype, String name, TypeAttributes attributes, Type baseType,
			Type[] interfaces)
			: this(maintype, CreateTypeBuilder(maintype, name, attributes, baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter maintype, TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
			maintype.Nested.Add(this);
		}

		#endregion

		#region Methods/Operators

		private static TypeBuilder CreateTypeBuilder(AbstractTypeEmitter maintype, string name, TypeAttributes attributes,
			Type baseType, Type[] interfaces)
		{
			return maintype.TypeBuilder.DefineNestedType(
				name,
				attributes,
				baseType, interfaces);
		}

		#endregion
	}
}