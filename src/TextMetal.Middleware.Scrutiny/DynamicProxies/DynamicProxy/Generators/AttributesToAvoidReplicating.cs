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

namespace Castle.DynamicProxy.Generators
{
	using System;

#if !NETCORE
	using System.Security.Permissions;
#endif

	public static class AttributesToAvoidReplicating
	{
		#region Constructors/Destructors

		static AttributesToAvoidReplicating()
		{
#if !NETCORE
			Add<ComImportAttribute>();
#endif
#if !SILVERLIGHT && !NETCORE
			Add<SecurityPermissionAttribute>();
#endif
#if DOTNET40
			Add<TypeIdentifierAttribute>();
#endif
		}

		#endregion

		#region Fields/Constants

		private static readonly IList<Type> attributes = new List<Type>();

		#endregion

		#region Methods/Operators

		public static void Add(Type attribute)
		{
			if (attributes.Contains(attribute) == false)
				attributes.Add(attribute);
		}

		public static void Add<T>()
		{
			Add(typeof(T));
		}

		public static bool Contains(Type type)
		{
			return attributes.Contains(type);
		}

		#endregion
	}
}