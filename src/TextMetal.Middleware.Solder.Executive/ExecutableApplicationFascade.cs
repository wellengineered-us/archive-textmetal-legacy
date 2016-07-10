﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using TextMetal.Middleware.Solder.Context;
using TextMetal.Middleware.Solder.Injection;
using TextMetal.Middleware.Solder.Primitives;
using TextMetal.Middleware.Solder.Utilities;

namespace TextMetal.Middleware.Solder.Executive
{
	public abstract class ExecutableApplicationFascade : IExecutableApplicationFascade
	{
		#region Constructors/Destructors

		public ExecutableApplicationFascade(IDataTypeFascade dataTypeFascade, IAppConfigFascade appConfigFascade, IReflectionFascade reflectionFascade, IAssemblyInformationFascade assemblyInformationFascade)
		{
			if ((object)dataTypeFascade == null)
				throw new ArgumentNullException(nameof(dataTypeFascade));

			if ((object)appConfigFascade == null)
				throw new ArgumentNullException(nameof(appConfigFascade));

			if ((object)reflectionFascade == null)
				throw new ArgumentNullException(nameof(reflectionFascade));

			if ((object)assemblyInformationFascade == null)
				throw new ArgumentNullException(nameof(assemblyInformationFascade));

			this.dataTypeFascade = dataTypeFascade;
			this.appConfigFascade = appConfigFascade;
			this.reflectionFascade = reflectionFascade;
			this.assemblyInformationFascade = assemblyInformationFascade;

			Current = this;
		}

		#endregion

		#region Fields/Constants

		private const string APPCONFIG_ARGS_REGEX = @"-(" + APPCONFIG_ID_REGEX_UNBOUNDED + @"{0,63}):(.{0,})";
		private const string APPCONFIG_ID_REGEX_UNBOUNDED = @"[a-zA-Z_\.][a-zA-Z_\.0-9]";
		private const string APPCONFIG_PROPS_REGEX = @"(" + APPCONFIG_ID_REGEX_UNBOUNDED + @"{0,63})=(.{0,})";

		private const string ENV_VAR_SOLDER_DNX_DEBUG_QUIRKS_MODE = "SOLDER_ENABLE_DNX_DEBUG_QUIRKS_MODE";

		private const string ENV_VAR_SOLDER_HOOK_UNHANDLED_EXCEPTIONS = "SOLDER_HOOK_UNHANDLED_EXCEPTIONS";
		private static readonly IContextualStorageFactory contextualStorageFactory = new DefaultContextualStorageFactory(ContextScope.LocalThreadSafe);

		private static readonly string EXECUTABLE_APPLICATION_CONTEXT_CURRENT_KEY = typeof(ExecutableApplicationFascade).GetTypeInfo().GUID.ToString("N");
		private readonly IAppConfigFascade appConfigFascade;
		private readonly IDataTypeFascade dataTypeFascade;
		private readonly IReflectionFascade reflectionFascade;
		private IAssemblyInformationFascade assemblyInformationFascade;
		private bool disposed;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the regular expression pattern for arguments.
		/// </summary>
		public static string ArgsRegEx
		{
			get
			{
				return APPCONFIG_ARGS_REGEX;
			}
		}

		protected static IContextualStorageFactory ContextualStorageFactory
		{
			get
			{
				return contextualStorageFactory;
			}
		}

		public static bool EnableDnxDebugQuirksMode
		{
			get
			{
				IDataTypeFascade dataTypeFascade;
				string svalue;
				bool ovalue;

				dataTypeFascade = AssemblyLoaderContainerContext.TheOnlyAllowedInstance.DependencyManager.ResolveDependency<IDataTypeFascade>(string.Empty, true);
				svalue = Environment.GetEnvironmentVariable(ENV_VAR_SOLDER_DNX_DEBUG_QUIRKS_MODE);

				if ((object)svalue == null)
					return false;

				if (!dataTypeFascade.TryParse<bool>(svalue, out ovalue))
					return false;

				return ovalue;
			}
		}

		public static bool HookUnhandledExceptions
		{
			get
			{
				IDataTypeFascade dataTypeFascade;
				string svalue;
				bool ovalue;

				dataTypeFascade = AssemblyLoaderContainerContext.TheOnlyAllowedInstance.DependencyManager.ResolveDependency<IDataTypeFascade>(string.Empty, true);
				svalue = Environment.GetEnvironmentVariable(ENV_VAR_SOLDER_HOOK_UNHANDLED_EXCEPTIONS);

				if ((object)svalue == null)
					return false;

				if (!dataTypeFascade.TryParse<bool>(svalue, out ovalue))
					return false;

				return !Debugger.IsAttached && ovalue;
			}
		}

		/// <summary>
		/// Gets the regular expression pattern for properties.
		/// </summary>
		public static string PropsRegEx
		{
			get
			{
				return APPCONFIG_PROPS_REGEX;
			}
		}

