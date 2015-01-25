﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Common.Core;
using TextMetal.Common.Core.Tokenization;
using TextMetal.Common.Xml;
using TextMetal.Framework.AssociativeModel;
using TextMetal.Framework.Core;
using TextMetal.Framework.DebuggerProfilerModel;
using TextMetal.Framework.ExpressionModel;
using TextMetal.Framework.SortModel;
using TextMetal.Framework.TemplateModel;

namespace TextMetal.Framework.HostingModel
{
	/// <summary>
	/// A set of extension methods to manage the XML Persist Engine model. NOTE: This file must be updated when adding or removing constructs.
	/// </summary>
	public static class WellKnownExtensions
	{
		#region Methods/Operators

		public static object printf(ITemplatingContext context, string[] parameters)
		{
			const int CNT_P = 2; // token, format
			object value;

			if ((object)context == null)
				throw new ArgumentNullException("context");

			if ((object)parameters == null)
				throw new ArgumentNullException("parameters");

			if (parameters.Length != CNT_P)
				throw new InvalidOperationException(string.Format("printf expects '{1}' parameter(s) but received '{0}' parameter(s).", parameters.Length, CNT_P));

			var x = context.GetDynamicWildcardTokenReplacementStrategy();

			if (!x.GetByToken(parameters[0], out value))
				return null;

			return value.SafeToString(parameters[1]);
		}

		/// <summary>
		/// Quickly register all well-known constructs within this framework.
		/// </summary>
		/// <param name="xpe"> The target XML Persist Engine instance. </param>
		public static void RegisterWellKnownConstructs(this IXmlPersistEngine xpe)
		{
			if ((object)xpe == null)
				throw new ArgumentNullException("xpe");

			xpe.RegisterKnownXmlTextObject<TemplateXmlTextObject>();

			xpe.RegisterKnownXmlObject<DebuggerBreakpointConstruct>();

			xpe.RegisterKnownXmlObject<AssociativeContainerConstruct>();
			xpe.RegisterKnownXmlObject<ArrayConstruct>();
			xpe.RegisterKnownXmlObject<ObjectConstruct>();
			xpe.RegisterKnownXmlObject<PropertyConstruct>();
			xpe.RegisterKnownXmlObject<ProxyConstruct>();

			xpe.RegisterKnownXmlObject<AspectConstruct>();
			xpe.RegisterKnownXmlObject<BinaryExpressionConstruct>();
			xpe.RegisterKnownXmlObject<ExpressionContainerConstruct>();
			xpe.RegisterKnownXmlObject<FacetConstruct>();
			xpe.RegisterKnownXmlObject<NullaryExpressionConstruct>();
			xpe.RegisterKnownXmlObject<RubyConstruct>();
			xpe.RegisterKnownXmlObject<UnaryExpressionConstruct>();
			xpe.RegisterKnownXmlObject<ValueConstruct>();

			xpe.RegisterKnownXmlObject<AscendingConstruct>();
			xpe.RegisterKnownXmlObject<DescendingConstruct>();
			xpe.RegisterKnownXmlObject<SortContainerConstruct>();

			xpe.RegisterKnownXmlObject<AliasConstruct>();
			xpe.RegisterKnownXmlObject<AllocConstruct>();
			xpe.RegisterKnownXmlObject<AssignConstruct>();
			xpe.RegisterKnownXmlObject<DoUntilConstruct>();
			xpe.RegisterKnownXmlObject<DoWhileConstruct>();
			xpe.RegisterKnownXmlObject<ExpandoConstruct>();
			xpe.RegisterKnownXmlObject<ForConstruct>();
			xpe.RegisterKnownXmlObject<ForEachConstruct>();
			xpe.RegisterKnownXmlObject<FreeConstruct>();
			xpe.RegisterKnownXmlObject<IfConstruct>();
			xpe.RegisterKnownXmlObject<ImportConstruct>();
			xpe.RegisterKnownXmlObject<IncludeConstruct>();
			xpe.RegisterKnownXmlObject<InvokeSourceStrategyConstruct>();
			xpe.RegisterKnownXmlObject<LogConstruct>();
			xpe.RegisterKnownXmlObject<OutputScopeConstruct>();
			xpe.RegisterKnownXmlObject<ReferenceConstruct>();
			xpe.RegisterKnownXmlObject<TemplateConstruct>();
			xpe.RegisterKnownXmlObject<TemplateContainerConstruct>();
			xpe.RegisterKnownXmlObject<UnlessConstruct>();
			xpe.RegisterKnownXmlObject<UntilConstruct>();
			xpe.RegisterKnownXmlObject<WhileConstruct>();
			xpe.RegisterKnownXmlObject<WriteConstruct>();
		}

		public static void RegisterWellKnownTokenReplacementStrategies(this Tokenizer tokenizer, ITemplatingContext templatingContext)
		{
			if ((object)tokenizer == null)
				throw new ArgumentNullException("tokenizer");

			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");

			tokenizer.TokenReplacementStrategies.Add("StaticPropertyResolver", new DynamicValueTokenReplacementStrategy(DynamicValueTokenReplacementStrategy.StaticPropertyResolver));
			tokenizer.TokenReplacementStrategies.Add("StaticMethodResolver", new DynamicValueTokenReplacementStrategy(DynamicValueTokenReplacementStrategy.StaticMethodResolver));
			tokenizer.TokenReplacementStrategies.Add("rb", new ContextualDynamicValueTokenReplacementStrategy<ITemplatingContext>(RubyConstruct.RubyExpressionResolver, templatingContext));
			tokenizer.TokenReplacementStrategies.Add("printf", new ContextualDynamicValueTokenReplacementStrategy<ITemplatingContext>(printf, templatingContext));
		}

		#endregion
	}
}