/*
	Copyright �2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Data;

using TextMetal.Middleware.Datazoid.UoW;
using TextMetal.Middleware.Solder.Extensions;
using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Oxymoron.Legacy.Config.Adapters
{
	public class AdoNetAdapterConfiguration : AdapterSpecificConfiguration
	{
		#region Constructors/Destructors

		public AdoNetAdapterConfiguration()
		{
		}

		#endregion

		#region Fields/Constants

		private string connectionAqtn;
		private string connectionString;
		private AdoNetCommandConfiguration executeCommand;
		private AdoNetCommandConfiguration postExecuteCommand;
		private AdoNetCommandConfiguration preExecuteCommand;

		#endregion

		#region Properties/Indexers/Events

		public string ConnectionAqtn
		{
			get
			{
				return this.connectionAqtn;
			}
			set
			{
				this.connectionAqtn = value;
			}
		}

		public string ConnectionString
		{
			get
			{
				return this.connectionString;
			}
			set
			{
				this.connectionString = value;
			}
		}

		public AdoNetCommandConfiguration ExecuteCommand
		{
			get
			{
				return this.executeCommand;
			}
			set
			{
				this.EnsureParentOnPropertySet(this.executeCommand, value);
				this.executeCommand = value;
			}
		}

		public AdoNetCommandConfiguration PostExecuteCommand
		{
			get
			{
				return this.postExecuteCommand;
			}
			set
			{
				this.EnsureParentOnPropertySet(this.postExecuteCommand, value);
				this.postExecuteCommand = value;
			}
		}

		public AdoNetCommandConfiguration PreExecuteCommand
		{
			get
			{
				return this.preExecuteCommand;
			}
			set
			{
				this.EnsureParentOnPropertySet(this.preExecuteCommand, value);
				this.preExecuteCommand = value;
			}
		}

		#endregion

		#region Methods/Operators

		public Type GetConnectionType()
		{
			Type connectionType;

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ConnectionAqtn))
				return null;

			connectionType = Type.GetType(this.ConnectionAqtn, false);

			return connectionType;
		}

		public virtual IUnitOfWork GetUnitOfWork(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
		{
			Type dictionaryConnectionType;

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ConnectionAqtn))
				throw new InvalidOperationException(string.Format("Configuration missing: '{0}'.", "AdoNetAdapterConfiguration.ConnectionAqtn"));

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ConnectionString))
				throw new InvalidOperationException(string.Format("Configuration missing: '{0}'.", "AdoNetAdapterConfiguration.ConnectionString"));

			dictionaryConnectionType = this.GetConnectionType();

			if ((object)dictionaryConnectionType == null)
				throw new InvalidOperationException(string.Format("Connection type failed to load: '{0}'.", this.ConnectionAqtn));

			return UnitOfWork.Create(dictionaryConnectionType, this.ConnectionString, false, isolationLevel);
		}

		public override IEnumerable<Message> Validate(string adapterContext)
		{
			List<Message> messages;
			const string CONTEXT = "Execution";
			const string PRE_CONTEXT = "Pre-Execution";
			const string POST_CONTEXT = "Post-Execution";

			messages = new List<Message>();

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ConnectionAqtn))
				messages.Add(NewError(string.Format("{0} adapter ADO.NET connection AQTN is required.", adapterContext)));

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ConnectionString))
				messages.Add(NewError(string.Format("{0} adapter ADO.NET connection string is required.", adapterContext)));

			if ((object)this.PreExecuteCommand != null)
				messages.AddRange(this.PreExecuteCommand.Validate(PRE_CONTEXT));

			if ((object)this.ExecuteCommand == null)
				messages.Add(NewError(string.Format("{0} adapter ADO.NET execute command is required.", adapterContext)));
			else
				messages.AddRange(this.ExecuteCommand.Validate(CONTEXT));

			if ((object)this.PostExecuteCommand != null)
				messages.AddRange(this.PostExecuteCommand.Validate(POST_CONTEXT));

			return messages;
		}

		#endregion
	}
}