		public static ExecutableApplicationFascade Current
		{
			get
			{
				return ContextualStorageFactory.GetContextualStorage().GetValue<ExecutableApplicationFascade>(EXECUTABLE_APPLICATION_CONTEXT_CURRENT_KEY);
			}
			set
			{
				ContextualStorageFactory.GetContextualStorage().SetValue<ExecutableApplicationFascade>(EXECUTABLE_APPLICATION_CONTEXT_CURRENT_KEY, value);
			}
		}

		protected IAppConfigFascade AppConfigFascade
		{
			get
			{
				return this.appConfigFascade;
			}
		}

		protected IAssemblyInformationFascade AssemblyInformationFascade
		{
			get
			{
				return this.assemblyInformationFascade;
			}
		}

		protected IDataTypeFascade DataTypeFascade
		{
			get
			{
				return this.dataTypeFascade;
			}
		}

		protected IReflectionFascade ReflectionFascade
		{
			get
			{
				return this.reflectionFascade;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current instance has been disposed.
		/// </summary>
		public bool Disposed
		{
			get
			{
				return this.disposed;
			}
			private set
			{
				this.disposed = value;
			}
		}

		#endregion

		#region Methods/Operators

		protected abstract void DisplayArgumentErrorMessage(IEnumerable<Message> argumentMessages);

		protected abstract void DisplayArgumentMapMessage(IDictionary<string, ArgumentSpec> argumentMap);

		protected abstract void DisplayBannerMessage();

		protected abstract void DisplayFailureMessage(Exception exception);

		protected abstract void DisplayRawArgumentsMessage(string[] args, IEnumerable<string> arguments);

		protected abstract void DisplaySuccessMessage(TimeSpan duration);

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.Disposed)
				return;

			if (disposing)
			{
				if ((object)Current != null)
					Current = null;
			}
		}

		/// <summary>
		/// The indirect entry point method for this application. Code is wrapped in this method to leverage the 'TryStartup'/'Startup' pattern. This method, if used, wraps the Startup() method in an exception handler. The handler will catch all exceptions and report a full detailed stack trace to the Console.Error stream; -1 is then returned as the exit code. Otherwise, if no exception is thrown, the exit code returned is that which is returned by Startup().
		/// </summary>
		/// <param name="args"> The command line arguments passed from the executing environment. </param>
		/// <returns> The resulting exit code. </returns>
		public int EntryPoint(string[] args)
		{
			if (HookUnhandledExceptions)
				return this.TryStartup(args);
			else
				return this.Startup(args);
		}

		protected abstract IDictionary<string, ArgumentSpec> GetArgumentMap();

		protected abstract int OnStartup(string[] args, IDictionary<string, IList<object>> arguments);

		/// <summary>
		/// Given a string array of command line arguments, this method will parse the arguments using a well know pattern match to obtain a loosely typed dictionary of key/multi-value pairs for use by applications.
		/// </summary>
		/// <param name="args"> The command line argument array to parse. </param>
		/// <returns> A loosely typed dictionary of key/multi-value pairs. </returns>
		public IDictionary<string, IList<string>> ParseCommandLineArguments(string[] args)
		{
			IDictionary<string, IList<string>> arguments;
			Match match;
			string key, value;
			IList<string> argumentValues;

			if ((object)args == null)
				throw new ArgumentNullException(nameof(args));

			arguments = new Dictionary<string, IList<string>>(StringComparer.CurrentCultureIgnoreCase);

			foreach (string arg in args)
			{
				match = Regex.Match(arg, ArgsRegEx, RegexOptions.IgnorePatternWhitespace);

				if ((object)match == null)
					continue;

				if (!match.Success)
					continue;

				if (match.Groups.Count != 3)
					continue;

				key = match.Groups[1].Value;
				value = match.Groups[2].Value;

				// key is required
				if (this.DataTypeFascade.IsNullOrWhiteSpace(key))
					continue;

				// val is required
				if (this.DataTypeFascade.IsNullOrWhiteSpace(value))
					continue;

				if (!arguments.ContainsKey(key))
					arguments.Add(key, new List<string>());

				argumentValues = arguments[key];

				// duplicate values are ignored
				if (argumentValues.Contains(value))
					continue;

				argumentValues.Add(value);
			}

			return arguments;
		}

		public int ShowNestedExceptionsAndThrowBrickAtProcess(Exception e)
		{
			this.DisplayFailureMessage(e);

			Environment.FailFast(string.Empty, e);

			return Int32.MinValue;
		}

