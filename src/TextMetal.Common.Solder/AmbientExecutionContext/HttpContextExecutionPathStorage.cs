﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Web;

namespace TextMetal.Common.Solder.AmbientExecutionContext
{
	public sealed class HttpContextExecutionPathStorage : IExecutionPathStorage
	{
		#region Constructors/Destructors

		public HttpContextExecutionPathStorage()
		{
		}

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// Gets a value indicating if the current application domain is running under ASP.NET.
		/// </summary>
		public static bool IsInHttpContext
		{
			get
			{
				return (object)HttpContext.Current != null;
			}
		}

		#endregion

		#region Methods/Operators

		public T GetValue<T>(string key)
		{
			return (T)HttpContext.Current.Items[key];
		}

		public bool HasValue(string key)
		{
			return HttpContext.Current.Items.Contains(key);
		}

		public void RemoveValue(string key)
		{
			HttpContext.Current.Items.Remove(key);
		}

		public void SetValue<T>(string key, T value)
		{
			HttpContext.Current.Items[key] = value;
		}

		#endregion
	}
}