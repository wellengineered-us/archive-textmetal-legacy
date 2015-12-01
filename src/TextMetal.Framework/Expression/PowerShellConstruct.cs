﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;

using TextMetal.Framework.Core;
using TextMetal.Framework.Tokenization;
using TextMetal.Framework.XmlDialect;
using TextMetal.Middleware.Solder.Utilities;

namespace TextMetal.Framework.Expression
{
	[XmlElementMapping(LocalName = "PowerShell", NamespaceUri = "http://www.textmetal.com/api/v6.0.0", ChildElementModel = ChildElementModel.Sterile)]
	public sealed class PowerShellConstruct : ExpressionXmlObject
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the PowerShellConstruct class.
		/// </summary>
		public PowerShellConstruct()
		{
		}

		#endregion

		#region Fields/Constants

		private static readonly PowerShellHost instance = new PowerShellHost();
		private string expr;
		private string file;
		private string script;
		private PowerShellSource src;

		#endregion

		#region Properties/Indexers/Events

		private static PowerShellHost SingletonPowerShellHost
		{
			get
			{
				return instance;
			}
		}

		[XmlAttributeMapping(LocalName = "src", NamespaceUri = "")]
		public string _Src
		{
			get
			{
				return this.Src.SafeToString();
			}
			set
			{
				PowerShellSource src;

				if (!DataTypeFascade.Instance.TryParse<PowerShellSource>(value, out src))
					this.Src = PowerShellSource.Unknown;
				else
					this.Src = src;
			}
		}

		[XmlAttributeMapping(LocalName = "expr", NamespaceUri = "")]
		public string Expr
		{
			get
			{
				return this.expr;
			}
			set
			{
				this.expr = value;
			}
		}

		[XmlAttributeMapping(LocalName = "file", NamespaceUri = "")]
		public string File
		{
			get
			{
				return this.file;
			}
			set
			{
				this.file = value;
			}
		}

		[XmlChildElementMapping(LocalName = "Script", NamespaceUri = "http://www.textmetal.com/api/v6.0.0", ChildElementType = ChildElementType.TextValue)]
		public string Script
		{
			get
			{
				return this.script;
			}
			set
			{
				this.script = value;
			}
		}

		public PowerShellSource Src
		{
			get
			{
				return this.src;
			}
			set
			{
				this.src = value;
			}
		}

		#endregion

		#region Methods/Operators

		public static object PowerShellExpressionResolver(ITemplatingContext context, string[] parameters)
		{
			const int CNT_P = 1; // expr

			if ((object)context == null)
				throw new ArgumentNullException("context");

			if ((object)parameters == null)
				throw new ArgumentNullException("parameters");

			if (parameters.Length != CNT_P)
				throw new InvalidOperationException(string.Format("PowerShellExpressionResolver expects '{1}' parameter(s) but received '{0}' parameter(s).", parameters.Length, CNT_P));

			return new PowerShellConstruct()
					{
						Src = PowerShellSource.Expr,
						Expr = parameters[0]
					}.CoreEvaluateExpression(context);
		}

		protected override object CoreEvaluateExpression(ITemplatingContext templatingContext)
		{
			DynamicWildcardTokenReplacementStrategy dynamicWildcardTokenReplacementStrategy;
			string scriptContent;
			IDictionary<string, object> scriptVariables;

			dynamic result;
			dynamic textMetal;
			Func<string, object> func;
			Action action;
			IDictionary<string, object> scriptFoo;

			if ((object)templatingContext == null)
				throw new ArgumentNullException("templatingContext");

			dynamicWildcardTokenReplacementStrategy = templatingContext.GetDynamicWildcardTokenReplacementStrategy();

			switch (this.Src)
			{
				case PowerShellSource.Script:
					scriptContent = this.Script;
					break;
				case PowerShellSource.Expr:
					scriptContent = this.Expr;
					break;
				case PowerShellSource.File:
					string file;
					file = templatingContext.Tokenizer.ExpandTokens(this.File, dynamicWildcardTokenReplacementStrategy);
					scriptContent = templatingContext.Input.LoadContent(file);
					break;
				default:
					scriptContent = "$null";
					break;
			}

			if (!SingletonPowerShellHost.Compile(scriptContent.GetHashCode(), scriptContent))
				new object(); // in cache already

			scriptFoo = new Dictionary<string, object>();

			func = (token) =>
					{
						object value;
						value = dynamicWildcardTokenReplacementStrategy.Evaluate(token, null);
						//Console.WriteLine("[{0}]={1}", token, value);
						return value;
					};

			action = () => templatingContext.LaunchDebugger();

			scriptFoo.Add("EvaluateToken", func);
			scriptFoo.Add("DebuggerBreakpoint", action);

			textMetal = new DictionaryDynamicObject(scriptFoo);

			scriptVariables = new Dictionary<string, object>();
			scriptVariables.Add("textMetal", textMetal);

			foreach (KeyValuePair<string, object> variableEntry in templatingContext.CurrentVariableTable)
			{
				if (scriptVariables.ContainsKey(variableEntry.Key))
					throw new InvalidOperationException(string.Format("Cannot set variable '{0}' in Ruby script scope; the specified variable name already exists.", variableEntry.Key));

				scriptVariables.Add(variableEntry.Key, variableEntry.Value);
			}

			result = SingletonPowerShellHost.Execute(scriptContent.GetHashCode(), scriptVariables);
			return result;
		}

		#endregion

		#region Classes/Structs/Interfaces/Enums/Delegates

		public enum PowerShellSource
		{
			Unknown = 0,
			Script,
			Expr,
			File
		}

		#endregion
	}
}