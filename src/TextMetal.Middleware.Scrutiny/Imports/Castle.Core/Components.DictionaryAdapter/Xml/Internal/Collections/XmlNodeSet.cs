// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright 2004-2012 Castle Project - http://www.castleproject.org/
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

#if DOTNET40
namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XmlNodeSet<T> : SetProjection<T>, IXmlNodeSource
	{
		public XmlNodeSet
		(
			IXmlNode               parentNode,
			IDictionaryAdapter     parentObject,
			IXmlCollectionAccessor accessor
		)
		: base
		(
			new XmlCollectionAdapter<T>
			(
				parentNode,
				parentObject,
				accessor
			)
		)
		{ }

		public IXmlNode Node
		{
		    get { return ((IXmlNodeSource)Adapter).Node; }
		}
	}
}
#endif
