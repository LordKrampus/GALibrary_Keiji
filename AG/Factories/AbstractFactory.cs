using System;

using GALibrary.Factories;


namespace GA.Factories
{
	public class AbstractFactory
	{
		private static AbstractFactory _instance;

		private AbstractFactory() { }

		public static AbstractFactory Instance => _instance ??= new AbstractFactory();

		public object CreateItem(IFactory factory, Type type, Type[]? tGenerics, object[] arguments)
		{
			return factory.CreateItem(type, tGenerics, arguments);
		}

		public object[] CreateEmptyArray(IFactory factory, Type type, Type[] tGenerics, int size)
		{
			return factory.CreateEmptyArray(type, tGenerics, size);
		}
	}
}