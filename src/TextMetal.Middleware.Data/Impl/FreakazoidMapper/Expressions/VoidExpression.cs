﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Middleware.Data.Impl.FreakazoidMapper.Expressions
{
	public sealed class VoidExpression : IExpression
	{
		#region Constructors/Destructors

		private VoidExpression()
		{
		}

		#endregion

		#region Fields/Constants

		private static readonly VoidExpression instance = new VoidExpression();

		#endregion

		#region Properties/Indexers/Events

		public static VoidExpression Instance
		{
			get
			{
				return instance;
			}
		}

		#endregion
	}
}