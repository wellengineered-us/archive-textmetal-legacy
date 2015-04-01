/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Framework.Core.ObjectTaxonomy;

namespace TextMetal.Framework.XmlDialect
{
	/// <summary>
	/// Provides a concrete implementation for XML object collections.
	/// </summary>
	/// <typeparam name="TXmlObject"> </typeparam>
	public class XmlObjectCollection<TXmlObject> : HierarchicalObjectCollection<TXmlObject>, IXmlObjectCollection<TXmlObject>
		where TXmlObject : IXmlObject
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the XmlObjectCollection class.
		/// </summary>
		/// <param name="site"> The containing site XML object. </param>
		public XmlObjectCollection(IXmlObject site)
			: base(site)
		{
		}

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the site XML object or null if this is unattached.
		/// </summary>
		public new IXmlObject Site
		{
			get
			{
				return (IXmlObject)base.Site;
			}
		}

		#endregion
	}
}