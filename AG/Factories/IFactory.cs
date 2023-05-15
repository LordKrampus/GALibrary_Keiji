using System;

namespace GALibrary.Factories
{
    public interface IFactory
    {
        public object CreateItem(Type type, Type[] tGenerics, object[] arguments);
        public object[] CreateEmptyArray(Type type, Type[] tGenerics, int size);
    }
}
