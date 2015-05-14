﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Xml;
using System.Xml.Linq;

using TextMetal.Middleware.Common.Utilities;
using TextMetal.Middleware.Data.UoW;

namespace TextMetal.Framework.Source.DatabaseSchema.Sql
{
	public class SqlSchemaSourceStrategy : SchemaSourceStrategy
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the SqlSchemaSourceStrategy class.
		/// </summary>
		public SqlSchemaSourceStrategy()
		{
		}

		#endregion

		#region Fields/Constants

		private const string NET_SQL_SERVER_DATA_SOURCE_TAG = "net.sqlserver";

		#endregion

		#region Methods/Operators

		protected override int CoreCalculateColumnSize(string dataSourceTag, Column column)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)column == null)
				throw new ArgumentNullException("column");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return column.ColumnSqlType == "image" ||
						column.ColumnSqlType == "text" ||
						column.ColumnSqlType == "ntext" ? (int)0 :
					(column.ColumnDbType == DbType.String &&
					column.ColumnSqlType.SafeToString().StartsWith("n") &&
					column.ColumnSize != 0 ?
						(int)(column.ColumnSize / 2) :
						column.ColumnSize);
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override int CoreCalculateParameterSize(string dataSourceTag, Parameter parameter)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)parameter == null)
				throw new ArgumentNullException("parameter");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return parameter.ParameterSqlType == "image" ||
						parameter.ParameterSqlType == "text" ||
						parameter.ParameterSqlType == "ntext" ? (int)0 :
					(parameter.ParameterDbType == DbType.String &&
					parameter.ParameterSqlType.SafeToString().StartsWith("n") &&
					parameter.ParameterSize != 0 ?
						(int)(parameter.ParameterSize / 2) :
						parameter.ParameterSize);
			}
			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetColumnParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetColumnParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, View view)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)view == null)
				throw new ArgumentNullException("view");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ViewName", view.ViewName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetDatabaseParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetDdlTriggerParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetDmlTriggerParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override bool CoreGetEmitImplicitReturnParameter(string dataSourceTag)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
				return true;

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetForeignKeyColumnParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table, ForeignKey foreignKey)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if ((object)foreignKey == null)
				throw new ArgumentNullException("foreignKey");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ForeignKeyName", foreignKey.ForeignKeyName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetForeignKeyParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetParameterParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Procedure procedure)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)procedure == null)
				throw new ArgumentNullException("procedure");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ProcedureName", procedure.ProcedureName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override string CoreGetParameterPrefix(string dataSourceTag)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
				return "@";

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetProcedureParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetSchemaParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database)
		{
			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetServerParameters(IUnitOfWork unitOfWork, string dataSourceTag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
				return null;

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetTableParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetUniqueKeyColumnParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table, UniqueKey uniqueKey)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if ((object)uniqueKey == null)
				throw new ArgumentNullException("uniqueKey");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@UniqueKeyName", uniqueKey.UniqueKeyName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override IEnumerable<IDbDataParameter> CoreGetUniqueKeyParameters(IUnitOfWork unitOfWork, string dataSourceTag, Server server, Database database, Schema schema, Table table)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if ((object)server == null)
				throw new ArgumentNullException("server");

			if ((object)database == null)
				throw new ArgumentNullException("database");

			if ((object)schema == null)
				throw new ArgumentNullException("schema");

			if ((object)table == null)
				throw new ArgumentNullException("table");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				return new IDbDataParameter[]
						{
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@ServerName", server.ServerName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@DatabaseName", database.DatabaseName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@SchemaName", schema.SchemaName),
							unitOfWork.CreateParameter(ParameterDirection.Input, DbType.String, 100, 0, 0, true, "@TableName", table.TableName)
						};
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override Type CoreInferClrTypeForSqlType(string dataSourceTag, string sqlType, int sqlPrecision)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				switch (sqlType = sqlType.SafeToString().ToUpper())
				{
					case "BIGINT":
						return typeof(Int64);
					case "BINARY":
						return typeof(Byte[]);
					case "BIT":
						return typeof(Boolean);
					case "CHARACTER":
					case "CHAR":
						return typeof(String);
					case "CURSOR":
						return typeof(Object);
					case "DATE":
						return typeof(DateTime);
					case "DATETIME":
						return typeof(DateTime);
					case "DATETIME2":
						return typeof(DateTime);
					case "DATETIMEOFFSET":
						return typeof(DateTimeOffset);
					case "DEC":
					case "DECIMAL":
						return typeof(Decimal);
					case "DOUBLE PRECISION":
					case "FLOAT":
						return sqlPrecision >= 0 && sqlPrecision <= 24 ? typeof(Single) : (sqlPrecision >= 25 && sqlPrecision <= 53 ? typeof(Double) : typeof(Object));
					case "GEOGRAPHY":
						return typeof(Object);
					case "GEOMETRY":
						return typeof(Object);
					case "HIERARCHYID":
						return typeof(Object);
					case "IMAGE":
						return typeof(Byte[]);
					case "INTEGER":
					case "INT":
						return typeof(Int32);
					case "MONEY":
						return typeof(Decimal);
					case "NATIONAL CHARACTER":
					case "NATIONAL CHAR":
					case "NCHAR":
						return typeof(String);
					case "NATIONAL TEXT":
					case "NTEXT":
						return typeof(String);
					case "NUMERIC":
						return typeof(Decimal);
					case "NATIONAL CHARACTER VARYING":
					case "NATIONAL CHAR VARYING":
					case "NVARCHAR":
						return typeof(String);
					case "REAL":
						return typeof(Single);
					case "TIMESTAMP":
					case "ROWVERSION":
						return typeof(Byte[]);
					case "SMALLDATETIME":
						return typeof(DateTime);
					case "SMALLINT":
						return typeof(Int16);
					case "SMALLMONEY":
						return typeof(Decimal);
					case "SQL_VARIANT":
						return typeof(Object);
					case "SYSNAME":
						return typeof(String);
					case "TABLE":
						return typeof(Object);
					case "TEXT":
						return typeof(String);
					case "TIME":
						return typeof(TimeSpan);
					case "TINYINT":
						return typeof(Byte);
					case "UNIQUEIDENTIFIER":
						return typeof(Guid);
					case "BINARY VARYING":
					case "VARBINARY":
						return typeof(Byte[]);
					case "CHARACTER VARYING":
					case "CHAR VARYING":
					case "VARCHAR":
						return typeof(String);
					case "XML":
						return typeof(XmlDocument);
					default:
						return typeof(Object); // dpb: 2014-05-13/changed behavior here to not throw exception
				}
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		protected override Type CoreInferSqlMetalClrTypeForClrType(string dataSourceTag, Type clrType)
		{
			if ((object)dataSourceTag == null)
				throw new ArgumentNullException("dataSourceTag");

			if (dataSourceTag.SafeToString().ToLower() == NET_SQL_SERVER_DATA_SOURCE_TAG)
			{
				if (clrType == typeof(Byte[]))
					return typeof(Binary);
				else if (clrType == typeof(XmlDocument))
					return typeof(XElement);
				else
					return clrType;
			}

			throw new ArgumentOutOfRangeException(string.Format("dataSourceTag: '{0}'", dataSourceTag));
		}

		#endregion
	}
}