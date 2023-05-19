using GA.Structures.Interfaces;
using GA.Functions.Interfaces;
using GA.Methods.Interfaces;
using GA.Operators.Interfaces;

using GA.Algoritmos;
using GALibrary.Factories;

namespace GA.Factories
{
    public class FAlgorithm : IFactory
    {
        private static FAlgorithm? _instance;

        private FAlgorithm() { }

        public static FAlgorithm Instance = _instance ??= new FAlgorithm();

        public static IGeneticAlgorithm<T, E, F> Reflection_CreateAlgorithm<T, E, F>(IPopulation<T, E, F> population,
            IFunction function, ISelectionMethod<T, E, F> method, object[] operators, object[] arguments)
            where T : IChromosome<E, F> where E: IGene<F>
        {
            IOperator<T, E, F>[] castOperators = new IOperator<T, E, F>[] { (IOperator<T, E, F>)operators[0], (IOperator<T, E, F>)operators[1] };

            return new GeneticAlgorithm<T, E, F>(population, (int)arguments[0],
                function, method, castOperators, hasElitismo: (bool)arguments[1]);
        }

        public object? CreateItem(Type tAlgorithm, Type[] tGenerics, object population, object function,
            object method, object[] ops, object[] arguments)
        {
            return this.CreateItem(tAlgorithm, tGenerics, new object[] { population, function, method, ops, arguments });
        }

        public object? CreateItem(Type tAlgorithm, Type[] tGenerics, object[] arguments)
        {
            return typeof(FAlgorithm).GetMethod("Reflection_CreateAlgorithm")?.
                 MakeGenericMethod(tGenerics).Invoke(null, arguments);
        }

        public static IGeneticAlgorithm<T, E, F>[] Reflection_CreateEmptyArray<T, E, F>(Type type, int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new IGeneticAlgorithm<T, E, F>[size];
        }

        public object[] CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            return (object[])typeof(FAlgorithm).GetMethod("Reflection_CreateEmptyArray")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { type, size });
        }
    }
}
