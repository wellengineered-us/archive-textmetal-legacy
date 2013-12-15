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

using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	using System;

	public class NewInstanceExpression : Expression
	{
		#region Constructors/Destructors

		public NewInstanceExpression(ConstructorInfo constructor, params Expression[] args)
		{
			this.constructor = constructor;
			this.arguments = args;
		}

		public NewInstanceExpression(Type target, Type[] constructor_args, params Expression[] args)
		{
			this.type = target;
			this.constructorArgs = constructor_args;
			this.arguments = args;
		}

		#endregion

		#region Fields/Constants

		private readonly Expression[] arguments;
		private readonly Type[] constructorArgs;
		private readonly Type type;
		private ConstructorInfo constructor;

		#endregion

		#region Methods/Operators

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			foreach (var exp in this.arguments)
				exp.Emit(member, gen);

			if (this.constructor == null)
				this.constructor = this.type.GetConstructor(this.constructorArgs);

			if (this.constructor == null)
				throw new ProxyGenerationException("Could not find constructor matching specified arguments");

			gen.Emit(OpCodes.Newobj, this.constructor);
		}

		#endregion
	}
}