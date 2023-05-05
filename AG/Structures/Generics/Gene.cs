using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Generics
{
    public abstract class Gene<T> : IGene<T>
    {
        protected T _value;

        public T Value { get => this._value; set => this._value = value; }

        public Gene(T value)
        {
            this._value = value;
        }

        public abstract BIGene Generate();

        public override string ToString()
        {
            return this._value.ToString();
        }
    }
}
