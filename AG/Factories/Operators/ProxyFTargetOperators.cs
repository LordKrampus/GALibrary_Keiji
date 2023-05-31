using GA.Functions.Interfaces;
using GA.Operators.Interfaces;
using GA.Operators;
using System;
using GA.Structures.Interfaces;
using System.Reflection;

namespace GALibrary.Factories.Operators
{
    public class ProxyFTargetOperators : FOperators
    {
        FOperators _fTarget;
        FOperators _fCovered;

        public ProxyFTargetOperators(FOperators fTarget, FOperators fCovered) 
        {
            this._fTarget = fTarget;
            this._fCovered = fCovered;
        }

        public override BIOperator CreateCrossover(Type type, IFunction function, double factor, object[]? arguments)
        {
            return this._fTarget.CreateCrossover(type, function, factor, 
                new object[]{ this._fCovered.CreateCrossover(typeof(Crossover<,,>), function, factor, new object[] {}) });
        }

        public override BIOperator CreateMutation(Type type, IFunction function, double factor, object[]? arguments)
        {
            return this._fTarget.CreateMutation(type, function, factor, new object[] { this._fCovered });

        }

        public override object[] CreateEmptyArray(int size)
        {
            return this._fTarget.CreateEmptyArray(size);
        }
    }
}
