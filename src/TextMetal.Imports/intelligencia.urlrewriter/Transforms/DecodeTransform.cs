// UrlRewriter - A .NET URL Rewriter module
// Version 2.0
//
// Copyright 2011 Intelligencia
// Copyright 2011 Seth Yates
// 

using System;
using System.Web;

using Intelligencia.UrlRewriter.Utilities;

namespace Intelligencia.UrlRewriter.Transforms
{
	/// <summary>
	/// Url decodes the input.
	/// </summary>
	public sealed class DecodeTransform : IRewriteTransform
	{
		#region Properties/Indexers/Events

		/// <summary>
		/// The name of the action.
		/// </summary>
		public string Name
		{
			get
			{
				return Constants.TransformDecode;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Applies a transformation to the input string.
		/// </summary>
		/// <param name="input"> The input string. </param>
		/// <returns> The transformed string. </returns>
		public string ApplyTransform(string input)
		{
			return HttpUtility.UrlDecode(input);
		}

		#endregion
	}
}