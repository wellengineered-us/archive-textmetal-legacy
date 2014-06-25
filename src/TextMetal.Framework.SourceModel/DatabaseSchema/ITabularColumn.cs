/*
	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Framework.SourceModel.DatabaseSchema
{
	[Obsolete("Provided for model breaking change compatability only.")]
	public interface ITabularColumn
	{
		#region Properties/Indexers/Events

		bool ColumnHasCheck
		{
			get;
		}

		bool ColumnHasDefault
		{
			get;
		}

		bool ColumnIsComputed
		{
			get;
		}

		bool ColumnIsIdentity
		{
			get;
		}

		bool ColumnIsPrimaryKey
		{
			get;
		}

		int ColumnPrimaryKeyOrdinal
		{
			get;
		}

		bool IsColumnServerGeneratedPrimaryKey
		{
			get;
		}

		#endregion
	}
}