// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ReturnStatement : Statement
	{
		#region Constructors/Destructors

		public ReturnStatement()
		{
		}

		public ReturnStatement(Reference reference)
		{
			this.reference = reference;
		}

		public ReturnStatement(Expression expression)
		{
			this.expression = expression;
		}

		#endregion

		#region Fields/Constants

		private readonly Expression expression;
		private readonly Reference reference;

		#endregion

		#region Methods/Operators

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			if (this.reference != null)
				ArgumentsUtil.EmitLoadOwnerAndReference(this.reference, gen);
			else if (this.expression != null)
				this.expression.Emit(member, gen);
			else
			{
				if (member.ReturnType != typeof(void))
					OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, member.ReturnType);
			}

			gen.Emit(OpCodes.Ret);
		}

		#endregion
	}
}