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
	public partial interface ITabWithNoPrimaryKeyWithIdentity : IModelObject
	{		
		#region Properties/Indexers/Events

		/* PRIMARY_KEY */
		Nullable<Int32> @ColIntId
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Int64> @ColBigint
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Byte[] @ColBinary
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Boolean> @ColBit
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColChar
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<DateTime> @ColDate
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<DateTime> @ColDatetime
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<DateTime> @ColDatetime2
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<DateTimeOffset> @ColDatetimeoffset
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Decimal> @ColDecimal
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Double> @ColFloat
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Byte[] @ColImage
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Int32> @ColInt
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Decimal> @ColMoney
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColNchar
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColNtext
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Decimal> @ColNumeric
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColNvarchar
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Single> @ColReal
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Byte[] @ColRowversion
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<DateTime> @ColSmalldatetime
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Int16> @ColSmallint
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Decimal> @ColSmallmoney
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Object @ColSqlVariant
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColSysname
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColText
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<TimeSpan> @ColTime
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Byte> @ColTinyint
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Nullable<Guid> @ColUniqueidentifier
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		Byte[] @ColVarbinary
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		String @ColVarchar
		{
			get;
			set;
		}
		
		/* PRIMARY_KEY */
		XmlDocument @ColXml
		{
			get;
			set;
		}
		
		#endregion
	}
}