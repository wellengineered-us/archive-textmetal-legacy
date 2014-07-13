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

namespace TextMetal.HostImpl.AspNetSample.DomainModel.Tables
{
	public partial interface ITabWithPrimaryKeyNoIdentity : IModelObject
	{		
		#region Properties/Indexers/Events

		/* PRIMARY_KEY */
		Nullable<Int32> @ColIntPk
		{
			get;
			set;
		}
		
		Nullable<Int64> @ColBigint
		{
			get;
			set;
		}
		
		Byte[] @ColBinary
		{
			get;
			set;
		}
		
		Nullable<Boolean> @ColBit
		{
			get;
			set;
		}
		
		String @ColChar
		{
			get;
			set;
		}
		
		Nullable<DateTime> @ColDate
		{
			get;
			set;
		}
		
		Nullable<DateTime> @ColDatetime
		{
			get;
			set;
		}
		
		Nullable<DateTime> @ColDatetime2
		{
			get;
			set;
		}
		
		Nullable<DateTimeOffset> @ColDatetimeoffset
		{
			get;
			set;
		}
		
		Nullable<Decimal> @ColDecimal
		{
			get;
			set;
		}
		
		Nullable<Double> @ColFloat
		{
			get;
			set;
		}
		
		Byte[] @ColImage
		{
			get;
			set;
		}
		
		Nullable<Int32> @ColInt
		{
			get;
			set;
		}
		
		Nullable<Decimal> @ColMoney
		{
			get;
			set;
		}
		
		String @ColNchar
		{
			get;
			set;
		}
		
		String @ColNtext
		{
			get;
			set;
		}
		
		Nullable<Decimal> @ColNumeric
		{
			get;
			set;
		}
		
		String @ColNvarchar
		{
			get;
			set;
		}
		
		Nullable<Single> @ColReal
		{
			get;
			set;
		}
		
		Byte[] @ColRowversion
		{
			get;
			set;
		}
		
		Nullable<DateTime> @ColSmalldatetime
		{
			get;
			set;
		}
		
		Nullable<Int16> @ColSmallint
		{
			get;
			set;
		}
		
		Nullable<Decimal> @ColSmallmoney
		{
			get;
			set;
		}
		
		Object @ColSqlVariant
		{
			get;
			set;
		}
		
		String @ColSysname
		{
			get;
			set;
		}
		
		String @ColText
		{
			get;
			set;
		}
		
		Nullable<TimeSpan> @ColTime
		{
			get;
			set;
		}
		
		Nullable<Byte> @ColTinyint
		{
			get;
			set;
		}
		
		Nullable<Guid> @ColUniqueidentifier
		{
			get;
			set;
		}
		
		Byte[] @ColVarbinary
		{
			get;
			set;
		}
		
		String @ColVarchar
		{
			get;
			set;
		}
		
		XmlDocument @ColXml
		{
			get;
			set;
		}
		
		#endregion
	}
}
