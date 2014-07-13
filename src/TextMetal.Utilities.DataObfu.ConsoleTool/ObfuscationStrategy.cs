﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;

namespace TextMetal.Utilities.DataObfu.ConsoleTool
{
	/// <summary>
	/// The set of industry standard obfuscation strategies supported by this framework.
	/// </summary>
	public enum ObfuscationStrategy
	{
		/// <summary>
		/// Returns un-obfuscated, original value.
		/// DATA TYPE: any
		/// </summary>
		None = 0,

		/// <summary>
		/// Returns an alternate value using a hashed lookup into a dictionary.
		/// DATA TYPE: string
		/// </summary>
		Substitution,

		/// <summary>
		/// Returns an alternate value using a hashed shuffle of alphanumeric characters (while preserving other characters).
		/// DATA TYPE: string
		/// </summary>
		Shuffling,

		/// <summary>
		/// Returns an alternate value within +/- (x%) of the original value.
		/// DATA TYPE: numeric
		/// Returns an alternate value within +/- (x%:365.25d) of the original value.
		/// DATA TYPE: temporal
		/// </summary>
		Variance,

		/// <summary>
		/// Returns an alternate value that is a binary encryption of the original value.
		/// DATA TYPE: string
		/// </summary>
		Ciphering,

		/// <summary>
		/// Returns an alternate value that is always null if NULL or the default value if NOT NULL.
		/// DATA TYPE: any
		/// </summary>
		Defaulting,

		/// <summary>
		/// Returns an alternate value that is a +/- (%) mask of the original value.
		/// DATA TYPE: string
		/// </summary>
		Masking
	}
}