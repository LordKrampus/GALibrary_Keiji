using GA.Structures.Interfaces;
using GA.Functions.Interfaces;
using GA.Methods.Interfaces;
using GA.Operators.Interfaces;

using GA.Algoritmos;

namespace GA.Factories
{
    public class FAlgorithm
    {
        private static FAlgorithm? _instance;

        private FAlgorithm() { }

        public static FAlgorithm Instance = _instance ??= new FAlgorithm();

        public static IGeneticAlgorithm<T, E, F> Reflection_CreateAlgorithm<T, E, F>(IPopulation<T, E, F> population,
            IFunction function, ISelectionMethod<T, E, F> method, IOperator<T, E, F>[] operadores, object[] arguments)
            where T : IChromosome<E, F> where E: IGene<F>
        {
            return new GeneticAlgorithm<T, E, F>(population,  limitGenerations: (int)arguments[0], 
                crossoverRate: (double)arguments[1], mutationRate: (double)arguments[2], function,
                method, operadores, hasElitismo: (bool)arguments[3]);
        }

        public object? GenerateAlgorithm(Type tChromosome, Type tGene, Type tGeneValue, 
            object population, object function, object method, object[] ops, object[] arguments)
        {
            return typeof(FAlgorithm).GetMethod("Reflection_CreateAlgorithm")?.
                 MakeGenericMethod(new Type[] { tChromosome, tGene, tGeneValue}).
                 Invoke(null, new object[] { population, function, method, ops, arguments });
        }

    }
}
