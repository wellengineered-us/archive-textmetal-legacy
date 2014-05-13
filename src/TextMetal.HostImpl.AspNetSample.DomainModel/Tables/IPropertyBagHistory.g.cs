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
	public partial interface IPropertyBagHistory : IModelObject
	{		
		#region Properties/Indexers/Events

		/* PRIMARY_KEY */
		Nullable<Int64> @PropertyBagHistoryId
		{
			get;
			set;
		}
		
		Nullable<DateTime> @PropertyBagHistoryTs
		{
			get;
			set;
		}
		
		Nullable<Int32> @PropertyBagId
		{
			get;
			set;
		}
		
		String @PropertyKey
		{
			get;
			set;
		}
		
		String @PropertyType
		{
			get;
			set;
		}
		
		String @PropertyValue
		{
			get;
			set;
		}
		
		Nullable<Byte> @SortOrder
		{
			get;
			set;
		}
		
		Nullable<DateTime> @CreationTimestamp
		{
			get;
			set;
		}
		
		Nullable<DateTime> @ModificationTimestamp
		{
			get;
			set;
		}
		
		Nullable<Int32> @CreationUserId
		{
			get;
			set;
		}
		
		Nullable<Int32> @ModificationUserId
		{
			get;
			set;
		}
		
		Nullable<Boolean> @LogicalDelete
		{
			get;
			set;
		}
		
		#endregion
	}
}
