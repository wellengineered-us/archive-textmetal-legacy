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
	using System;

	public class NullCoalescingOperatorExpression : Expression
	{
		#region Constructors/Destructors

		public NullCoalescingOperatorExpression(Expression expression, Expression @default)
		{
			if (expression == null)
				throw new ArgumentNullException("expression");

			if (@default == null)
				throw new ArgumentNullException("default");

			this.expression = expression;
			this.@default = @default;
		}

		#endregion

		#region Fields/Constants

		private readonly Expression @default;
		private readonly Expression expression;

		#endregion

		#region Methods/Operators

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			this.expression.Emit(member, gen);
			gen.Emit(OpCodes.Dup);
			var label = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, label);
			gen.Emit(OpCodes.Pop);
			this.@default.Emit(member, gen);
			gen.MarkLabel(label);
		}

		#endregion
	}
}