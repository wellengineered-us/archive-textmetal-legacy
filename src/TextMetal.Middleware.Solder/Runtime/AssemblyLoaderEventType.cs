/*
	Copyright �2002-2016 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

namespace TextMetal.Middleware.Solder.Runtime
{
	public enum AssemblyLoaderEventType : byte
	{
		Unknown = 0,
		Startup = 1,
		Shutdown = 2,
		Brick = 0xFF
	}
}