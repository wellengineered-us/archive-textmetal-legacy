﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Xml;

namespace TextMetal.Framework.TemplateModel
{
	[XmlElementMapping(LocalName = "If", NamespaceUri = "http://www.textmetal.com/api/v6.0.0", ChildElementModel = ChildElementModel.Sterile)]
	public sealed class IfConstruct : ConditionalBranchConstruct
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the IfConstruct class.
		/// </summary>
		public IfConstruct()
			: base(true)
		{
		}

		#endregion
	}
}