﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 4.3.0.27741;
// 		Copyright ©2002-2011 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: http://code.google.com/p/textmetal/
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2011 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

using TextMetal.Core.Plumbing;

namespace TextMetal.WebHostSample.Objects.Model
{
	public partial class Repository : IRepository
	{		
		#region Constructors/Destructors
		
		public Repository()
		{
		}
		
		#endregion
		
		#region Fields/Constants
		
		private const string CONNECTION_STRING_NAME = "TextMetal.WebHostSample.Objects.Model::ConnectionString";
		private const int MSSQL_PERSIST_NOT_EXPECTED_RECORDS_AFFECTED = 0;
		private const int MSSQL_QUERY_EXPECTED_RECORDS_AFFECTED = -1;
		private const int SQLITE_PERSIST_NOT_EXPECTED_RECORDS_AFFECTED = 0;
		private const int SQLITE_QUERY_EXPECTED_RECORDS_AFFECTED = 0;
						
		#endregion
		
		#region Properties/Indexers/Events
		
		public static string ConnectionString
		{
			get
			{
				string connectionString;

				connectionString = AppConfig.GetConnectionString(CONNECTION_STRING_NAME);

				OnPreProcessConnectionString(ref connectionString);
				
				return connectionString;
			}
		}
		
		public static Type ConnectionType
		{
			get
			{
				return Type.GetType(AppConfig.GetConnectionProvider(CONNECTION_STRING_NAME), true);
			}
		}
				
		#endregion
		
		#region Methods/Operators
		
		public static UnitOfWorkContext GetUnitOfWorkContext()
		{
			return UnitOfWorkContext.Create(ConnectionType, ConnectionString, true);
		}

		static partial void OnPreProcessConnectionString(ref string connectionString);
		
		protected delegate TResult Stank<T1, TResult>(T1 p1);

		protected delegate TResult Stank<T1, T2, TResult>(T1 p1, T2 p2);

		protected delegate TResult Stank<T1, T2, T3, TResult>(T1 p1, T2 p2, T3 p3);

		protected delegate TResult Stank<T1, T2, T3, T4, TResult>(T1 p1, T2 p2, T3 p3, T4 p4);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15);

		protected delegate TResult Stank<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16);

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, TResult>(Stank<UnitOfWorkContext, T1, TResult> callbackMethod, T1 p1)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, TResult>(Stank<UnitOfWorkContext, T1, T2, TResult> callbackMethod, T1 p1, T2 p2)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, TResult> callbackMethod, T1 p1, T2 p2, T3 p3)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
			}
		}

		protected TResult ExecuteAmbientUnitOfWorkAware<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Stank<UnitOfWorkContext, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> callbackMethod, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
		{			
			TResult retval;
			
			if ((object)UnitOfWorkContext.Current == null)
			{
				using (UnitOfWorkContext unitOfWorkContext = Repository.GetUnitOfWorkContext())
				{
					retval = callbackMethod(unitOfWorkContext, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
											
					unitOfWorkContext.Complete();
					
					return retval;
				}
			}			
			else
			{
				return callbackMethod(UnitOfWorkContext.Current, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
			}
		}

		#endregion
	}
}
