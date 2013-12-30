﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.3.597;
// 		Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Xml;

using TextMetal.Common.Core;

namespace TextMetal.HostImpl.AspNetSample.Objects.Model.Tables
{
	public partial class SexualChocolate : Object
	{		
		#region Constructors/Destructors
		
		public SexualChocolate()
		{
		}
		
		#endregion
		
		#region Fields/Constants

		private Nullable<Int32> @sexualChocolateId;
		private String @em;
		private Byte[] @blob;
		private Nullable<DateTime> @creationTimestamp;
		private Nullable<DateTime> @modificationTimestamp;
		private Nullable<Boolean> @logicalDelete;

		#endregion

		#region Properties/Indexers/Events
		
		public virtual bool IsNew
		{
			get
			{
				return this.SexualChocolateId == default(Nullable<Int32>);
			}
			set
			{
				if(value)
					this.SexualChocolateId =  default(Nullable<Int32>);
			}
		}
		
		/* PRIMARY_KEY */
		public Nullable<Int32> @SexualChocolateId
		{
			get
			{
				return this.@sexualChocolateId;
			}
			set
			{
				this.@sexualChocolateId = value;
			}
		}
		
		public String @Em
		{
			get
			{
				return this.@em;
			}
			set
			{
				this.@em = value;
			}
		}
		
		public Byte[] @Blob
		{
			get
			{
				return this.@blob;
			}
			set
			{
				this.@blob = value;
			}
		}
		
		public Nullable<DateTime> @CreationTimestamp
		{
			get
			{
				return this.@creationTimestamp;
			}
			set
			{
				this.@creationTimestamp = value;
			}
		}
		
		public Nullable<DateTime> @ModificationTimestamp
		{
			get
			{
				return this.@modificationTimestamp;
			}
			set
			{
				this.@modificationTimestamp = value;
			}
		}
		
		public Nullable<Boolean> @LogicalDelete
		{
			get
			{
				return this.@logicalDelete;
			}
			set
			{
				this.@logicalDelete = value;
			}
		}
		
		#endregion
	}
}
