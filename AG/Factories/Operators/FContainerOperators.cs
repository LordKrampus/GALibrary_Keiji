using GA.Factories;
using GA.Operators.Interfaces;
using GA.Operators;
using GA.Structures.Interfaces;
using System;
using GALibrary.Operators;
using GA.Structures.Capsules;

namespace GALibrary.Factories.Operators
{
    public class FContainerOperators<T, E, F, G, H> : FOperators<T, G, H>
         where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
       where F : IChromosome<G, H> where G : IGene<H>
    {
        private static FContainerOperators<T, E, F, G, H> _instance;

        private FContainerOperators() { }

        public static FContainerOperators<T, E, F, G, H> GetInstance()
        {
            return _instance ??= new FContainerOperators<T, E, F, G, H>();
        }

        public BIOperator CreateCrossover(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(ContainerCrossover<,,,,>)):
                    return CreateContainerCrossover(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateContainerCrossover(object[] arguments)
        {
            return new ContainerCrossover<T, E, F, G, H>((double)arguments[0]);
        }

        public BIOperator CreateMutation(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(ContainerMutation<,,,,>)):
                    return CreateContainerMutation(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateContainerMutation(object[] arguments)
        {
            return new ContainerMutation<T, E, F, G, H>((double)arguments[0]);
        }
    }
}
