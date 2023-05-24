using GA.Factories;
using GA.Operators.Interfaces;
using GA.Operators;
using GA.Structures.Interfaces;
using System;
using GALibrary.Operators;
using GA.Structures.Capsules;
using GA.Functions.Interfaces;

namespace GALibrary.Factories.Operators
{
    public class FContainerOperators<T, E, F, G, H> : FOperators
         where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
       where F : IChromosome<G, H> where G : IGene<H>
    {
        private static FContainerOperators<T, E, F, G, H> _instance;

        private FContainerOperators() { }

        public static FContainerOperators<T, E, F, G, H> GetInstance()
        {
            return _instance ??= new FContainerOperators<T, E, F, G, H>();
        }

        public override BIOperator CreateCrossover(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(ContainerCrossover<,,,,>)):
                    return CreateContainerCrossover(function, factor);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateContainerCrossover(IFunction function, double factor)
        {
            return new ContainerCrossover<T, E, F, G, H>(function, factor);
        }

        public override BIOperator CreateMutation(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(ContainerMutation<,,,,>)):
                    return CreateContainerMutation(function, factor);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateContainerMutation(IFunction function, double factor)
        {
            return new ContainerMutation<T, E, F, G, H>(function, factor);
        }

        public override object[] CreateEmptyArray(int size)
        {
            return new IOperator<T, G, H>[size];
        }
    }
}
