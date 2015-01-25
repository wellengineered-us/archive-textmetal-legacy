/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Common.Syntax.Expressions
{
	/// <summary>
	/// Represents a value.
	/// </summary>
	public interface IValue : IExpression
	{
		#region Properties/Indexers/Events

		object __
		{
			get;
		}

		#endregion
	}
}