﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Middleware.Datazoid.Repositories.Impl.Strategies
{
	public interface ISqlNuance
	{
		#region Methods/Operators

		string GetAliasedColumnName(string tableAlias, string columnName);

		string GetColumnName(string columnName);

		int GetExpectedRecordsAffected(bool isNullipotent);

		string GetIdentityFunctionName();

		string GetParameterName(string parameterName);

		string GetProcedureName(string schemaName, string procedureName);

		string GetTableAlias(string tableAlias);

		string GetTableName(string schemaName, string tableName);

		#endregion
	}
}