﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
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

	public class InterfaceMembersCollector : MembersCollector
	{
		#region Constructors/Destructors

		public InterfaceMembersCollector(Type @interface)
			: base(@interface)
		{
		}

		#endregion

		#region Methods/Operators

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (method.IsAccessible() == false)
				return null;

			var proxyable = this.AcceptMethod(method, false, hook);
			return new MetaMethod(method, method, isStandalone, proxyable, false);
		}

		#endregion
	}
}