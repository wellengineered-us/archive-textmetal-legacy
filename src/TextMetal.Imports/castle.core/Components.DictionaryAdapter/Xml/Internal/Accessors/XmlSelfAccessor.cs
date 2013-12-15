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
	using System;

	public class XmlSelfAccessor : XmlAccessor
	{
		#region Constructors/Destructors

		public XmlSelfAccessor(Type clrType, IXmlContext context)
			: base(clrType, context)
		{
		}

		#endregion

		#region Fields/Constants

		internal static readonly XmlAccessorFactory<XmlSelfAccessor>
			Factory = (name, type, context) => new XmlSelfAccessor(type, context);

		#endregion

		#region Methods/Operators

		public override void ConfigureNillable(bool nillable)
		{
			// This behavior cannot support nillable
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode parentNode, bool mutable)
		{
			return parentNode.SelectSelf(this.ClrType);
		}

		#endregion
	}
}

#endif