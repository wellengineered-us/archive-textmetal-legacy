﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Middleware.Datazoid.Primitives
{
	public interface IColumn
	{
		#region Properties/Indexers/Events

		int ColumnIndex
		{
			get;
		}

		bool? ColumnIsNullable
		{
			get;
		}

		string ColumnName
		{
			get;
		}

		Type ColumnType
		{
			get;
		}

		int TableIndex
		{
			get;
		}

		object TagContext
		{
			get;
		}

		#endregion
	}
}