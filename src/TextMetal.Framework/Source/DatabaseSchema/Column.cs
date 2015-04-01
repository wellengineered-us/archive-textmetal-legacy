/*
	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Data;
using System.Xml.Serialization;

using LeastViable.Common.Fascades.Utilities;

namespace TextMetal.Framework.Source.DatabaseSchema
{
	[Serializable]
	public abstract class Column
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the Column class.
		/// </summary>
		protected Column()
		{
		}

		#endregion

		#region Fields/Constants

		private Type columnClrNonNullableType;
		private Type columnClrNullableType;
		private Type columnClrType;
		private string columnCSharpClrNonNullableType;
		private string columnCSharpClrNullableType;
		private string columnCSharpClrType;
		private string columnCSharpDbType;
		private string columnCSharpIsAnonymousLiteral;
		private string columnCSharpNullableLiteral;
		private DbType columnDbType;
		private bool columnIsAnonymous;
		private bool columnIsUserDefinedType;
		private string columnName;
		private string columnNameCamelCase;
		private string columnNameConstantCase;
		private string columnNamePascalCase;
		private string columnNamePluralCamelCase;
		private string columnNamePluralConstantCase;
		private string columnNamePluralPascalCase;
		private string columnNameSingularCamelCase;
		private string columnNameSingularConstantCase;
		private string columnNameSingularPascalCase;
		private string columnNameSqlMetalCamelCase;
		private string columnNameSqlMetalPascalCase;
		private string columnNameSqlMetalPluralCamelCase;
		private string columnNameSqlMetalPluralPascalCase;
		private string columnNameSqlMetalSingularCamelCase;
		private string columnNameSqlMetalSingularPascalCase;
		private bool columnNullable;
		private int columnOrdinal;
		private int columnPrecision;
		private int columnScale;
		private int columnSize;
		private Type columnSqlMetalClrNonNullableType;
		private Type columnSqlMetalClrNullableType;
		private Type columnSqlMetalClrType;
		private string columnSqlMetalCSharpClrNonNullableType;
		private string columnSqlMetalCSharpClrNullableType;
		private string columnSqlMetalCSharpClrType;
		private string columnSqlType;

		#endregion

		#region Properties/Indexers/Events

		[XmlAttribute("ColumnClrNonNullableType")]
		public string _ColumnClrNotNullableType
		{
			get
			{
				return this.ColumnClrNonNullableType.SafeToString();
			}
			set
			{
				if (DataTypeFascade.Instance.IsNullOrWhiteSpace(value))
					this.ColumnClrNonNullableType = null;
				else
					this.ColumnClrNonNullableType = Type.GetType(value, false);
			}
		}

		[XmlAttribute("ColumnClrNullableType")]
		public string _ColumnClrNullableType
		{
			get
			{
				return this.ColumnClrNullableType.SafeToString();
			}
			set
			{
				if (DataTypeFascade.Instance.IsNullOrWhiteSpace(value))
					this.ColumnClrNullableType = null;
				else
					this.ColumnClrNullableType = Type.GetType(value, false);
			}
		}

		[XmlAttribute("ColumnClrType")]
		public string _ColumnClrType
		{
			get
			{
				return this.ColumnClrType.SafeToString();
			}
			set
			{
				if (DataTypeFascade.Instance.IsNullOrWhiteSpace(value))
					this.ColumnClrType = null;
				else
					this.ColumnClrType = Type.GetType(value, false);
			}
		}

		[XmlIgnore]
		public Type ColumnClrNonNullableType
		{
			get
			{
				return this.columnClrNonNullableType;
			}
			set
			{
				this.columnClrNonNullableType = value;
			}
		}

		[XmlIgnore]
		public Type ColumnClrNullableType
		{
			get
			{
				return this.columnClrNullableType;
			}
			set
			{
				this.columnClrNullableType = value;
			}
		}

		[XmlIgnore]
		public Type ColumnClrType
		{
			get
			{
				return this.columnClrType;
			}
			set
			{
				this.columnClrType = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpClrNonNullableType
		{
			get
			{
				return this.columnCSharpClrNonNullableType;
			}
			set
			{
				this.columnCSharpClrNonNullableType = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpClrNullableType
		{
			get
			{
				return this.columnCSharpClrNullableType;
			}
			set
			{
				this.columnCSharpClrNullableType = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpClrType
		{
			get
			{
				return this.columnCSharpClrType;
			}
			set
			{
				this.columnCSharpClrType = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpDbType
		{
			get
			{
				return this.columnCSharpDbType;
			}
			set
			{
				this.columnCSharpDbType = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpIsAnonymousLiteral
		{
			get
			{
				return this.columnCSharpIsAnonymousLiteral;
			}
			set
			{
				this.columnCSharpIsAnonymousLiteral = value;
			}
		}

		[XmlAttribute]
		public string ColumnCSharpNullableLiteral
		{
			get
			{
				return this.columnCSharpNullableLiteral;
			}
			set
			{
				this.columnCSharpNullableLiteral = value;
			}
		}

		[XmlAttribute]
		public DbType ColumnDbType
		{
			get
			{
				return this.columnDbType;
			}
			set
			{
				this.columnDbType = value;
			}
		}

		[XmlAttribute]
		public bool ColumnIsAnonymous
		{
			get
			{
				return this.columnIsAnonymous;
			}
			set
			{
				this.columnIsAnonymous = value;
			}
		}

		[XmlAttribute]
		public bool ColumnIsUserDefinedType
		{
			get
			{
				return this.columnIsUserDefinedType;
			}
			set
			{
				this.columnIsUserDefinedType = value;
			}
		}

		[XmlAttribute]
		public string ColumnName
		{
			get
			{
				return this.columnName;
			}
			set
			{
				if (this.ColumnIsAnonymous = DataTypeFascade.Instance.IsNullOrEmpty(value))
					this.columnName = string.Format("Column_{0:0000}", this.ColumnOrdinal);
				else
					this.columnName = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameCamelCase
		{
			get
			{
				return this.columnNameCamelCase;
			}
			set
			{
				this.columnNameCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameConstantCase
		{
			get
			{
				return this.columnNameConstantCase;
			}
			set
			{
				this.columnNameConstantCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNamePascalCase
		{
			get
			{
				return this.columnNamePascalCase;
			}
			set
			{
				this.columnNamePascalCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNamePluralCamelCase
		{
			get
			{
				return this.columnNamePluralCamelCase;
			}
			set
			{
				this.columnNamePluralCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNamePluralConstantCase
		{
			get
			{
				return this.columnNamePluralConstantCase;
			}
			set
			{
				this.columnNamePluralConstantCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNamePluralPascalCase
		{
			get
			{
				return this.columnNamePluralPascalCase;
			}
			set
			{
				this.columnNamePluralPascalCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSingularCamelCase
		{
			get
			{
				return this.columnNameSingularCamelCase;
			}
			set
			{
				this.columnNameSingularCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSingularConstantCase
		{
			get
			{
				return this.columnNameSingularConstantCase;
			}
			set
			{
				this.columnNameSingularConstantCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSingularPascalCase
		{
			get
			{
				return this.columnNameSingularPascalCase;
			}
			set
			{
				this.columnNameSingularPascalCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalCamelCase
		{
			get
			{
				return this.columnNameSqlMetalCamelCase;
			}
			set
			{
				this.columnNameSqlMetalCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalPascalCase
		{
			get
			{
				return this.columnNameSqlMetalPascalCase;
			}
			set
			{
				this.columnNameSqlMetalPascalCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalPluralCamelCase
		{
			get
			{
				return this.columnNameSqlMetalPluralCamelCase;
			}
			set
			{
				this.columnNameSqlMetalPluralCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalPluralPascalCase
		{
			get
			{
				return this.columnNameSqlMetalPluralPascalCase;
			}
			set
			{
				this.columnNameSqlMetalPluralPascalCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalSingularCamelCase
		{
			get
			{
				return this.columnNameSqlMetalSingularCamelCase;
			}
			set
			{
				this.columnNameSqlMetalSingularCamelCase = value;
			}
		}

		[XmlAttribute]
		public string ColumnNameSqlMetalSingularPascalCase
		{
			get
			{
				return this.columnNameSqlMetalSingularPascalCase;
			}
			set
			{
				this.columnNameSqlMetalSingularPascalCase = value;
			}
		}

		[XmlAttribute]
		public bool ColumnNullable
		{
			get
			{
				return this.columnNullable;
			}
			set
			{
				this.columnNullable = value;
			}
		}

		[XmlAttribute]
		public int ColumnOrdinal
		{
			get
			{
				return this.columnOrdinal;
			}
			set
			{
				this.columnOrdinal = value;
			}
		}

		[XmlAttribute]
		public int ColumnPrecision
		{
			get
			{
				return this.columnPrecision;
			}
			set
			{
				this.columnPrecision = value;
			}
		}

		[XmlAttribute]
		public int ColumnScale
		{
			get
			{
				return this.columnScale;
			}
			set
			{
				this.columnScale = value;
			}
		}

		[XmlAttribute]
		public int ColumnSize
		{
			get
			{
				return this.columnSize;
			}
			set
			{
				this.columnSize = value;
			}
		}

		[XmlIgnore]
		public Type ColumnSqlMetalClrNonNullableType
		{
			get
			{
				return this.columnSqlMetalClrNonNullableType;
			}
			set
			{
				this.columnSqlMetalClrNonNullableType = value;
			}
		}

		[XmlIgnore]
		public Type ColumnSqlMetalClrNullableType
		{
			get
			{
				return this.columnSqlMetalClrNullableType;
			}
			set
			{
				this.columnSqlMetalClrNullableType = value;
			}
		}

		[XmlIgnore]
		public Type ColumnSqlMetalClrType
		{
			get
			{
				return this.columnSqlMetalClrType;
			}
			set
			{
				this.columnSqlMetalClrType = value;
			}
		}

		[XmlAttribute]
		public string ColumnSqlMetalCSharpClrNonNullableType
		{
			get
			{
				return this.columnSqlMetalCSharpClrNonNullableType;
			}
			set
			{
				this.columnSqlMetalCSharpClrNonNullableType = value;
			}
		}

		[XmlAttribute]
		public string ColumnSqlMetalCSharpClrNullableType
		{
			get
			{
				return this.columnSqlMetalCSharpClrNullableType;
			}
			set
			{
				this.columnSqlMetalCSharpClrNullableType = value;
			}
		}

		[XmlAttribute]
		public string ColumnSqlMetalCSharpClrType
		{
			get
			{
				return this.columnSqlMetalCSharpClrType;
			}
			set
			{
				this.columnSqlMetalCSharpClrType = value;
			}
		}

		[XmlAttribute]
		public string ColumnSqlType
		{
			get
			{
				return this.columnSqlType;
			}
			set
			{
				this.columnSqlType = value;
			}
		}

		#endregion
	}
}