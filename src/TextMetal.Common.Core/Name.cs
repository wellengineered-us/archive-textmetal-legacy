﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Globalization;
using System.Text;

using Microsoft.CSharp;

namespace TextMetal.Common.Core
{
	/// <summary>
	/// Internal set of static methods used to format a name (symbol) in US English.
	/// </summary>
	public static class Name
	{
		#region Methods/Operators

		/// <summary>
		/// Gets the camel (e.g. 'myVariableName') form of a name. This method strips underscores.
		/// </summary>
		/// <param name="value"> The value to which to get the camel case form. </param>
		/// <returns> The camel case, valid C# identifier form of the specified value. </returns>
		public static string GetCamelCase(string value)
		{
			StringBuilder sb;
			char prev;
			int i = 0;
			bool toupper = false;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			sb = new StringBuilder();
			prev = value[0];

			foreach (char curr in value)
			{
				if (curr == '_')
				{
					toupper = true;
					continue; // ignore setting prev=curr
				}

				toupper = toupper || char.IsDigit(prev) || (char.IsLower(prev) && char.IsUpper(curr));

				if (toupper)
					sb.Append(char.ToUpper(curr));
				else
					sb.Append(char.ToLower(curr));

				prev = curr;
				i++;
				toupper = false;
			}

			return sb.ToString();
		}

		/// <summary>
		/// Gets the contant (e.g. 'MY_VARIABLE_NAME') form of a name. This method adds underscores at case change boundaries.
		/// </summary>
		/// <param name="value"> The value to which to get the constant case form. </param>
		/// <returns> The constant case, valid C# identifier form of the specified value. </returns>
		public static string GetConstantCase(string value)
		{
			StringBuilder sb;
			char prev;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			sb = new StringBuilder();
			prev = value[0];

			foreach (char curr in value)
			{
				if (curr == '_')
					continue;

				if (char.IsLower(prev) && char.IsUpper(curr))
					sb.Append('_');

				sb.Append(char.ToUpper(curr));
				prev = curr;
			}

			return sb.ToString();
		}

		/// <summary>
		/// Gets the Pascal (e.g. 'MyVariableName') form of a name. This method strips underscores.
		/// </summary>
		/// <param name="value"> The value to which to get the Pascal case form. </param>
		/// <returns> The Pascal case, valid C# identifier form of the specified value. </returns>
		public static string GetPascalCase(string value)
		{
			StringBuilder sb;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			value = GetCamelCase(value);
			sb = new StringBuilder(value);

			sb[0] = char.ToUpper(sb[0]);

			return sb.ToString();
		}

		/// <summary>
		/// Gets the plural (e.g. 'myVariableNames') form of a name. This method uses basic stemming.
		/// </summary>
		/// <param name="value"> The value to which to get the plural form. </param>
		/// <returns> The plural, valid C# identifier form of the specified value. </returns>
		public static string GetPluralForm(string value)
		{
			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			if (value.EndsWith("x", StringComparison.OrdinalIgnoreCase) ||
				value.EndsWith("ch", StringComparison.OrdinalIgnoreCase) ||
				(value.EndsWith("ss", StringComparison.OrdinalIgnoreCase) ||
				value.EndsWith("sh", StringComparison.OrdinalIgnoreCase)))
				value = value + "es";
			else if (value.EndsWith("y", StringComparison.OrdinalIgnoreCase) && value.Length > 1 &&
					!IsVowel(value[value.Length - 2]))
			{
				value = value.Remove(value.Length - 1, 1);
				value = value + "ies";
			}
			else if (!value.EndsWith("s", StringComparison.OrdinalIgnoreCase))
				value = value + "s";

			return value;
		}

