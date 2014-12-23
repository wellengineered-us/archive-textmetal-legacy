/*
	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Data;

using TextMetal.Common.Core;

namespace TextMetal.Common.Data.Framework.Strategy
{
	public sealed class OdbcSqlServerDataSourceTagStrategy : DataSourceTagStrategy
	{
		#region Constructors/Destructors

		private OdbcSqlServerDataSourceTagStrategy()
			: base(ODBC_SQL_SERVER_DATA_SOURCE_TAG, false, true)
		{
		}

		#endregion

		#region Fields/Constants

		private const string ODBC_SQL_SERVER_COLUMN_ALIASED_FORMAT = "{0}.[{1}]";
		private const string ODBC_SQL_SERVER_COLUMN_NAME_FORMAT = "[{0}]";
		private const string ODBC_SQL_SERVER_DATA_SOURCE_TAG = "odbc.sqlserver";
		private const string ODBC_SQL_SERVER_IDENTITY_FUNCTION_NAME = "SCOPE_IDENTITY()";
		private const string ODBC_SQL_SERVER_PARAMETER_NAME_FORMAT = "?";
		private const int ODBC_SQL_SERVER_PERSIST_NOT_EXPECTED_RECORDS_AFFECTED = 0;
		private const string ODBC_SQL_SERVER_PROCEDURE_NAME_FORMAT = "[{0}]";
		private const int ODBC_SQL_SERVER_QUERY_EXPECTED_RECORDS_AFFECTED = -1;
		private const string ODBC_SQL_SERVER_SCHEMA_PROCEDURE_NAME_FORMAT = "[{0}].[{1}]";
		private const string ODBC_SQL_SERVER_SCHEMA_TABLE_NAME_FORMAT = "[{0}].[{1}]";
		private const string ODBC_SQL_SERVER_TABLE_ALIAS_FORMAT = "{0}";
		private const string ODBC_SQL_SERVER_TABLE_NAME_FORMAT = "[{0}]";
		private static readonly OdbcSqlServerDataSourceTagStrategy instance = new OdbcSqlServerDataSourceTagStrategy();

		#endregion

		#region Properties/Indexers/Events

		public string DataSourceTag
		{
			get
			{
				return ODBC_SQL_SERVER_DATA_SOURCE_TAG;
			}
		}

		public static OdbcSqlServerDataSourceTagStrategy Instance
		{
			get
			{
				return instance;
			}
		}

		#endregion

		#region Methods/Operators

		public bool CreateNativeDatabaseFile(string databaseFilePath)
		{
			return false;
		}

		public override string GetAliasedColumnName(string tableAlias, string columnName)
		{
			string retVal;

			retVal = string.Format(ODBC_SQL_SERVER_COLUMN_ALIASED_FORMAT, this.GetTableAlias(tableAlias), columnName);

			return retVal;
		}

		public override string GetColumnName(string columnName)
		{
			string retVal;

			retVal = string.Format(ODBC_SQL_SERVER_COLUMN_NAME_FORMAT, columnName);

			return retVal;
		}

		public override int GetExpectedRecordsAffected(bool isNullipotent)
		{
			if (!isNullipotent)
				return ODBC_SQL_SERVER_PERSIST_NOT_EXPECTED_RECORDS_AFFECTED;
			else
				return ODBC_SQL_SERVER_QUERY_EXPECTED_RECORDS_AFFECTED;
		}

		public override string GetIdentityFunctionName()
		{
			string retVal;

			retVal = ODBC_SQL_SERVER_IDENTITY_FUNCTION_NAME;

			return retVal;
		}

		public override string GetParameterName(string parameterName)
		{
			string retVal;

			retVal = string.Format(ODBC_SQL_SERVER_PARAMETER_NAME_FORMAT, parameterName);

			return retVal;
		}

		public override string GetProcedureName(string schemaName, string procedureName)
		{
			string retVal;

			retVal = !DataType.Instance.IsNullOrWhiteSpace(schemaName) ?
				string.Format(ODBC_SQL_SERVER_SCHEMA_PROCEDURE_NAME_FORMAT, schemaName, procedureName) :
				string.Format(ODBC_SQL_SERVER_PROCEDURE_NAME_FORMAT, procedureName);

			return retVal;
		}

		public override string GetTableAlias(string tableAlias)
		{
			string retVal;

			retVal = string.Format(ODBC_SQL_SERVER_TABLE_ALIAS_FORMAT, tableAlias);

			return retVal;
		}

		public override string GetTableName(string schemaName, string tableName)
		{
			string retVal;

			retVal = !DataType.Instance.IsNullOrWhiteSpace(schemaName) ?
				string.Format(ODBC_SQL_SERVER_SCHEMA_TABLE_NAME_FORMAT, schemaName, tableName) :
				string.Format(ODBC_SQL_SERVER_TABLE_NAME_FORMAT, tableName);

			return retVal;
		}

		public override void ParameterMagic(IUnitOfWork unitOfWork, IDbDataParameter commandParameter, string originalSqlType)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)commandParameter == null)
				throw new ArgumentNullException("commandParameter");

			if (originalSqlType.SafeToString().ToUpper() == "NTEXT")
				Reflexion.Instance.SetLogicalPropertyValue(commandParameter, "OdbcType", Enum.Parse(Type.GetType("System.Data.Odbc.OdbcType, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true), "NText", true));
			else if (originalSqlType.SafeToString().ToUpper() == "TEXT")
				Reflexion.Instance.SetLogicalPropertyValue(commandParameter, "OdbcType", Enum.Parse(Type.GetType("System.Data.Odbc.OdbcType, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true), "Text", true));
			else if (originalSqlType.SafeToString().ToUpper() == "IMAGE")
				Reflexion.Instance.SetLogicalPropertyValue(commandParameter, "OdbcType", Enum.Parse(Type.GetType("System.Data.Odbc.OdbcType, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true), "Image", true));
		}

		#endregion
	}
}