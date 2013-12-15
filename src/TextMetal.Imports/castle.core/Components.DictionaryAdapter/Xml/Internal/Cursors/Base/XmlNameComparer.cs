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
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.f
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;

#if !SILVERLIGHT && !MONO // Until support for other platforms is verified

namespace Castle.Components.DictionaryAdapter.Xml
{
	using System;

	public class XmlNameComparer : IEqualityComparer<XmlName>
	{
		#region Constructors/Destructors

		private XmlNameComparer(StringComparer comparer)
		{
			this.comparer = comparer;
		}

		#endregion

		#region Fields/Constants

		public static readonly XmlNameComparer
			Default = new XmlNameComparer(StringComparer.Ordinal),
			IgnoreCase = new XmlNameComparer(StringComparer.OrdinalIgnoreCase);

		private readonly StringComparer comparer;

		#endregion

		#region Methods/Operators

		public bool Equals(XmlName x, XmlName y)
		{
			return this.comparer.Equals(x.LocalName, y.LocalName)
					&& this.comparer.Equals(x.NamespaceUri, y.NamespaceUri);
		}

		public int GetHashCode(XmlName name)
		{
			var code = (name.LocalName != null)
				? this.comparer.GetHashCode(name.LocalName)
				: 0;

			if (name.NamespaceUri != null)
			{
				code = (code << 7 | code >> 25)
						^ this.comparer.GetHashCode(name.NamespaceUri);
			}

			return code;
		}

		#endregion
	}
}

#endif