		private int Startup(string[] args)
		{
			int returnCode;
			DateTime start, end;
			TimeSpan duration;
			IDictionary<string, ArgumentSpec> argumentMap;
			IList<Message> argumentValidationMessages;

			IList<string> argumentValues;
			IDictionary<string, IList<string>> arguments;

			IDictionary<string, IList<object>> finalArguments;
			IList<object> finalArgumentValues;
			object finalArgumentValue;

			this.DisplayBannerMessage();
			start = DateTime.UtcNow;

			arguments = this.ParseCommandLineArguments(args);
			argumentMap = this.GetArgumentMap();

			finalArguments = new Dictionary<string, IList<object>>();
			argumentValidationMessages = new List<Message>();

			if ((object)argumentMap != null)
			{
				foreach (string argumentToken in argumentMap.Keys)
				{
					bool argumentExists;
					int argumentValueCount = 0;
					ArgumentSpec argumentSpec;

					if (argumentExists = arguments.TryGetValue(argumentToken, out argumentValues))
						argumentValueCount = argumentValues.Count;

					if (!argumentMap.TryGetValue(argumentToken, out argumentSpec))
						continue;

					if (argumentSpec.Required && !argumentExists)
					{
						argumentValidationMessages.Add(new Message(string.Empty, string.Format("A required argument was not specified: '{0}'.", argumentToken), Severity.Error));
						continue;
					}

					if (argumentSpec.Bounded && argumentValueCount > 1)
					{
						argumentValidationMessages.Add(new Message(string.Empty, string.Format("A bounded argument was specified more than once: '{0}'.", argumentToken), Severity.Error));
						continue;
					}

					if ((object)argumentValues != null)
					{
						finalArgumentValues = new List<object>();

						if ((object)argumentSpec.Type != null)
						{
							foreach (string argumentValue in argumentValues)
							{
								if (!this.DataTypeFascade.TryParse(argumentSpec.Type, argumentValue, out finalArgumentValue))
									argumentValidationMessages.Add(new Message(string.Empty, string.Format("An argument '{0}' value '{1}' was specified that failed to parse to the target type '{2}'.", argumentToken, argumentValue, argumentSpec.Type.FullName), Severity.Error));
								else
									finalArgumentValues.Add(finalArgumentValue);
							}
						}
						else
						{
							foreach (string argumentValue in argumentValues)
								finalArgumentValues.Add(argumentValue);
						}

						finalArguments.Add(argumentToken, finalArgumentValues);
					}
				}
			}

			if (argumentValidationMessages.Any())
			{
				this.DisplayArgumentErrorMessage(argumentValidationMessages);
				this.DisplayArgumentMapMessage(argumentMap);
				//this.DisplayRawArgumentsMessage(args);
				returnCode = -1;
			}
			else
				returnCode = this.OnStartup(args, finalArguments);

			end = DateTime.UtcNow;
			duration = end - start;

			this.DisplaySuccessMessage(duration);

			return returnCode;
		}

		/// <summary>
		/// Given a string property, this method will parse the property using a well know pattern match to obtain an output key/value pair for use by applications.
		/// </summary>
		/// <param name="arg"> The property to parse. </param>
		/// <param name="key"> The output property key. </param>
		/// <param name="value"> The output property value. </param>
		/// <returns> A value indicating if the parse was successful or not. </returns>
		public bool TryParseCommandLineArgumentProperty(string arg, out string key, out string value)
		{
			Match match;
			string k, v;

			key = null;
			value = null;

			if ((object)arg == null)
				throw new ArgumentNullException(nameof(arg));

			match = Regex.Match(arg, PropsRegEx, RegexOptions.IgnorePatternWhitespace);

			if ((object)match == null)
				return false;

			if (!match.Success)
				return false;

			if (match.Groups.Count != 3)
				return false;

			k = match.Groups[1].Value;
			v = match.Groups[2].Value;

			// key is required
			if (this.DataTypeFascade.IsNullOrWhiteSpace(k))
				return false;

			// val is required
			if (this.DataTypeFascade.IsNullOrWhiteSpace(v))
				return false;

			key = k;
			value = v;
			return true;
		}

		private int TryStartup(string[] args)
		{
			try
			{
				return this.Startup(args);
			}
			catch (Exception ex)
			{
				return this.ShowNestedExceptionsAndThrowBrickAtProcess(new Exception("Main", ex));
			}

			return -1;
		}

		#endregion

		#region Classes/Structs/Interfaces/Enums/Delegates

		protected class ArgumentSpec
		{
			#region Constructors/Destructors

			public ArgumentSpec(Type type, bool required, bool bounded)
			{
				this.type = type ?? typeof(Object);
				this.required = required;
				this.bounded = bounded;
			}

			#endregion

			#region Fields/Constants

			private readonly bool bounded;
			private readonly bool required;
			private readonly Type type;

			#endregion

			#region Properties/Indexers/Events

			public bool Bounded
			{
				get
				{
					return this.bounded;
				}
			}

			public bool Required
			{
				get
				{
					return this.required;
				}
			}

			public Type Type
			{
				get
				{
					return this.type;
				}
			}

			#endregion
		}

		protected class ArgumentSpec<T> : ArgumentSpec
		{
			#region Constructors/Destructors

			public ArgumentSpec(bool required, bool bounded)
				: base(typeof(T), required, bounded)
			{
			}

			#endregion
		}

		#endregion
	}
}