using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class PersistentGene<Gen, Val> : Gene<Val> where Gen : IGene<Val>
    {
        private Gen _gene;
        private string _name;
        private int _persistence;

        public Gen Gene => this._gene;
        public string Name => this._name;
        public int Persistence => this._persistence;

        public PersistentGene(Gen gene, string name, int persistence) : base (gene.Value)
        {
            this._gene = gene;
            this._name = name;
            this._persistence = persistence;
        }

        public override object New(object[] arguments)
        {
            return new PersistentGene<Gen, Val>(this._gene, this._name, this._persistence);
        }

        public override object[] GenerateArray(int length)
        {
            return new PersistentGene<Gen, Val>[length];
        }

        public override string ToString()
        {
            return this.Gene.ToString();
        }
    }
}