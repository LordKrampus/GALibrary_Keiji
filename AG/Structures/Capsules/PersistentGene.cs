using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class PersistentGene<T, E> : Gene<E> where T :  IGene<E>  
    {
        private T _gene;
        private string _name;
        private int _persistence;

        public T Gene => this._gene;
        public string Name => this._name;
        public int Persistence => this._persistence;

        public PersistentGene(T gene, string name, int persistence) : base (gene.Value)
        {
            this._gene = gene;
            this._name = name;
            this._persistence = persistence;
        }

        public override object New(object[] arguments)
        {
            return new PersistentGene<T, E>(this._gene, this._name, this._persistence);
        }

        public object[] GenerateArray(int length)
        {
            return new PersistentGene<T, E>[length];
        }

        public override string ToString()
        {
            return base.ToString() + $" ({Persistence})";
        }
    }
}