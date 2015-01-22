/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Linq;

namespace TextMetal.Common.Core
{
	public sealed class DelimitedTextSpec
	{
		#region Constructors/Destructors

		public DelimitedTextSpec()
		{
		}

		#endregion

		#region Fields/Constants

		private string fieldDelimiter;
		private bool firstRecordIsHeader;
		private string[] headerNames;
		private string quoteValue;
		private string recordDelimiter;

		#endregion

		#region Properties/Indexers/Events

		public string FieldDelimiter
		{
			get
			{
				return this.fieldDelimiter;
			}
			set
			{
				this.fieldDelimiter = value;
			}
		}

		public bool FirstRecordIsHeader
		{
			get
			{
				return this.firstRecordIsHeader;
			}
			set
			{
				this.firstRecordIsHeader = value;
			}
		}

		public string[] HeaderNames
		{
			get
			{
				return this.headerNames;
			}
			set
			{
				this.headerNames = value;
			}
		}

		public string QuoteValue
		{
			get
			{
				return this.quoteValue;
			}
			set
			{
				this.quoteValue = value;
			}
		}

		public string RecordDelimiter
		{
			get
			{
				return this.recordDelimiter;
			}
			set
			{
				this.recordDelimiter = value;
			}
		}

		#endregion

		#region Methods/Operators

		public void AssertValid()
		{
			if (DataType.Instance.IsNullOrEmpty(this.RecordDelimiter))
				throw new InvalidOperationException(string.Format("Record delimiter is invalid."));

			if (DataType.Instance.IsNullOrEmpty(this.FieldDelimiter))
				throw new InvalidOperationException(string.Format("Field delimiter is invalid."));

			if (DataType.Instance.IsNullOrEmpty(this.QuoteValue))
				throw new InvalidOperationException(string.Format("Quote value is invalid."));

			var strings = new string[] { this.RecordDelimiter, this.FieldDelimiter, this.QuoteValue };
			if (strings.GroupBy(s => s).Where(gs => gs.Count() > 1).Any())
				throw new InvalidOperationException(string.Format("Duplicate delimiter/value encountered."));
		}

		#endregion
	}
}