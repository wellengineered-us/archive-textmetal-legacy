﻿/*
	Copyright ©2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Data;

using Newtonsoft.Json;

using TextMetal.Middleware.Datazoid.Primitives;
using TextMetal.Middleware.Solder.Extensions;
using TextMetal.Middleware.Solder.Primitives;

namespace TextMetal.Middleware.Oxymoron.Legacy.Config.Adapters
{
	public class AdoNetParameterConfiguration : ConfigurationObject, IAdoNetParameter
	{
		#region Constructors/Destructors

		public AdoNetParameterConfiguration()
		{
		}

		#endregion

		#region Fields/Constants

		private string sourceColumn;

		private DbType parameterDbType;
		private ParameterDirection parameterDirection;
		private string parameterName;
		private bool parameterNullable;
		private byte parameterPrecision;
		private byte parameterScale;
		private int parameterSize;
		private object parameterValue;

		#endregion

		#region Properties/Indexers/Events

		public string SourceColumn
		{
			get
			{
				return this.sourceColumn;
			}
			set
			{
				this.sourceColumn = value;
			}
		}

		public DbType ParameterDbType
		{
			get
			{
				return this.parameterDbType;
			}
			set
			{
				this.parameterDbType = value;
			}
		}

		public ParameterDirection ParameterDirection
		{
			get
			{
				return this.parameterDirection;
			}
			set
			{
				this.parameterDirection = value;
			}
		}

		public string ParameterName
		{
			get
			{
				return this.parameterName;
			}
			set
			{
				this.parameterName = value;
			}
		}

		public bool ParameterNullable
		{
			get
			{
				return this.parameterNullable;
			}
			set
			{
				this.parameterNullable = value;
			}
		}

		public byte ParameterPrecision
		{
			get
			{
				return this.parameterPrecision;
			}
			set
			{
				this.parameterPrecision = value;
			}
		}

		public byte ParameterScale
		{
			get
			{
				return this.parameterScale;
			}
			set
			{
				this.parameterScale = value;
			}
		}

		public int ParameterSize
		{
			get
			{
				return this.parameterSize;
			}
			set
			{
				this.parameterSize = value;
			}
		}

		public object ParameterValue
		{
			get
			{
				return this.parameterValue;
			}
			set
			{
				this.parameterValue = value;
			}
		}

		[JsonIgnore]
		public new AdoNetAdapterConfiguration Parent
		{
			get
			{
				return (AdoNetAdapterConfiguration)base.Parent;
			}
			set
			{
				base.Parent = value;
			}
		}

		#endregion

		#region Methods/Operators

		public override IEnumerable<Message> Validate()
		{
			return this.Validate(null);
		}

		public IEnumerable<Message> Validate(int? parameterIndex)
		{
			List<Message> messages;

			messages = new List<Message>();

			if (SolderLegacyInstanceAccessor.DataTypeFascadeLegacyInstance.IsNullOrWhiteSpace(this.ParameterName))
				messages.Add(NewError(string.Format("Parameter[{0}] name is required.", parameterIndex)));

			return messages;
		}

		#endregion
	}
}