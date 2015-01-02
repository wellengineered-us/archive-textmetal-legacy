﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Xml;
using TextMetal.Framework.Core;

namespace TextMetal.Framework.TemplateModel
{
	[XmlElementMapping(LocalName = "Until", NamespaceUri = "http://www.textmetal.com/api/v6.0.0", ChildElementModel = ChildElementModel.Sterile)]
	public sealed class UntilConstruct : ConditionalIterationConstruct
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the UntilConstruct class.
		/// </summary>
		public UntilConstruct()
			: base(true, false)
		{
		}

		#endregion

		#region Methods/Operators

		protected override void CoreConditionalIterationInitialize(ITemplatingContext templatingContext)
		{
			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");
		}

		protected override void CoreConditionalIterationStep(ITemplatingContext templatingContext, uint indexOneBase)
		{
			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");
		}

		protected override void CoreConditionalIterationTerminate(ITemplatingContext templatingContext)
		{
			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");
		}

		#endregion
	}
}