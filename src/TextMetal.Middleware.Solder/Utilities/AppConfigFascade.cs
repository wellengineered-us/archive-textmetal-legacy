﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using Microsoft.Framework.Configuration;
using Microsoft.Framework.Configuration.Json;

namespace TextMetal.Middleware.Solder.Utilities
{
	/// <summary>
	/// Provides static helper and/or extension methods for strongly typed read access to an app.config or web.config file.
	/// </summary>
	public class AppConfigFascade : IAppConfigFascade
	{
		#region Constructors/Destructors

		/// <summary>
		/// Initializes a new instance of the AppConfigFascade class.
		/// </summary>
		/// <param name="appConfigFilePath"> The file path to the application configuration JSON file. </param>
		/// <param name="dataTypeFascade"> The data type instance to use. </param>
		public AppConfigFascade(string appConfigFilePath, IDataTypeFascade dataTypeFascade)
		{
			if ((object)dataTypeFascade == null)
				throw new ArgumentNullException(nameof(dataTypeFascade));

			this.dataTypeFascade = dataTypeFascade;

			this.LoadAppConfigFile(appConfigFilePath);
		}

		#endregion

		#region Fields/Constants

		private readonly IDataTypeFascade dataTypeFascade;

		#endregion

		#region Properties/Indexers/Events

		private IDataTypeFascade DataTypeFascade
		{
			get
			{
				return this.dataTypeFascade;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Gets the value of an app settings for the current application's default configuration. A AppConfigException is thrown if the key does not exist.
		/// </summary>
		/// <typeparam name="TValue"> The type to convert the app settings value. </typeparam>
		/// <param name="key"> The key to get a value. </param>
		/// <returns> The app settings as type TValue. </returns>
		public TValue GetAppSetting<TValue>(string key)
		{
			string svalue;
			TValue ovalue;
			Type typeOfValue;

			if ((object)key == null)
				throw new ArgumentNullException(nameof(key));

			typeOfValue = typeof(TValue);
			svalue = "TODO";

			if ((object)svalue == null)
				throw new AppConfigException(string.Format("Key '{0}' was not found in app.config file.", key));

			if (!this.DataTypeFascade.TryParse<TValue>(svalue, out ovalue))
				throw new AppConfigException(string.Format("App.config key '{0}' value '{1}' is not a valid '{2}'.", key, svalue, typeOfValue.FullName));

			return ovalue;
		}

		/// <summary>
		/// Gets the value of an app settings for the current application's default configuration. A AppConfigException is thrown if the key does not exist.
		/// </summary>
		/// <param name="valueType"> The type to convert the app settings value. </param>
		/// <param name="key"> The key to get a value. </param>
		/// <returns> The app settings as a string. </returns>
		public object GetAppSetting(Type valueType, string key)
		{
			string svalue;
			object ovalue;

			if ((object)valueType == null)
				throw new ArgumentNullException(nameof(valueType));

			if ((object)key == null)
				throw new ArgumentNullException(nameof(key));

			svalue = "TODO";

			if ((object)svalue == null)
				throw new AppConfigException(string.Format("Key '{0}' was not found in app.config file.", key));

			if (!this.DataTypeFascade.TryParse(valueType, svalue, out ovalue))
				throw new AppConfigException(string.Format("App.config key '{0}' value '{1}' is not a valid '{2}'.", key, svalue, valueType.FullName));

			return ovalue;
		}

		/// <summary>
		/// Checks to see if an app settings key exists for the current application's default configuration.
		/// </summary>
		/// <param name="key"> The key to check. </param>
		/// <returns> A boolean value indicating the app setting key presence. </returns>
		public bool HasAppSetting(string key)
		{
			string value;

			if ((object)key == null)
				throw new ArgumentNullException(nameof(key));

			value = "TODO";

			return ((object)value != null);
		}

		private void LoadAppConfigFile(string appConfigFilePath)
		{
			if ((object)appConfigFilePath == null)
				throw new ArgumentNullException(nameof(appConfigFilePath));

			IConfigurationBuilder configurationBuilder;
			IConfigurationProvider configurationProvider;
			IConfigurationRoot configurationRoot;

			configurationBuilder = new ConfigurationBuilder();
			configurationProvider = new JsonConfigurationProvider(appConfigFilePath);
			configurationBuilder.Add(configurationProvider);
			configurationRoot = configurationBuilder.Build();
		}

		#endregion
	}
}