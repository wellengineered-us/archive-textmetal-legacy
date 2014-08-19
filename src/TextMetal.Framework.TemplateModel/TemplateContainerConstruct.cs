﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Tokenization;
using TextMetal.Common.Xml;
using TextMetal.Framework.Core;

namespace TextMetal.Framework.TemplateModel
{
	[XmlElementMapping(LocalName = "TemplateContainer", NamespaceUri = "http://www.textmetal.com/api/v6.0.0", ChildElementModel = ChildElementModel.Items)]
	public sealed class TemplateContainerConstruct : TemplateXmlObject, ITemplateContainerConstruct
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the TemplateContainerConstruct class.
		/// </summary>
		public TemplateContainerConstruct()
		{
		}

		#endregion

		#region Fields/Constants

		private string id;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the associative ID of the current associative model container XML object.
		/// </summary>
		[XmlAttributeMapping(LocalName = "id", NamespaceUri = "")]
		public string Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		public new IXmlObjectCollection<ITemplateXmlObject> Items
		{
			get
			{
				return new ContravariantListAdapter<ITemplateXmlObject, IXmlObject>(base.Items);
			}
		}

		#endregion

		#region Methods/Operators

		protected override void CoreExpandTemplate(ITemplatingContext templatingContext)
		{
			DynamicWildcardTokenReplacementStrategy dynamicWildcardTokenReplacementStrategy;

			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");

			dynamicWildcardTokenReplacementStrategy = templatingContext.GetDynamicWildcardTokenReplacementStrategy();

			if ((object)this.Items != null)
			{
				foreach (ITemplateMechanism templateMechanism in this.Items)
					templateMechanism.ExpandTemplate(templatingContext);
			}
		}

		#endregion
	}
}