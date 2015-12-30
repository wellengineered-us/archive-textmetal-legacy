// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright 2004-2012 Castle Project - http://www.castleproject.org/
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
	public class IfNullExpression : Expression
	{
		#region Constructors/Destructors

		public IfNullExpression(Reference reference, IILEmitter ifNull, IILEmitter ifNotNull = null)
		{
			this.reference = reference;
			this.ifNull = ifNull;
			this.ifNotNull = ifNotNull;
		}

		#endregion

		#region Fields/Constants

		private readonly IILEmitter ifNotNull;
		private readonly IILEmitter ifNull;
		private readonly Reference reference;

		#endregion

		#region Methods/Operators

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(this.reference, gen);
			var notNull = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, notNull);
			this.ifNull.Emit(member, gen);
			gen.MarkLabel(notNull);
			if (this.ifNotNull != null) // yeah, I know that reads funny :)
				this.ifNotNull.Emit(member, gen);
		}

		#endregion
	}
}