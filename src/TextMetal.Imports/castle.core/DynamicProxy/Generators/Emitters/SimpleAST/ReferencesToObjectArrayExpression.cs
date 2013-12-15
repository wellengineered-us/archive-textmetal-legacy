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

	/// <summary>
	/// </summary>
	public class ReferencesToObjectArrayExpression : Expression
	{
		#region Constructors/Destructors

		public ReferencesToObjectArrayExpression(params TypeReference[] args)
		{
			this.args = args;
		}

		#endregion

		#region Fields/Constants

		private readonly TypeReference[] args;

		#endregion

		#region Methods/Operators

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			var local = gen.DeclareLocal(typeof(object[]));

			gen.Emit(OpCodes.Ldc_I4, this.args.Length);
			gen.Emit(OpCodes.Newarr, typeof(object));
			gen.Emit(OpCodes.Stloc, local);

			for (var i = 0; i < this.args.Length; i++)
			{
				gen.Emit(OpCodes.Ldloc, local);
				gen.Emit(OpCodes.Ldc_I4, i);

				var reference = this.args[i];

				ArgumentsUtil.EmitLoadOwnerAndReference(reference, gen);

				if (reference.Type.IsByRef)
					throw new NotSupportedException();

				if (reference.Type.IsValueType)
					gen.Emit(OpCodes.Box, reference.Type.UnderlyingSystemType);
				else if (reference.Type.IsGenericParameter)
					gen.Emit(OpCodes.Box, reference.Type);

				gen.Emit(OpCodes.Stelem_Ref);
			}

			gen.Emit(OpCodes.Ldloc, local);
		}

		#endregion
	}
}