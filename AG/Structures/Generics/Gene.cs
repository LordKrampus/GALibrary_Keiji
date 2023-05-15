using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Generics
{
    public abstract class Gene<T> : IGene<T>
    {
        protected T _value;

        public virtual T Value { get => this._value; set => this._value = value; }
        public object ObjValue { get => this._value; set => this._value = (T)value; }

        public Gene(T value)
        {
            this._value = value;
        }

        public virtual object[] GenerateArray(int length)
        {
            return new Gene<T>[length];
        }

        public abstract object New(object[] arguments);

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
