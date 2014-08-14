﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 6.0.0.37114;
// 		Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

using TextMetal.Common.Core;
using TextMetal.Common.Data;
using TextMetal.Common.Data.Framework;
using TextMetal.Common.Syntax.Expressions;
using TextMetal.Common.Syntax.Operators;
using TextMetal.Common.Syntax.Statements;

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Tables
{
	public partial class TabWithNoPrimaryKeyWithIdentity : Object, INotifyPropertyChanged, ITabWithNoPrimaryKeyWithIdentity
	{
		#region Constructors/Destructors

		public TabWithNoPrimaryKeyWithIdentity()
		{
		}

		#endregion

		#region Fields/Constants

		public const string SCHEMA_NAME = "testcases";
		public const string TABLE_NAME = "tab_with_no_primary_key_with_identity";
		public const bool HAS_SINGLE_COLUMN_SERVER_GENERATED_PRIMARY_KEY = true;
		public const string COLUMN_NAME_COLINTID = "col_int_id";
		public const string COLUMN_NAME_COLBIGINT = "col_bigint";
		public const string COLUMN_NAME_COLBINARY = "col_binary";
		public const string COLUMN_NAME_COLBIT = "col_bit";
		public const string COLUMN_NAME_COLCHAR = "col_char";
		public const string COLUMN_NAME_COLDATE = "col_date";
		public const string COLUMN_NAME_COLDATETIME = "col_datetime";
		public const string COLUMN_NAME_COLDATETIME2 = "col_datetime2";
		public const string COLUMN_NAME_COLDATETIMEOFFSET = "col_datetimeoffset";
		public const string COLUMN_NAME_COLDECIMAL = "col_decimal";
		public const string COLUMN_NAME_COLFLOAT = "col_float";
		public const string COLUMN_NAME_COLIMAGE = "col_image";
		public const string COLUMN_NAME_COLINT = "col_int";
		public const string COLUMN_NAME_COLMONEY = "col_money";
		public const string COLUMN_NAME_COLNCHAR = "col_nchar";
		public const string COLUMN_NAME_COLNTEXT = "col_ntext";
		public const string COLUMN_NAME_COLNUMERIC = "col_numeric";
		public const string COLUMN_NAME_COLNVARCHAR = "col_nvarchar";
		public const string COLUMN_NAME_COLREAL = "col_real";
		public const string COLUMN_NAME_COLROWVERSION = "col_rowversion";
		public const string COLUMN_NAME_COLSMALLDATETIME = "col_smalldatetime";
		public const string COLUMN_NAME_COLSMALLINT = "col_smallint";
		public const string COLUMN_NAME_COLSMALLMONEY = "col_smallmoney";
		public const string COLUMN_NAME_COLSQLVARIANT = "col_sql_variant";
		public const string COLUMN_NAME_COLSYSNAME = "col_sysname";
		public const string COLUMN_NAME_COLTEXT = "col_text";
		public const string COLUMN_NAME_COLTIME = "col_time";
		public const string COLUMN_NAME_COLTINYINT = "col_tinyint";
		public const string COLUMN_NAME_COLUNIQUEIDENTIFIER = "col_uniqueidentifier";
		public const string COLUMN_NAME_COLVARBINARY = "col_varbinary";
		public const string COLUMN_NAME_COLVARCHAR = "col_varchar";
		public const string COLUMN_NAME_COLXML = "col_xml";

		private Nullable<Int32> @colIntId;
		private Nullable<Int64> @colBigint;
		private Byte[] @colBinary;
		private Nullable<Boolean> @colBit;
		private String @colChar;
		private Nullable<DateTime> @colDate;
		private Nullable<DateTime> @colDatetime;
		private Nullable<DateTime> @colDatetime2;
		private Nullable<DateTimeOffset> @colDatetimeoffset;
		private Nullable<Decimal> @colDecimal;
		private Nullable<Double> @colFloat;
		private Byte[] @colImage;
		private Nullable<Int32> @colInt;
		private Nullable<Decimal> @colMoney;
		private String @colNchar;
		private String @colNtext;
		private Nullable<Decimal> @colNumeric;
		private String @colNvarchar;
		private Nullable<Single> @colReal;
		private Byte[] @colRowversion;
		private Nullable<DateTime> @colSmalldatetime;
		private Nullable<Int16> @colSmallint;
		private Nullable<Decimal> @colSmallmoney;
		private Object @colSqlVariant;
		private String @colSysname;
		private String @colText;
		private Nullable<TimeSpan> @colTime;
		private Nullable<Byte> @colTinyint;
		private Nullable<Guid> @colUniqueidentifier;
		private Byte[] @colVarbinary;
		private String @colVarchar;
		private XmlDocument @colXml;

		#endregion

		#region Properties/Indexers/Events

		public event PropertyChangedEventHandler PropertyChanged;

		public virtual bool IsNew
		{
			get
			{
				return this.@ColIntId == default(Nullable<Int32>);
			}
			set
			{
				if(value)
					this.@ColIntId =  default(Nullable<Int32>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @ColIntId
		{
			get
			{
				return this.@colIntId;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colIntId, value))
				{
					this.@colIntId = value;
					OnPropertyChanged("ColIntId");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int64> @ColBigint
		{
			get
			{
				return this.@colBigint;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colBigint, value))
				{
					this.@colBigint = value;
					OnPropertyChanged("ColBigint");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Byte[] @ColBinary
		{
			get
			{
				return this.@colBinary;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colBinary, value))
				{
					this.@colBinary = value;
					OnPropertyChanged("ColBinary");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Boolean> @ColBit
		{
			get
			{
				return this.@colBit;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colBit, value))
				{
					this.@colBit = value;
					OnPropertyChanged("ColBit");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColChar
		{
			get
			{
				return this.@colChar;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colChar, value))
				{
					this.@colChar = value;
					OnPropertyChanged("ColChar");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @ColDate
		{
			get
			{
				return this.@colDate;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colDate, value))
				{
					this.@colDate = value;
					OnPropertyChanged("ColDate");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @ColDatetime
		{
			get
			{
				return this.@colDatetime;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colDatetime, value))
				{
					this.@colDatetime = value;
					OnPropertyChanged("ColDatetime");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @ColDatetime2
		{
			get
			{
				return this.@colDatetime2;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colDatetime2, value))
				{
					this.@colDatetime2 = value;
					OnPropertyChanged("ColDatetime2");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTimeOffset> @ColDatetimeoffset
		{
			get
			{
				return this.@colDatetimeoffset;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colDatetimeoffset, value))
				{
					this.@colDatetimeoffset = value;
					OnPropertyChanged("ColDatetimeoffset");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Decimal> @ColDecimal
		{
			get
			{
				return this.@colDecimal;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colDecimal, value))
				{
					this.@colDecimal = value;
					OnPropertyChanged("ColDecimal");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Double> @ColFloat
		{
			get
			{
				return this.@colFloat;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colFloat, value))
				{
					this.@colFloat = value;
					OnPropertyChanged("ColFloat");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Byte[] @ColImage
		{
			get
			{
				return this.@colImage;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colImage, value))
				{
					this.@colImage = value;
					OnPropertyChanged("ColImage");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @ColInt
		{
			get
			{
				return this.@colInt;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colInt, value))
				{
					this.@colInt = value;
					OnPropertyChanged("ColInt");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Decimal> @ColMoney
		{
			get
			{
				return this.@colMoney;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colMoney, value))
				{
					this.@colMoney = value;
					OnPropertyChanged("ColMoney");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColNchar
		{
			get
			{
				return this.@colNchar;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colNchar, value))
				{
					this.@colNchar = value;
					OnPropertyChanged("ColNchar");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColNtext
		{
			get
			{
				return this.@colNtext;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colNtext, value))
				{
					this.@colNtext = value;
					OnPropertyChanged("ColNtext");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Decimal> @ColNumeric
		{
			get
			{
				return this.@colNumeric;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colNumeric, value))
				{
					this.@colNumeric = value;
					OnPropertyChanged("ColNumeric");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColNvarchar
		{
			get
			{
				return this.@colNvarchar;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colNvarchar, value))
				{
					this.@colNvarchar = value;
					OnPropertyChanged("ColNvarchar");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Single> @ColReal
		{
			get
			{
				return this.@colReal;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colReal, value))
				{
					this.@colReal = value;
					OnPropertyChanged("ColReal");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Byte[] @ColRowversion
		{
			get
			{
				return this.@colRowversion;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colRowversion, value))
				{
					this.@colRowversion = value;
					OnPropertyChanged("ColRowversion");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<DateTime> @ColSmalldatetime
		{
			get
			{
				return this.@colSmalldatetime;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colSmalldatetime, value))
				{
					this.@colSmalldatetime = value;
					OnPropertyChanged("ColSmalldatetime");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int16> @ColSmallint
		{
			get
			{
				return this.@colSmallint;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colSmallint, value))
				{
					this.@colSmallint = value;
					OnPropertyChanged("ColSmallint");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Decimal> @ColSmallmoney
		{
			get
			{
				return this.@colSmallmoney;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colSmallmoney, value))
				{
					this.@colSmallmoney = value;
					OnPropertyChanged("ColSmallmoney");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Object @ColSqlVariant
		{
			get
			{
				return this.@colSqlVariant;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colSqlVariant, value))
				{
					this.@colSqlVariant = value;
					OnPropertyChanged("ColSqlVariant");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColSysname
		{
			get
			{
				return this.@colSysname;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colSysname, value))
				{
					this.@colSysname = value;
					OnPropertyChanged("ColSysname");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColText
		{
			get
			{
				return this.@colText;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colText, value))
				{
					this.@colText = value;
					OnPropertyChanged("ColText");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<TimeSpan> @ColTime
		{
			get
			{
				return this.@colTime;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colTime, value))
				{
					this.@colTime = value;
					OnPropertyChanged("ColTime");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Byte> @ColTinyint
		{
			get
			{
				return this.@colTinyint;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colTinyint, value))
				{
					this.@colTinyint = value;
					OnPropertyChanged("ColTinyint");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Guid> @ColUniqueidentifier
		{
			get
			{
				return this.@colUniqueidentifier;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colUniqueidentifier, value))
				{
					this.@colUniqueidentifier = value;
					OnPropertyChanged("ColUniqueidentifier");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public Byte[] @ColVarbinary
		{
			get
			{
				return this.@colVarbinary;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colVarbinary, value))
				{
					this.@colVarbinary = value;
					OnPropertyChanged("ColVarbinary");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public String @ColVarchar
		{
			get
			{
				return this.@colVarchar;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colVarchar, value))
				{
					this.@colVarchar = value;
					OnPropertyChanged("ColVarchar");
				}
			}
		}
		
		/* PRIMARY_KEY */
		public XmlDocument @ColXml
		{
			get
			{
				return this.@colXml;
			}
			set
			{
				if (!DataType.ObjectsEqualValueSemantics(this.@colXml, value))
				{
					this.@colXml = value;
					OnPropertyChanged("ColXml");
				}
			}
		}
		
		#endregion

		#region Methods/Operators

		partial void OnMark();

		partial void OnValidate(ref IEnumerable<Message> messages);

		public virtual void Mark()
		{
			this.OnMark();
		}

		public virtual IEnumerable<Message> Validate()
		{
			IEnumerable<Message> messages = null;

			this.OnValidate(ref messages);

			return messages ?? new Message[] { };
		}

		protected void OnAllPropertiesChanged()
        {
			this.OnPropertyChanged(null);
		}

		protected void OnPropertyChanged(string propertyName)
        {
			if ((object)this.PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

		#endregion
	}
}
