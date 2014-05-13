﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 6.0.0.29228;
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
using System.Xml;

using TextMetal.Common.Core;
using TextMetal.Common.Data;
using TextMetal.Common.Data.Framework;
using TextMetal.Common.Expressions;

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Tables
{
	public partial class TabWithPrimaryKeyAsDefault : Object, ITabWithPrimaryKeyAsDefault
	{		
		#region Constructors/Destructors
		
		public TabWithPrimaryKeyAsDefault()
		{
		}
		
		#endregion
		
		#region Fields/Constants
		
		public const string SCHEMA_NAME = "testcases";
		public const string TABLE_NAME = "tab_with_primary_key_as_default";
		public const bool HAS_SINGLE_COLUMN_SERVER_GENERATED_PRIMARY_KEY = false;
		public const string COLUMN_NAME_COLUUIDDFPK = "col_uuid_df_pk";
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

		private bool isNew = true;
		private Nullable<Guid> @colUuidDfPk;
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
		
		public virtual bool IsNew
		{
			get
			{
				return this.isNew;
			}
			set
			{
				this.isNew = value;
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Guid> @ColUuidDfPk
		{
			get
			{
				return this.@colUuidDfPk;
			}
			set
			{
				this.@colUuidDfPk = value;
			}
		}
		
		public Nullable<Int64> @ColBigint
		{
			get
			{
				return this.@colBigint;
			}
			set
			{
				this.@colBigint = value;
			}
		}
		
		public Byte[] @ColBinary
		{
			get
			{
				return this.@colBinary;
			}
			set
			{
				this.@colBinary = value;
			}
		}
		
		public Nullable<Boolean> @ColBit
		{
			get
			{
				return this.@colBit;
			}
			set
			{
				this.@colBit = value;
			}
		}
		
		public String @ColChar
		{
			get
			{
				return this.@colChar;
			}
			set
			{
				this.@colChar = value;
			}
		}
		
		public Nullable<DateTime> @ColDate
		{
			get
			{
				return this.@colDate;
			}
			set
			{
				this.@colDate = value;
			}
		}
		
		public Nullable<DateTime> @ColDatetime
		{
			get
			{
				return this.@colDatetime;
			}
			set
			{
				this.@colDatetime = value;
			}
		}
		
		public Nullable<DateTime> @ColDatetime2
		{
			get
			{
				return this.@colDatetime2;
			}
			set
			{
				this.@colDatetime2 = value;
			}
		}
		
		public Nullable<DateTimeOffset> @ColDatetimeoffset
		{
			get
			{
				return this.@colDatetimeoffset;
			}
			set
			{
				this.@colDatetimeoffset = value;
			}
		}
		
		public Nullable<Decimal> @ColDecimal
		{
			get
			{
				return this.@colDecimal;
			}
			set
			{
				this.@colDecimal = value;
			}
		}
		
		public Nullable<Double> @ColFloat
		{
			get
			{
				return this.@colFloat;
			}
			set
			{
				this.@colFloat = value;
			}
		}
		
		public Byte[] @ColImage
		{
			get
			{
				return this.@colImage;
			}
			set
			{
				this.@colImage = value;
			}
		}
		
		public Nullable<Int32> @ColInt
		{
			get
			{
				return this.@colInt;
			}
			set
			{
				this.@colInt = value;
			}
		}
		
		public Nullable<Decimal> @ColMoney
		{
			get
			{
				return this.@colMoney;
			}
			set
			{
				this.@colMoney = value;
			}
		}
		
		public String @ColNchar
		{
			get
			{
				return this.@colNchar;
			}
			set
			{
				this.@colNchar = value;
			}
		}
		
		public String @ColNtext
		{
			get
			{
				return this.@colNtext;
			}
			set
			{
				this.@colNtext = value;
			}
		}
		
		public Nullable<Decimal> @ColNumeric
		{
			get
			{
				return this.@colNumeric;
			}
			set
			{
				this.@colNumeric = value;
			}
		}
		
		public String @ColNvarchar
		{
			get
			{
				return this.@colNvarchar;
			}
			set
			{
				this.@colNvarchar = value;
			}
		}
		
		public Nullable<Single> @ColReal
		{
			get
			{
				return this.@colReal;
			}
			set
			{
				this.@colReal = value;
			}
		}
		
		public Byte[] @ColRowversion
		{
			get
			{
				return this.@colRowversion;
			}
			set
			{
				this.@colRowversion = value;
			}
		}
		
		public Nullable<DateTime> @ColSmalldatetime
		{
			get
			{
				return this.@colSmalldatetime;
			}
			set
			{
				this.@colSmalldatetime = value;
			}
		}
		
		public Nullable<Int16> @ColSmallint
		{
			get
			{
				return this.@colSmallint;
			}
			set
			{
				this.@colSmallint = value;
			}
		}
		
		public Nullable<Decimal> @ColSmallmoney
		{
			get
			{
				return this.@colSmallmoney;
			}
			set
			{
				this.@colSmallmoney = value;
			}
		}
		
		public Object @ColSqlVariant
		{
			get
			{
				return this.@colSqlVariant;
			}
			set
			{
				this.@colSqlVariant = value;
			}
		}
		
		public String @ColSysname
		{
			get
			{
				return this.@colSysname;
			}
			set
			{
				this.@colSysname = value;
			}
		}
		
		public String @ColText
		{
			get
			{
				return this.@colText;
			}
			set
			{
				this.@colText = value;
			}
		}
		
		public Nullable<TimeSpan> @ColTime
		{
			get
			{
				return this.@colTime;
			}
			set
			{
				this.@colTime = value;
			}
		}
		
		public Nullable<Byte> @ColTinyint
		{
			get
			{
				return this.@colTinyint;
			}
			set
			{
				this.@colTinyint = value;
			}
		}
		
		public Nullable<Guid> @ColUniqueidentifier
		{
			get
			{
				return this.@colUniqueidentifier;
			}
			set
			{
				this.@colUniqueidentifier = value;
			}
		}
		
		public Byte[] @ColVarbinary
		{
			get
			{
				return this.@colVarbinary;
			}
			set
			{
				this.@colVarbinary = value;
			}
		}
		
		public String @ColVarchar
		{
			get
			{
				return this.@colVarchar;
			}
			set
			{
				this.@colVarchar = value;
			}
		}
		
		public XmlDocument @ColXml
		{
			get
			{
				return this.@colXml;
			}
			set
			{
				this.@colXml = value;
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
		
		#endregion
	}
}
