/*
	Copyright �2002-2017 Daniel P. Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Middleware.Solder.Utilities.Vfs
{
	public interface IVirtualFileSystemItem
	{
		#region Properties/Indexers/Events

		string ItemName
		{
			get;
		}

		string ItemPath
		{
			get;
		}

		VirtualFileSystemItemType ItemType
		{
			get;
		}

		#endregion
	}
}