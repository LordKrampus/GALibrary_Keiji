using GA.Methods.Interfaces;
using GA.Structures.Interfaces;

using GA.Methods;

namespace GA.Factories
{
    public class FMethod
    {
        private static FMethod? _instance;

        private FMethod() { }

        public static FMethod Instance => _instance ??= new FMethod();

        public static ISelectionMethod<T, E, F> ReflectionGenerateMethod<T, E, F>(Type type, object[] arguments) 
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type) 
            {
                case Type t when t.Equals(typeof(Roulette<,,>)):
                    return new Roulette<T, E, F>(isMinimization:(bool)arguments[0], isAllowClonage:(bool)arguments[1]);

                case Type t when t.Equals(typeof(Tournament<,,>)):
                    if (arguments == null) goto default;
                    return new Tournament<T, E, F>(arenaSize:(int)arguments[0], isMinimization:(bool)arguments[1], isAllowClonage:(bool)arguments[2]);

                default:
                    throw new Exception();
            }
        }

        public object? GenerateMethod(Type tChromosome, Type tGene, Type tGeneValue, Type tMethod, object[] parameters)
        {
            return typeof(FMethod).GetMethod("ReflectionGenerateMethod")?.
                        MakeGenericMethod(new Type[] { tChromosome, tGene, tGeneValue}).
                        Invoke(null, new object[] { tMethod, parameters });
        }
    }
}
