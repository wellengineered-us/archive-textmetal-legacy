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


#if !SILVERLIGHT && !MONO // Until support for other platforms is verified

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlDynamicSerializer : XmlTypeSerializer
	{
		#region Constructors/Destructors

		protected XmlDynamicSerializer()
		{
		}

		#endregion

		#region Fields/Constants

		public static readonly XmlDynamicSerializer
			Instance = new XmlDynamicSerializer();

		#endregion

		#region Properties/Indexers/Events

		public override XmlTypeKind Kind
		{
			get
			{
				return XmlTypeKind.Simple;
			}
		}

		#endregion

		#region Methods/Operators

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return node.ClrType == typeof(object)
				? new object()
				: For(node.ClrType).GetValue(node, parent, accessor);
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			if (node.ClrType != typeof(object))
				For(node.ClrType).SetValue(node, parent, accessor, oldValue, ref value);
			else
				node.Clear();
		}

		#endregion
	}
}

#endif