/*
	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.IO;
using System.Reflection;
using System.Web;

using TextMetal.Common.Core;

namespace TextMetal.Common.Data.Framework
{
	public sealed class DatabaseFileManager
	{
		#region Constructors/Destructors

		public DatabaseFileManager(string appSettingsPrefix, INativeDatabaseFileFactory nativeDatabaseFileFactory)
		{
			if ((object)appSettingsPrefix == null)
				throw new ArgumentNullException("appSettingsPrefix");

			if ((object)nativeDatabaseFileFactory == null)
				throw new ArgumentNullException("nativeDatabaseFileFactory");

			if (DataType.IsWhiteSpace(appSettingsPrefix))
				throw new ArgumentOutOfRangeException("appSettingsPrefix");

			this.appSettingsPrefix = appSettingsPrefix;
			this.nativeDatabaseFileFactory = nativeDatabaseFileFactory;
		}

		#endregion

		#region Fields/Constants

		private readonly string appSettingsPrefix;
		private readonly INativeDatabaseFileFactory nativeDatabaseFileFactory;

		#endregion

		#region Properties/Indexers/Events

		private string AppSettingsPrefix
		{
			get
			{
				return this.appSettingsPrefix;
			}
		}

		public string DatabaseDirectoryPath
		{
			get
			{
				return AppConfig.GetAppSetting<string>(string.Format("{0}::DatabaseDirectoryPath", this.AppSettingsPrefix));
			}
		}

		public string DatabaseFileName
		{
			get
			{
				return AppConfig.GetAppSetting<string>(string.Format("{0}::DatabaseFileName", this.AppSettingsPrefix));
			}
		}

		public string DatabaseFilePath
		{
			get
			{
				string value;

				// {0} == GetApplicationUserSpecificDirectoryPath()
				value = Path.Combine(string.Format(this.DatabaseDirectoryPath ?? "", GetApplicationUserSpecificDirectoryPath()), this.DatabaseFileName);

				return value;
			}
		}

		public bool KillDatabaseFile
		{
			get
			{
				bool value;

				if (!AppConfig.HasAppSetting(string.Format("{0}::KillDatabaseFile", this.AppSettingsPrefix)))
					return false;

				value = AppConfig.GetAppSetting<bool>(string.Format("{0}::KillDatabaseFile", this.AppSettingsPrefix));

				return value;
			}
		}

		private INativeDatabaseFileFactory NativeDatabaseFileFactory
		{
			get
			{
				return this.nativeDatabaseFileFactory;
			}
		}

		public bool UseDatabaseFile
		{
			get
			{
				bool value;

				value = AppConfig.GetAppSetting<bool>(string.Format("{0}::UseDatabaseFile", this.AppSettingsPrefix));

				return value;
			}
		}

		#endregion

		#region Methods/Operators

		private static string GetApplicationUserSpecificDirectoryPath()
		{
			Assembly assembly;
			AssemblyInformation assemblyInformation;
			string userSpecificDirectoryPath;

			if (ExecutionPathStorage.IsInHttpContext)
				userSpecificDirectoryPath = Path.GetFullPath(HttpContext.Current.Server.MapPath("~/"));
			else
			{
				assembly = Assembly.GetExecutingAssembly();
				assemblyInformation = new AssemblyInformation(assembly);

				if ((object)assemblyInformation.Company != null &&
					(object)assemblyInformation.Product != null &&
					(object)assemblyInformation.Win32FileVersion != null)
				{
					userSpecificDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
					userSpecificDirectoryPath = Path.Combine(userSpecificDirectoryPath, assemblyInformation.Company);
					userSpecificDirectoryPath = Path.Combine(userSpecificDirectoryPath, assemblyInformation.Product);
					userSpecificDirectoryPath = Path.Combine(userSpecificDirectoryPath, assemblyInformation.Win32FileVersion);
				}
				else
					userSpecificDirectoryPath = Path.GetFullPath(".");
			}

			return userSpecificDirectoryPath;
		}

		private bool EnsureDatabaseFile()
		{
			string databaseFilePath;
			string databaseDirectoryPath;
			bool retval = false;

			databaseFilePath = Path.GetFullPath(this.DatabaseFilePath);
			databaseDirectoryPath = Path.GetDirectoryName(databaseFilePath);

			if (!Directory.Exists(databaseDirectoryPath))
				Directory.CreateDirectory(databaseDirectoryPath);

			if (!File.Exists(databaseFilePath))
				retval = this.NativeDatabaseFileFactory.CreateNativeDatabaseFile(databaseFilePath);

			return retval;
		}

		public void InitializeFromRevisionHistoryResource(IUnitOfWorkFactory unitOfWorkFactory, Type revisionHistoryResourceAssemblyType, string revisionHistoryResourceName)
		{
			DatabaseHistory history;

			if ((object)unitOfWorkFactory == null)
				throw new ArgumentNullException("unitOfWorkFactory");

			if ((object)revisionHistoryResourceAssemblyType == null)
				throw new ArgumentNullException("revisionHistoryResourceAssemblyType");

			if ((object)revisionHistoryResourceName == null)
				throw new ArgumentNullException("revisionHistoryResourceName");

			if (DataType.IsNullOrWhiteSpace(revisionHistoryResourceName))
				throw new ArgumentOutOfRangeException("revisionHistoryResourceName");

			if (this.UseDatabaseFile)
			{
				if (!DataType.IsNullOrWhiteSpace(this.DatabaseFilePath))
				{
					if (this.KillDatabaseFile)
					{
						if (File.Exists(this.DatabaseFilePath))
							File.Delete(this.DatabaseFilePath);
					}

					this.EnsureDatabaseFile();
				}

				if (!Cerealization.Cerealization.TryGetFromAssemblyResource<DatabaseHistory>(revisionHistoryResourceAssemblyType, revisionHistoryResourceName, out history))
					throw new InvalidOperationException(string.Format("Unable to deserialize instance of '{0}' from the manifest resource name '{1}' in the assembly '{2}'.", typeof(DatabaseHistory).FullName, revisionHistoryResourceName, revisionHistoryResourceAssemblyType.Assembly.FullName));

				using (IUnitOfWork unitOfWork = unitOfWorkFactory.GetUnitOfWork())
				{
					history.PerformSchemaUpgrade(unitOfWork);

					unitOfWork.Complete();
				}
			}
		}

		#endregion
	}
}