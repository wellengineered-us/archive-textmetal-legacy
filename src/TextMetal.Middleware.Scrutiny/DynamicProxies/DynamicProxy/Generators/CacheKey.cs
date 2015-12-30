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

namespace Castle.DynamicProxy.Generators
{
	using System;

#if FEATURE_SERIALIZATION
	[Serializable]
#endif

	public class CacheKey
	{
		private readonly MemberInfo target;
		private readonly Type[] interfaces;
		private readonly ProxyGenerationOptions options;
		private readonly Type type;

		/// <summary>
		/// Initializes a new instance of the <see cref="CacheKey" /> class.
		/// </summary>
		/// <param name="target"> Target element. This is either target type or target method for invocation types. </param>
		/// <param name="type"> The type of the proxy. This is base type for invocation types. </param>
		/// <param name="interfaces"> The interfaces. </param>
		/// <param name="options"> The options. </param>
		public CacheKey(MemberInfo target, Type type, Type[] interfaces, ProxyGenerationOptions options)
		{
			this.target = target;
			this.type = type;
			this.interfaces = interfaces ?? Type.EmptyTypes;
			this.options = options;
		}

#if NETCORE // Going forward, TypeInfo and not Type inherits from MemberInfo

		/// <summary>
		/// Initializes a new instance of the <see cref="CacheKey" /> class.
		/// </summary>
		/// <param name="target"> Type of the target. </param>
		/// <param name="interfaces"> The interfaces. </param>
		/// <param name="options"> The options. </param>
		public CacheKey(Type target, Type[] interfaces, ProxyGenerationOptions options)
			: this(target.GetTypeInfo(), null, interfaces, options)
		{
		}
#else
	/// <summary>
	///   Initializes a new instance of the <see cref = "CacheKey" /> class.
	/// </summary>
	/// <param name = "target">Type of the target.</param>
	/// <param name = "interfaces">The interfaces.</param>
	/// <param name = "options">The options.</param>
		public CacheKey(Type target, Type[] interfaces, ProxyGenerationOptions options)
			: this(target, null, interfaces, options)
		{
		}
#endif

		public override int GetHashCode()
		{
			var result = this.target.GetHashCode();
			foreach (var inter in this.interfaces)
				result += 29 + inter.GetHashCode();
			if (this.options != null)
				result = 29 * result + this.options.GetHashCode();
			if (this.type != null)
				result = 29 * result + this.type.GetHashCode();
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
				return true;

			var cacheKey = obj as CacheKey;
			if (cacheKey == null)
				return false;

			if (!Equals(this.type, cacheKey.type))
				return false;
			if (!Equals(this.target, cacheKey.target))
				return false;
			if (this.interfaces.Length != cacheKey.interfaces.Length)
				return false;
			for (var i = 0; i < this.interfaces.Length; i++)
			{
				if (!Equals(this.interfaces[i], cacheKey.interfaces[i]))
					return false;
			}
			if (!Equals(this.options, cacheKey.options))
				return false;
			return true;
		}
	}
}