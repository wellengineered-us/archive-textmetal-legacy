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

using System.Collections.Generic;
using System.Diagnostics;

namespace Castle.DynamicProxy.Generators
{
	public class NamingScope : INamingScope
	{
		#region Constructors/Destructors

		public NamingScope()
		{
		}

		private NamingScope(INamingScope parent)
		{
			this.parentScope = parent;
		}

		#endregion

		#region Fields/Constants

		private readonly IDictionary<string, int> names = new Dictionary<string, int>();
		private readonly INamingScope parentScope;

		#endregion

		#region Properties/Indexers/Events

		public INamingScope ParentScope
		{
			get
			{
				return this.parentScope;
			}
		}

		#endregion

		#region Methods/Operators

		public string GetUniqueName(string suggestedName)
		{
			Debug.Assert(string.IsNullOrEmpty(suggestedName) == false,
				"string.IsNullOrEmpty(suggestedName) == false");

			int counter;
			if (!this.names.TryGetValue(suggestedName, out counter))
			{
				this.names.Add(suggestedName, 0);
				return suggestedName;
			}

			counter++;
			this.names[suggestedName] = counter;
			return suggestedName + "_" + counter.ToString();
		}

		public INamingScope SafeSubScope()
		{
			return new NamingScope(this);
		}

		#endregion
	}
}