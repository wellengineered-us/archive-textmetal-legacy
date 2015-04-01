﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Framework.Core.ObjectTaxonomy;

namespace TextMetal.Framework.XmlDialect
{
	/// <summary>
	/// Represents an XML object and it's "schema".
	/// </summary>
	public interface IXmlObject : IHierarchicalObject
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// Gets an array of allowed child XML object types.
		/// </summary>
		Type[] AllowedChildTypes
		{
			get;
		}

		/// <summary>
		/// Gets a list of XML object items.
		/// </summary>
		IXmlObjectCollection<IXmlObject> Items
		{
			get;
		}

		/// <summary>
		/// Gets or sets the optional single XML object content.
		/// </summary>
		IXmlObject Content
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the parent XML object or null if this is the document root.
		/// </summary>
		new IXmlObject Parent
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the surround XML object or null if this is not surrounded (in a collection).
		/// </summary>
		new IXmlObjectCollection Surround
		{
			get;
			set;
		}

		#endregion
	}
}