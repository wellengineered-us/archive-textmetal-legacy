﻿/*
	Copyright ©2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;

using TextMetal.Middleware.Oxymoron.Legacy.Config;
using TextMetal.Middleware.Oxymoron.Legacy.Config.Adapters;
using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Oxymoron.Legacy.Adapter.Destination
{
	public class NullDestinationAdapter : DestinationAdapter<AdapterSpecificConfiguration>, INullAdapter
	{
		#region Constructors/Destructors

		public NullDestinationAdapter()
		{
		}

		#endregion

		#region Methods/Operators

		protected override void CoreInitialize()
		{
		}

		protected override void CorePushData(TableConfiguration tableConfiguration, IEnumerable<IRecord> sourceDataEnumerable)
		{
			if ((object)tableConfiguration == null)
				throw new ArgumentNullException(nameof(tableConfiguration));

			if ((object)sourceDataEnumerable == null)
				throw new ArgumentNullException(nameof(sourceDataEnumerable));

			sourceDataEnumerable.Count(); // force enumeration
		}

		protected override void CoreTerminate()
		{
		}

		#endregion
	}
}