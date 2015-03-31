﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Collections.Generic;

namespace TextMetal.Framework.Hosting.Email
{
	public interface IHostEmailMessage
	{
		#region Properties/Indexers/Events

		IList<IHostEmailAttachment> HostEmailAttachments
		{
			get;
		}

		string BlindCarbonCopy
		{
			get;
			set;
		}

		string Body
		{
			get;
			set;
		}

		string CarbonCopy
		{
			get;
			set;
		}

		string From
		{
			get;
			set;
		}

		bool? IsBodyHtml
		{
			get;
			set;
		}

		bool? Processed
		{
			get;
			set;
		}

		string ReplyTo
		{
			get;
			set;
		}

		string Sender
		{
			get;
			set;
		}

		string Subject
		{
			get;
			set;
		}

		string To
		{
			get;
			set;
		}

		#endregion
	}
}