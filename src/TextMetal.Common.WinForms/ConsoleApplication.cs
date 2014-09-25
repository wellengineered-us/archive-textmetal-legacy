﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using TextMetal.Common.Core;

namespace TextMetal.Common.WinForms
{
	public abstract class ConsoleApplication : ExecutableApplication
	{
		#region Constructors/Destructors

		protected ConsoleApplication()
		{
		}

		#endregion

		#region Methods/Operators

		protected override sealed void DisplayArgumentErrorMessage(IEnumerable<Message> argumentMessages)
		{
			ConsoleColor oldConsoleColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			if ((object)argumentMessages != null)
			{
				foreach (Message argumentMessage in argumentMessages)
					Console.WriteLine(argumentMessage.Description);
			}

			Console.ForegroundColor = oldConsoleColor;
		}

		protected override sealed void DisplayArgumentMapMessage(IDictionary<string, ArgumentSpec> argumentMap)
		{
			ConsoleColor oldConsoleColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Magenta;

			var requiredArgumentTokens = argumentMap.Select(m => (!m.Value.Required ? "[" : "") + string.Format("-{0}:value{1}", m.Key, !m.Value.Bounded ? "(s)" : "") + (!m.Value.Required ? "]" : ""));

			if ((object)requiredArgumentTokens != null)
			{
				Console.WriteLine(Environment.NewLine +
					string.Format("USAGE: {0} ", Assembly.GetEntryAssembly().ManifestModule.Name) + string.Join(" ", requiredArgumentTokens) +
					Environment.NewLine);
			}
			
			Console.ForegroundColor = oldConsoleColor;
		}

		protected override sealed void DisplayFailureMessage(Exception exception)
		{
			ConsoleColor oldConsoleColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine((object)exception != null ? Reflexion.GetErrors(exception, 0) : "<unknown>");
			Console.ForegroundColor = oldConsoleColor;

			Console.WriteLine(Environment.NewLine + "The operation failed to complete.");
		}

		protected override sealed void DisplaySuccessMessage(TimeSpan duration)
		{
			Console.WriteLine(Environment.NewLine + "Operation completed successfully; duration: '{0}'.", duration);
		}

		#endregion
	}
}