﻿/*
	Copyright ©2002-2011 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Core.TemplateModel;
using TextMetal.Core.TokenModel;
using TextMetal.Core.XmlModel;

namespace TextMetal.Core.ExpressionModel
{
	[XmlElementMapping(LocalName = "ExpressionContainer", NamespaceUri = "http://code.google.com/p/textmetal/rev3", ChildElementModel = ChildElementModel.Content)]
	public sealed class ExpressionContainerConstruct : ExpressionXmlObject
	{
		#region Constructors/Destructors

		public ExpressionContainerConstruct()
		{
		}

		#endregion

		#region Fields/Constants

		private string id;

		#endregion

		#region Properties/Indexers/Events

		public new ExpressionXmlObject Content
		{
			get
			{
				return (ExpressionXmlObject)base.Content;
			}
			set
			{
				base.Content = value;
			}
		}

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

		#endregion

		#region Methods/Operators

		protected override object CoreEvaluateExpression(TemplatingContext templatingContext)
		{
			object ovalue;
			string svalue;
			DynamicWildcardTokenReplacementStrategy dynamicWildcardTokenReplacementStrategy;

			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");

			dynamicWildcardTokenReplacementStrategy = templatingContext.GetDynamicWildcardTokenReplacementStrategy();

			if ((object)this.Content != null)
				ovalue = ((IExpressionXmlObject)this.Content).EvaluateExpression(templatingContext);
			else
				ovalue = null;

			svalue = ovalue as string;

			if ((object)svalue != null)
				ovalue = templatingContext.Tokenizer.ExpandTokens(svalue, dynamicWildcardTokenReplacementStrategy);

			return ovalue;
		}

		#endregion
	}
}