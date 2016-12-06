﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Middleware.Solder.Extensions;

namespace TextMetal.Middleware.Datazoid.Repositories.Impl.Strategies
{
	public sealed class DataSourceTagStrategyFactory : IDataSourceTagStrategyFactory
	{
		#region Constructors/Destructors

		private DataSourceTagStrategyFactory()
		{
		}

		#endregion

		#region Methods/Operators

		public IDataSourceTagStrategy GetDataSourceTagStrategy(string dataSourceTag)
		{
			if (dataSourceTag.SafeToString().ToLower() == NetSqlServerDataSourceTagStrategy.Instance.DataSourceTag.SafeToString().ToLower())
				return NetSqlServerDataSourceTagStrategy.Instance;
			else if (dataSourceTag.SafeToString().ToLower() == NetSqliteDataSourceTagStrategy.Instance.DataSourceTag.SafeToString().ToLower())
				return NetSqliteDataSourceTagStrategy.Instance;
			else if (dataSourceTag.SafeToString().ToLower() == OdbcSqlServerDataSourceTagStrategy.Instance.DataSourceTag.SafeToString().ToLower())
				return OdbcSqlServerDataSourceTagStrategy.Instance;
			else
				throw new InvalidOperationException(string.Format("Data source tag was not recognized: '{0}'.", dataSourceTag));
		}

		#endregion
	}
}