﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.Datazoid.Repositories.Impl.Expressions
{
	/// <summary>
	/// Represents a literal value.
	/// </summary>
	public sealed class LiteralValue : IExpression
	{
		#region Constructors/Destructors

		public LiteralValue(object _)
		{
			this._ = _;
		}

		#endregion

		#region Fields/Constants

		private readonly object _;

		#endregion

		#region Properties/Indexers/Events

		public object __
		{
			get
			{
				return this._;
			}
		}

		#endregion
	}
}