﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using TextMetal.Common.Core;
using TextMetal.Common.WinForms;
using TextMetal.HostImpl.Tool;

namespace TextMetal.HostImpl.ConsoleTool
{
	/// <summary>
	/// Entry point class for the application.
	/// </summary>
	internal class Program : ConsoleApplication
	{
		#region Fields/Constants

		private static readonly Program instance = new Program();

		#endregion

		#region Properties/Indexers/Events

		public static Program Instance
		{
			get
			{
				return instance;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// The entry point method for this application.
		/// </summary>
		/// <param name="args"> The command line arguments passed from the executing environment. </param>
		/// <returns> The resulting exit code. </returns>
		[STAThread]
		public static int Main(string[] args)
		{
			using (Instance)
				return Instance.EntryPoint(args);
		}

		protected override IDictionary<string, ArgumentSlot> GetArgumentMap()
		{
			IDictionary<string, ArgumentSlot> argumentMap;

			argumentMap = new Dictionary<string, ArgumentSlot>();
			argumentMap.Add(CMDLN_TOKEN_TEMPLATEFILE, new ArgumentSlot()
			{
				Required = true,
				Bounded = true
			});
			argumentMap.Add(CMDLN_TOKEN_SOURCEFILE, new ArgumentSlot()
			{
				Required = true,
				Bounded = true
			});
			argumentMap.Add(CMDLN_TOKEN_BASEDIR, new ArgumentSlot()
			{
				Required = true,
				Bounded = true
			});
			argumentMap.Add(CMDLN_TOKEN_SOURCESTRATEGY_AQTN, new ArgumentSlot()
			{
				Required = true,
				Bounded = true
			});
			argumentMap.Add(CMDLN_TOKEN_STRICT, new ArgumentSlot()
			{
				Required = true,
				Bounded = true
			});
			argumentMap.Add(CMDLN_TOKEN_PROPERTY, new ArgumentSlot()
			{
				Required = false,
				Bounded = false
			});
			argumentMap.Add(CMDLN_DEBUGGER_LAUNCH, new ArgumentSlot()
			{
				Required = false,
				Bounded = true
			});

			return argumentMap;
		}

		private const string CMDLN_TOKEN_TEMPLATEFILE = "templatefile";
		private const string CMDLN_TOKEN_SOURCEFILE = "sourcefile";
		private const string CMDLN_TOKEN_BASEDIR = "basedir";
		private const string CMDLN_TOKEN_SOURCESTRATEGY_AQTN = "sourcestrategy";
		private const string CMDLN_TOKEN_STRICT = "strict";
		private const string CMDLN_TOKEN_PROPERTY = "property";
		private const string CMDLN_DEBUGGER_LAUNCH = "debug";

		protected override int OnStartup(string[] args, IDictionary<string, IList<string>> arguments)
		{
			Dictionary<string, object> argz;
			string templateFilePath;
			string sourceFilePath;
			string baseDirectoryPath;
			string sourceStrategyAqtn;
			bool strictMatching;
			bool debuggerLaunch = false;
			IDictionary<string, IList<string>> properties;
			IList<string> argumentValues;
			IList<string> propertyValues;
			bool hasProperties;

			if ((object)args == null)
				throw new ArgumentNullException("args");

			if ((object)arguments == null)
				throw new ArgumentNullException("arguments");

			if (arguments.ContainsKey(CMDLN_DEBUGGER_LAUNCH))
				DataType.TryParse<bool>(arguments[CMDLN_DEBUGGER_LAUNCH].Single(), out debuggerLaunch);

			if (debuggerLaunch)
				Console.WriteLine("Debugger launch result: '{0}'", Debugger.Launch() && Debugger.IsAttached);

			// required
			properties = new Dictionary<string, IList<string>>();

			templateFilePath = arguments[CMDLN_TOKEN_TEMPLATEFILE].Single();
			sourceFilePath = arguments[CMDLN_TOKEN_SOURCEFILE].Single();
			baseDirectoryPath = arguments[CMDLN_TOKEN_BASEDIR].Single();
			sourceStrategyAqtn = arguments[CMDLN_TOKEN_SOURCESTRATEGY_AQTN].Single();
			DataType.TryParse<bool>(arguments[CMDLN_TOKEN_STRICT].Single(), out strictMatching);
			
			hasProperties = arguments.TryGetValue(CMDLN_TOKEN_PROPERTY, out argumentValues);

			argz = new Dictionary<string, object>();
			argz.Add(CMDLN_TOKEN_TEMPLATEFILE, templateFilePath);
			argz.Add(CMDLN_TOKEN_SOURCEFILE, sourceFilePath);
			argz.Add(CMDLN_TOKEN_BASEDIR, baseDirectoryPath);
			argz.Add(CMDLN_TOKEN_SOURCESTRATEGY_AQTN, sourceStrategyAqtn);
			argz.Add(CMDLN_TOKEN_STRICT, strictMatching);
			argz.Add(CMDLN_DEBUGGER_LAUNCH, arguments.ContainsKey(CMDLN_DEBUGGER_LAUNCH) ? (object)debuggerLaunch : null);
			argz.Add(CMDLN_TOKEN_PROPERTY, hasProperties ? (object)argumentValues : null);

			if (hasProperties)
			{
				if ((object)argumentValues != null)
				{
					foreach (string argumentValue in argumentValues)
					{
						string key, value;

						if (!AppConfig.TryParseCommandLineArgumentProperty(argumentValue, out key, out value))
							continue;

						if (!properties.ContainsKey(key))
							properties.Add(key, propertyValues = new List<string>());
						else
							propertyValues = properties[key];

						// duplicate values are ignored
						if (propertyValues.Contains(value))
							continue;

						propertyValues.Add(value);
					}
				}
			}

			using (IToolHost toolHost = new ToolHost())
				toolHost.Host((object)args != null ? args.Length : -1, args, argz, templateFilePath, sourceFilePath, baseDirectoryPath, sourceStrategyAqtn, strictMatching, properties);

			return 0;
		}

		#endregion
	}
}