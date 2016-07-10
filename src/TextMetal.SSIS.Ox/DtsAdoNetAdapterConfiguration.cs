/*
	Copyright �2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Data;

using TextMetal.Middleware.Datazoid.UoW;
using TextMetal.Middleware.Oxymoron.Legacy.Config.Adapters;

namespace TextMetal.SSIS.Ox
{
	internal class DtsAdoNetAdapterConfiguration : AdoNetAdapterConfiguration
	{
		#region Constructors/Destructors

		public DtsAdoNetAdapterConfiguration()
		{
		}

		#endregion

		#region Fields/Constants

		private Func<IUnitOfWork> dictionaryUnitOfWorkCallback;

		#endregion

		#region Properties/Indexers/Events

		public Func<IUnitOfWork> DictionaryUnitOfWorkCallback
		{
			get
			{
				return this.dictionaryUnitOfWorkCallback;
			}
			set
			{
				this.dictionaryUnitOfWorkCallback = value;
			}
		}

		#endregion

		#region Methods/Operators

		public override IUnitOfWork GetUnitOfWork(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
		{
			if ((object)this.DictionaryUnitOfWorkCallback != null)
				return this.DictionaryUnitOfWorkCallback();
			else
				return null;
		}

		#endregion
	}
}