﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.IO;

namespace TextMetal.Utilities.VsIdeConv.ConsoleTool.FileHandlers
{
	public interface IFileHandler
	{
		#region Methods/Operators

		void Execute(FileInfo fileInfo);

		#endregion
	}
}