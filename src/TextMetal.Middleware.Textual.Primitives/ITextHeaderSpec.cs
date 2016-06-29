/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Globalization;

namespace TextMetal.Middleware.Textual.Primitives
{
	public interface ITextHeaderSpec
	{
		#region Properties/Indexers/Events

		NumberFormatInfo FieldNumberFormatSpec
		{
			get;
			set;
		}

		FieldType FieldType
		{
			get;
			set;
		}

		string HeaderName
		{
			get;
			set;
		}

		#endregion
	}
}