		/// <summary>
		/// Gets the singular (e.g. 'myVariableName') form of a name. This method uses basic stemming.
		/// </summary>
		/// <param name="value"> The value to which to get the singular form. </param>
		/// <returns> The singular, valid C# identifier form of the specified value. </returns>
		public static string GetSingularForm(string value)
		{
			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			if (string.Compare(value, "series", StringComparison.OrdinalIgnoreCase) == 0)
				return value;

			if (string.Compare(value, "wines", StringComparison.OrdinalIgnoreCase) == 0)
				return value.Remove(value.Length - 1, 1);

			if (value.Length > 3 && value.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
			{
				if (!IsVowel(value[value.Length - 4]))
				{
					value = value.Remove(value.Length - 3, 3);
					value = value + 'y';
				}
			}
			else if (value.EndsWith("ees", StringComparison.OrdinalIgnoreCase))
				value = value.Remove(value.Length - 1, 1);
			else if (value.EndsWith("ches", StringComparison.OrdinalIgnoreCase) || value.EndsWith("xes", StringComparison.OrdinalIgnoreCase) || value.EndsWith("sses", StringComparison.OrdinalIgnoreCase))
				value = value.Remove(value.Length - 2, 2);
			else
			{
				if (string.Compare(value, "gas", StringComparison.OrdinalIgnoreCase) == 0 || value.Length <= 1 || (!value.EndsWith("s", StringComparison.OrdinalIgnoreCase) || value.EndsWith("ss", StringComparison.OrdinalIgnoreCase)) || value.EndsWith("us", StringComparison.OrdinalIgnoreCase))
					return value;
				value = value.Remove(value.Length - 1, 1);
			}

			return value;
		}

		/// <summary>
		/// Gets the camel (e.g. 'myVariableName') form of a name. This method mimics SqlMetal.exe.
		/// </summary>
		/// <param name="value"> The value to which to get the camel case form. </param>
		/// <returns> The camel case, valid C# identifier form of the specified value. </returns>
		public static string GetSqlMetalCamelCase(string value)
		{
			StringBuilder sb;
			bool flag = true;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			sb = new StringBuilder();

			for (int index = 0; index < value.Length; ++index)
			{
				char ch = value[index];

				if ((int)ch >= 97 && (int)ch <= 122 ||
					(int)ch >= 65 && (int)ch <= 90 ||
					((int)ch >= 48 && (int)ch <= 57 ||
					(int)ch == 95))
				{
					if (flag)
						ch = char.ToUpper(ch, CultureInfo.InvariantCulture);

					flag = false;
					sb.Append(ch);
				}
				else
				{
					flag = true;
					sb.Append(ch);
				}
			}

			value = sb.ToString();
			return value;
		}

		public static string GetSqlMetalObjectNamePascalCase(string schemaName, string objectName)
		{
			string value;

			if ((object)schemaName == null)
				throw new ArgumentNullException("schemaName");

			if ((object)objectName == null)
				throw new ArgumentNullException("objectName");

			if (!DataType.Instance.IsNullOrWhiteSpace(schemaName) && schemaName.ToLower() != "dbo")
				value = string.Format("{0}_{1}", GetSqlMetalPascalCase(schemaName), GetSqlMetalPascalCase(objectName));
			else
				value = string.Format("{0}", GetSqlMetalPascalCase(objectName));

			return value;
		}

		/// <summary>
		/// Gets the Pascal (e.g. 'MyVariableName') form of a name. This method mimics SqlMetal.exe.
		/// </summary>
		/// <param name="value"> The value to which to get the Pascal case form. </param>
		/// <returns> The Pascal case, valid C# identifier form of the specified value. </returns>
		public static string GetSqlMetalPascalCase(string value)
		{
			StringBuilder sb;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			value = GetValidCSharpIdentifier(value);

			if (value.Length < 1)
				return value;

			value = GetSqlMetalCamelCase(value);
			sb = new StringBuilder(value);

			sb[0] = char.ToUpper(sb[0]);

			return sb.ToString();
		}

		/// <summary>
		/// Gets a valid C# identifier from the specified name (symbol).
		/// </summary>
		/// <param name="value"> The value to which to derive the C# identifier. </param>
		/// <returns> The valid C# identifier form of the specified value. </returns>
		private static string GetValidCSharpIdentifier(string value)
		{
			bool first = true;
			StringBuilder sb;

			if ((object)value == null)
				throw new ArgumentNullException("value");

			sb = new StringBuilder();

			foreach (char curr in value)
			{
				if (!(first && char.IsDigit(curr)) && (char.IsLetterOrDigit(curr) || curr == '_'))
					sb.Append(curr);
				else if ((first && char.IsDigit(curr)) || curr == ' ')
					sb.Append('_');
				else
					; // skip

				first = false;
			}

			return sb.ToString();
		}

		/// <summary>
		/// Gets a value indicating whether the specified value is a valid C# identifier.
		/// </summary>
		/// <param name="value"> The value to test as a C# identifier. </param>
		/// <returns> True if the specified value is a valid C# identifier; otherwise false. </returns>
		public static bool IsValidCSharpIdentifier(string value)
		{
			return new CSharpCodeProvider().IsValidIdentifier(value);
		}

		/// <summary>
		/// Gets a value indicating whether the specified character is a vowel (US English).
		/// </summary>
		/// <param name="ch"> The value to test as a vowel (US English). </param>
		/// <returns> True if the specified value is a vowel (US English); otherwise false. </returns>
		private static bool IsVowel(char ch)
		{
			switch (ch)
			{
				case 'A':
				case 'E':
				case 'I':
				case 'O':
				case 'U':
				case 'Y':
					return true;
				case 'a':
				case 'e':
				case 'i':
				case 'o':
				case 'u':
				case 'y':
					return true;
				default:
					return false;
			}
		}

		#endregion
	}
}