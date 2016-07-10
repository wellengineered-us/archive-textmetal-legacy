﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using TextMetal.Middleware.Oxymoron.Legacy.Config.Adapters;
using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Oxymoron.Legacy.Config
{
	public sealed class AdapterConfiguration<TAdapterSpecificConfiguration> : AdapterConfiguration
		where TAdapterSpecificConfiguration : AdapterSpecificConfiguration, new()
	{
		#region Constructors/Destructors

		public AdapterConfiguration(AdapterConfiguration adapterConfiguration)
		{
			if ((object)adapterConfiguration == null)
				throw new ArgumentNullException(nameof(adapterConfiguration));

			if ((object)base.AdapterSpecificConfiguration != null &&
				(object)adapterConfiguration.AdapterSpecificConfiguration != null)
			{
				foreach (KeyValuePair<string, object> keyValuePair in adapterConfiguration.AdapterSpecificConfiguration)
					base.AdapterSpecificConfiguration.Add(keyValuePair.Key, keyValuePair.Value);
			}

			this.AdapterAqtn = adapterConfiguration.AdapterAqtn;
			this.Parent = adapterConfiguration.Parent;
			this.Surround = adapterConfiguration.Surround;
		}

		#endregion

		#region Fields/Constants

		private TAdapterSpecificConfiguration adapterSpecificConfiguration;
		private bool frozen;

		#endregion

		#region Properties/Indexers/Events

		public new TAdapterSpecificConfiguration AdapterSpecificConfiguration
		{
			get
			{
				this.ApplyAdapterSpecificConfiguration(); // special case
				return this.adapterSpecificConfiguration;
			}
			set
			{
				this.EnsureParentOnPropertySet(this.adapterSpecificConfiguration, value);
				this.adapterSpecificConfiguration = value;
			}
		}

		public bool Frozen
		{
			get
			{
				return this.frozen;
			}
			set
			{
				this.frozen = value;
			}
		}

		#endregion

		#region Methods/Operators

		public void ApplyAdapterSpecificConfiguration()
		{
			if ((object)base.AdapterSpecificConfiguration != null && !this.Frozen)
			{
				this.AdapterSpecificConfiguration = JObject.FromObject(base.AdapterSpecificConfiguration).ToObject<TAdapterSpecificConfiguration>();
				this.Frozen = true;
			}
		}

		public override Type GetAdapterSpecificConfigurationType()
		{
			return typeof(TAdapterSpecificConfiguration);
		}

		public override void ResetAdapterSpecificConfiguration()
		{
			base.ResetAdapterSpecificConfiguration();
			this.Frozen = false;
			this.AdapterSpecificConfiguration = null;
		}

		public override IEnumerable<Message> Validate(string adapterContext)
		{
			List<Message> messages;

			messages = new List<Message>();
			messages.AddRange(base.Validate(adapterContext));

			if ((object)this.AdapterSpecificConfiguration != null)
				messages.AddRange(this.AdapterSpecificConfiguration.Validate(adapterContext));

			return messages;
		}

		#endregion
	}
}