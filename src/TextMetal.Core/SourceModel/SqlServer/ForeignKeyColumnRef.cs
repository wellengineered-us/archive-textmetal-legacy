﻿/*
	Copyright ©2002-2011 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Xml.Serialization;

namespace TextMetal.Core.SourceModel.SqlServer
{
	[Serializable]
	public class ForeignKeyColumnRef
	{
		#region Constructors/Destructors

		public ForeignKeyColumnRef()
		{
		}

		#endregion

		#region Fields/Constants

		private int foreignKeyChildColumnOrdinal;
		private string foreignKeyChildTableName;
		private int foreignKeyColumnOrdinal;
		private int foreignKeyParentColumnOrdinal;

		#endregion

		#region Properties/Indexers/Events

		[XmlAttribute]
		public int ForeignKeyChildColumnOrdinal
		{
			get
			{
				return this.foreignKeyChildColumnOrdinal;
			}
			set
			{
				this.foreignKeyChildColumnOrdinal = value;
			}
		}

		[XmlAttribute]
		public string ForeignKeyChildTableName
		{
			get
			{
				return this.foreignKeyChildTableName;
			}
			set
			{
				this.foreignKeyChildTableName = value;
			}
		}

		[XmlAttribute]
		public int ForeignKeyColumnOrdinal
		{
			get
			{
				return this.foreignKeyColumnOrdinal;
			}
			set
			{
				this.foreignKeyColumnOrdinal = value;
			}
		}

		[XmlAttribute]
		public int ForeignKeyParentColumnOrdinal
		{
			get
			{
				return this.foreignKeyParentColumnOrdinal;
			}
			set
			{
				this.foreignKeyParentColumnOrdinal = value;
			}
		}

		#endregion
	}
}