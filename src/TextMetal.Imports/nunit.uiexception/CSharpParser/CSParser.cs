// ****************************************************************
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.Text;

namespace NUnit.UiException.CodeFormatters
{
	/// <summary>
	/// 	(formerly named CSParser)
	/// 
	/// 	Helper class to build and setup FormattedCode instances from formatted C# texts.
	/// </summary>
	public class CSharpCodeFormatter :
		ICodeFormatter
	{
		#region Constructors/Destructors

		/// <summary>
		/// 	Builds a new instance of CSharpCodeFormatter.
		/// </summary>
		public CSharpCodeFormatter()
		{
			this._info = FormattedCode.NewCodeInfo();

			return;
		}

		#endregion

		#region Fields/Constants

		/// <summary>
		/// 	The underlying data object of a FormattedCode instance.
		/// </summary>
		private FormattedCode.CodeInfo _info;

		#endregion

		#region Properties/Indexers/Events

		/// <summary>
		/// 	Gets a new instance of FormattedCode.
		/// 	To get useful FormattedCode instances, caller should ensure
		/// 	that TryParse() was invoked first.
		/// </summary>
		public FormattedCode CSCode
		{
			get
			{
				return (new InternalFormattedCode(this._info));
			}
		}

		/// <summary>
		/// 	Returns "C#"
		/// </summary>
		public string Language
		{
			get
			{
				return ("C#");
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// 	Interprets and highlight the given string as C# code
		/// 	and return the resulting FormattedCode instance.
		/// </summary>
		/// <param name="csharpCode"> A string read as C# code. This parameter must not be null. </param>
		/// <returns> A FormattedCode instance containing data to highlight the text with basic syntax coloring. </returns>
		public FormattedCode Format(string csharpCode)
		{
			UiExceptionHelper.CheckNotNull(csharpCode, "csharpCode");

			this._info = FormattedCode.NewCodeInfo();
			csharpCode = this.PreProcess(csharpCode);
			this.Parse(csharpCode);

			return (this.CSCode);
		}

		/// <summary>
		/// 	Analyzes the input text as C# code. This method doesn't return anything.
		/// 	Callers may retrieve the result of this process by querying the FormattedCode property.
		/// 	Passing null results in raising an exception.
		/// </summary>
		/// <param name="csharp"> The text to be analyzed. </param>
		protected void Parse(string csharp)
		{
			TokenClassifier classifier;
			ConcreteToken csToken;
			ClassificationTag tag;
			Lexer lexer;
			StringBuilder text;
			int tokenIndex;

			UiExceptionHelper.CheckNotNull(csharp, "csharp");

			csharp = this.PreProcess(csharp);

			lexer = new Lexer();
			lexer.Parse(csharp);

			classifier = new TokenClassifier();
			text = new StringBuilder();
			csToken = null;
			tokenIndex = 0;

			// loop through each token in the text
			while (lexer.Next())
			{
				// classify the current token 
				tag = classifier.Classify(lexer.CurrentToken);

				// if the tag cannot be merged with current csToken
				// we flush csToken into _info and build a new instance
				// from the current tag.
				if (csToken == null ||
				    !csToken.CanMerge(this._info.LineArray.Count, tag))
				{
					this._flushToken(csToken, this._info);
					csToken = new ConcreteToken(
						lexer.CurrentToken.Text, tag,
						lexer.CurrentToken.IndexStart,
						this._info.LineArray.Count);
				}

				// append token's text into text
				text.Append(lexer.CurrentToken.Text);

				// handle newline character. Appends tokenIndex to LineArray
				// and set tokenIndex to the start of the newline.
				if (lexer.CurrentToken.Text == "\n")
				{
					this._info.LineArray.Add(tokenIndex);
					tokenIndex = this._info.IndexArray.Count + 1;
				}
			}

			// flush terminal token
			this._flushToken(csToken, this._info);

			if (csToken != null &&
			    this._info.LineArray.Count == 0)
				this._info.LineArray.Add(tokenIndex);

			this._info.Text = csharp;

			return;
		}

		/// <summary>
		/// 	Prepare input text for the parsing stage.
		/// </summary>
		/// <param name="text"> The text to be pre-processed. </param>
		/// <returns> A string ready to be parsed. </returns>
		protected string PreProcess(string text)
		{
			if (text == null)
				return (null);

			// this replace tabulation by space sequences. The reason is
			// that the technique used to measure strings at rendering time
			// fail to measure '\t' correctly and lines of text containing those
			// characters are badly aligned.
			//  The simplest thing to fix that is to remove tabs altogether.

			return (text.Replace("\t", "    "));
		}

		/// <summary>
		/// 	Appends data in token at the end of output.
		/// </summary>
		/// <param name="token"> Token to be merged with output. </param>
		/// <param name="output"> Target location. </param>
		private void _flushToken(ClassifiedToken token, FormattedCode.CodeInfo output)
		{
			if (token == null)
				return;

			output.IndexArray.Add(token.IndexStart);
			output.TagArray.Add((byte)token.Tag);

			return;
		}

		#endregion

		#region Classes/Structs/Interfaces/Enums/Delegates

		/// <summary>
		/// 	Implements ClassifiedToken.
		/// </summary>
		private class ConcreteToken :
			ClassifiedToken
		{
			#region Constructors/Destructors

			/// <summary>
			/// 	Builds and setup a new instance of ClassifiedToken.
			/// </summary>
			/// <param name="text"> The text in this token. </param>
			/// <param name="tag"> The smState tag. </param>
			/// <param name="indexStart"> Starting startingPosition of the string from the beginning of the text. </param>
			/// <param name="lineIndex"> The line startingPosition. </param>
			public ConcreteToken(string text, ClassificationTag tag, int indexStart, int lineIndex)
			{
				this._text = text;
				this._tag = tag;
				this._indexStart = indexStart;
				this._lineIndex = lineIndex;

				return;
			}

			#endregion

			#region Fields/Constants

			private int _lineIndex;

			#endregion

			#region Methods/Operators

			/// <summary>
			/// 	Tests whether or not the given lineIndex and tag are compatible with
			/// 	the ones in the current Token.
			/// </summary>
			/// <param name="lineIndex"> A line startingPosition. </param>
			/// <param name="tag"> A smState tag. </param>
			/// <returns> A boolean that says whether these data are compatible. </returns>
			public bool CanMerge(int lineIndex, ClassificationTag tag)
			{
				return (this._tag == tag && this._lineIndex == lineIndex);
			}

			#endregion
		}

		/// <summary>
		/// 	Implements FormattedCode.
		/// </summary>
		private class InternalFormattedCode :
			FormattedCode
		{
			#region Constructors/Destructors

			public InternalFormattedCode(CodeInfo info)
			{
				this._codeInfo = info;
			}

			#endregion
		}

		#endregion
	}
}