﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.1.0.41861;
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
using System.Xml;

using TextMetal.Common.Core;

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Tables
{
	public partial class TabWithPrimaryKeyNoIdentity : Object
	{		
		#region Constructors/Destructors
		
		public TabWithPrimaryKeyNoIdentity()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private bool isNew = true;
		private Nullable<Int32> @colIntPk;
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
		public Nullable<Int32> @ColIntPk
		{
			get
			{
				return this.@colIntPk;
			}
			set
			{
				this.@colIntPk = value;
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
	}
}