using GA.Methods.Interfaces;
using GA.Structures.Interfaces;

using GA.Methods;
using GA.Operators.Interfaces;
using GALibrary.Factories;

namespace GA.Factories
{
    public class FMethod : IFactory
    {
        private static FMethod? _instance;

        private FMethod() { }

        public static FMethod Instance => _instance ??= new FMethod();

        public static ISelectionMethod<T, E, F> Reflection_CreateRoulette<T, E, F>(bool isMinimization, bool isAllowClonage)
             where T : IChromosome<E, F> where E : IGene<F>
        {
            return new Roulette<T, E, F>(isMinimization, isAllowClonage);
        }

        public static ISelectionMethod<T, E, F> Reflection_CreateTournament<T, E, F>(int arenaSize, bool isMinimization, bool isAllowClonage)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new Tournament<T, E, F>(arenaSize, isMinimization, isAllowClonage);

        }

        public object? CreateItem(Type tMethod, Type[]? tGenerics, object[] arguments)
        {
            string methodStr;
            switch (tMethod)
            {
                case Type t when t.Equals(typeof(Roulette<,,>)):
                    methodStr = "Reflection_CreateRoulette";
                    break;

                case Type t when t.Equals(typeof(Tournament<,,>)):
                    methodStr = "Reflection_CreateTournament";

                    if (arguments == null) goto default;
                    break;

                default:
                    throw new Exception();
            }

            return typeof(FMethod).GetMethod(methodStr)?.
                        MakeGenericMethod(tGenerics).Invoke(null, arguments);
        }

        public static ISelectionMethod<T, E, F>[] Reflection_CreateEmptyArray<T, E, F>(Type type, int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new ISelectionMethod<T, E, F>[size];
        }

        public object[]? CreateEmptyArray(Type type, Type[] TGenerics, int size)
        {
            return (object[]?)typeof(FMethod).GetMethod("Reflection_CreateEmptyArray")?.
                         MakeGenericMethod(TGenerics).
                         Invoke(null, new object[] { type, size });
        }
    }
}
