/*
	Copyright �2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Collections.Generic;

using TextMetal.Middleware.Solder.Extensions;
using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Oxymoron.Legacy.Config.Strategies
{
	public class ScriptObfuscationStrategyConfiguration : ObfuscationStrategyConfiguration
	{
		#region Constructors/Destructors

		public ScriptObfuscationStrategyConfiguration()
		{
		}

		#endregion

		#region Fields/Constants

		private string sourceCode;

		#endregion

		#region Properties/Indexers/Events

		public string SourceCode
		{
			get
			{
				return this.sourceCode;
			}
			set
			{
				this.sourceCode = value;
			}
		}

		#endregion

		#region Methods/Operators

		public override IEnumerable<Message> Validate(int? columnIndex)
		{
			List<Message> messages;

			messages = new List<Message>();

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.SourceCode))
				messages.Add(NewError(string.Format("Column[{0}/{1}] source code is required.", columnIndex, this.Parent.ColumnName)));

			return messages;
		}

		#endregion
	}
}