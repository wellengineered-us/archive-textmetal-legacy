﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Framework.XmlDialect;

namespace TextMetal.Framework.Core
{
	/// <summary>
	/// Represents an associative XML object.
	/// </summary>
	public interface IAssociativeXmlObject : IAssociativeMechanism, IXmlObject
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the associative name of the current associative XML object.
		/// </summary>
		string Name
		{
			get;
		}

		#endregion
	}
}