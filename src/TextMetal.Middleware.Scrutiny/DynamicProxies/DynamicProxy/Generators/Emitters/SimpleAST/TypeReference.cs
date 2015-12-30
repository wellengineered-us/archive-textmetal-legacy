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

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	using System;

	public abstract class TypeReference : Reference
	{
		#region Constructors/Destructors

		protected TypeReference(Type argumentType)
			: this(null, argumentType)
		{
		}

		protected TypeReference(Reference owner, Type type)
			: base(owner)
		{
			this.type = type;
		}

		#endregion

		#region Fields/Constants

		private readonly Type type;

		#endregion

		#region Properties/Indexers/Events

		public Type Type
		{
			get
			{
				return this.type;
			}
		}

		#endregion
	}
}