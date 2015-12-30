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

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Castle.Core
{
	using System;

#if FEATURE_SERIALIZATION
	[Serializable]
#endif

	public class ReferenceEqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
	{
		#region Constructors/Destructors

		private ReferenceEqualityComparer()
		{
		}

		#endregion

		#region Fields/Constants

		private static readonly ReferenceEqualityComparer<T> instance = new ReferenceEqualityComparer<T>();

		#endregion

		#region Properties/Indexers/Events

		public static ReferenceEqualityComparer<T> Instance
		{
			get
			{
				return instance;
			}
		}

		#endregion

		#region Methods/Operators

		bool IEqualityComparer.Equals(object x, object y)
		{
			return ReferenceEquals(x, y);
		}

		bool IEqualityComparer<T>.Equals(T x, T y)
		{
			return ReferenceEquals(x, y);
		}

		public int GetHashCode(object obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}

		#endregion
	}
}