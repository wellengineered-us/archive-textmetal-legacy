﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using Newtonsoft.Json;

using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Datazoid.Models.Tabular
{
	/// <summary>
	/// Provides a contract for table model objects (tables, views, etc.).
	/// </summary
	public interface ITableModelObject : IRecordModelObject, IValidate
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// Gets the ordinal sorted array values identifying the current table model object instance.
		/// </summary>
		[JsonIgnore]
		object[] IdValues
		{
			get;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the current table model object instance
		/// is new (never been persisted) or old (has been persisted).
		/// </summary>
		[JsonIgnore]
		bool IsNew
		{
			get;
			set;
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Called prior to any non-nullipotent (e.g. insert, update, delete) operation.
		/// </summary>
		void Mark();

		#endregion
	}
}