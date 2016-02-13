﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;

using TextMetal.Middleware.Datazoid.UoW;
using TextMetal.Middleware.Solder.Utilities;

namespace TextMetal.Middleware.Datazoid.Repositories.Impl.Migrations
{
	/// <summary>
	/// Represents an ordered set of historical revsions to a database (file).
	/// </summary>
	[XmlRoot(ElementName = "History", Namespace = "http://www.leastviable.com/api/v7.0.0")]
	public sealed class DatabaseHistory
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the DatabaseHistory class.
		/// </summary>
		public DatabaseHistory()
		{
		}

		#endregion

		#region Fields/Constants

		private readonly List<DatabaseRevision> revisions = new List<DatabaseRevision>();
		private string doesSchemaTrackingExistCommandText;
		private string getSchemaVersionCommandText;
		private string incrementSchemaVersionCommandText;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets a list of ordered revisions.
		/// </summary>
		[XmlArray(ElementName = "Revisions", Order = 3)]
		[XmlArrayItem(ElementName = "Revision")]
		public List<DatabaseRevision> Revisions
		{
			get
			{
				return this.revisions;
			}
		}

		/// <summary>
		/// Gets or sets the SQL required to determine if schema tracking is enabled in the database (file).
		/// </summary>
		[XmlElement("DoesSchemaTrackingExistCommandText", Order = 0)]
		public string DoesSchemaTrackingExistCommandText
		{
			get
			{
				return (this.doesSchemaTrackingExistCommandText ?? string.Empty).Trim();
			}
			set
			{
				this.doesSchemaTrackingExistCommandText = (value ?? string.Empty).Trim();
			}
		}

		/// <summary>
		/// Gets or sets the SQL required to determine the schema version of the database (file).
		/// </summary>
		[XmlElement("GetSchemaVersionCommandText", Order = 1)]
		public string GetSchemaVersionCommandText
		{
			get
			{
				return (this.getSchemaVersionCommandText ?? string.Empty).Trim();
			}
			set
			{
				this.getSchemaVersionCommandText = (value ?? string.Empty).Trim();
			}
		}

		/// <summary>
		/// Gets or sets the SQL required to increment the schema version in the database (file).
		/// </summary>
		[XmlElement("IncrementSchemaVersionCommandText", Order = 2)]
		public string IncrementSchemaVersionCommandText
		{
			get
			{
				return (this.incrementSchemaVersionCommandText ?? string.Empty).Trim();
			}
			set
			{
				this.incrementSchemaVersionCommandText = (value ?? string.Empty).Trim();
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// For a given unitOfWork, perform a schema upgrade if necessary. The ordered set of revisions are executed from version+1 to version[n].
		/// </summary>
		/// <param name="unitOfWork"> The target unitOfWork. </param>
		/// <returns> A value indicating whether any changes were needed against the target database (file). </returns>
		public bool PerformSchemaUpgrade(IUnitOfWork unitOfWork)
		{
			bool changed = false;
			DatabaseRevision revision;
			string svalue;
			int ivalue;
			int schemaRevision, currentSchemaRevision;

			if ((object)unitOfWork == null)
				throw new ArgumentNullException(nameof(unitOfWork));

			if (this.Revisions.Count < 1)
				throw new InvalidOperationException(string.Format("Revision count was less than one."));

			ivalue = unitOfWork.ExecuteScalar<int>(CommandType.Text, this.DoesSchemaTrackingExistCommandText, null);

			if (ivalue != 1)
			{
				// revision -1
				schemaRevision = -1;
			}
			else
			{
				svalue = unitOfWork.ExecuteScalar<string>(CommandType.Text, this.GetSchemaVersionCommandText, null);

				if (!DataTypeFascade.Instance.TryParse(svalue, out schemaRevision))
					throw new InvalidOperationException(string.Format("The schema revision scalar value returned from the database '{0}' could not be parsed into a valid '{1}'.", svalue, typeof(int)));
			}

			currentSchemaRevision = this.Revisions.Max(x => x.Number);

			if (schemaRevision != currentSchemaRevision)
			{
				changed = true;

				for (int workingRevision = schemaRevision + 1; workingRevision <= currentSchemaRevision; workingRevision++)
				{
					int _workingRevision = workingRevision;

					revision = this.Revisions.SingleOrDefault(rh => rh.Number == _workingRevision);

					if ((object)revision == null)
						throw new InvalidOperationException(String.Format("The revision number '{0}' was not found. Revsions must be sequential without any gaps.", _workingRevision));

					if (revision.Statements.Count < 1)
						throw new InvalidOperationException("A revsion must have at least one statement.");

					foreach (string statement in revision.Statements)
						unitOfWork.ExecuteRecords(CommandType.Text, statement, null, null).ToList();

					unitOfWork.ExecuteRecords(CommandType.Text, this.IncrementSchemaVersionCommandText, null, null).ToList();
				}
			}

			ivalue = unitOfWork.ExecuteScalar<int>(CommandType.Text, this.DoesSchemaTrackingExistCommandText, null);

			if (ivalue != 1)
				throw new InvalidOperationException(string.Format("Schema tracking is not enabled in the database."));

			svalue = unitOfWork.ExecuteScalar<string>(CommandType.Text, this.GetSchemaVersionCommandText, null);

			if (!DataTypeFascade.Instance.TryParse(svalue, out schemaRevision))
				throw new InvalidOperationException(string.Format("The schema revision scalar value returned from the database '{0}' could not be parsed into a valid '{1}'.", svalue, typeof(int)));

			if (schemaRevision != currentSchemaRevision)
				throw new InvalidOperationException(string.Format("The schema revison '{0}' does not equal the CURRENT schema revison '{1}.", schemaRevision, currentSchemaRevision));

			return changed;
		}

		#endregion
	}
}