﻿/*
	Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Expressions;
using TextMetal.Common.Xml;
using TextMetal.Framework.Core;

namespace TextMetal.Framework.ExpressionModel
{
	[XmlKnownElementMapping(LocalName = "ExpressionContainer", NamespaceUri = "http://www.textmetal.com/api/v5.0.0", ChildElementModel = ChildElementModel.Content)]
	public interface IExpressionContainerConstruct : IContentContainerXmlObject<IExpressionXmlObject>, IExpressionXmlObject, IExpression
	{
	}
}