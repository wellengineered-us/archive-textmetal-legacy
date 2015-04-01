﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Framework.Core.ObjectTaxonomy
{
	/// <summary>
	/// Represents a hierarchical object collection.
	/// </summary>
	public interface IHierarchicalObjectCollection /* : IList*/
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the site hierarchical object or null if this is unattached.
		/// </summary>
		IHierarchicalObject Site
		{
			get;
		}

		#endregion
	}
}