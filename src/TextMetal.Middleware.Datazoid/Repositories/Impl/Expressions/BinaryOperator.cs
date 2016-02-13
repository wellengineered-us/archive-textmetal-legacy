﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.Datazoid.Repositories.Impl.Expressions
{
	public enum BinaryOperator
	{
		Undefined = 0,

		Add,

		Sub,

		Div,

		Mul,

		Mod,

		And,

		Or,

		Eq,

		Ne,

		Lt,

		Le,

		Gt,

		Ge,

		Like,
	}
}