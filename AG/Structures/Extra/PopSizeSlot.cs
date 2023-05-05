using System;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Structures.Extra
{
    public class PopSizeSlot<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {   
        private double _probability;
        private double _cumulative;
        private bool _isEnable;

        IIndividual<T, E, F> _individual;

        public double Probability
        {
            get => this._probability;
            set => this._probability = value;
        }

        public double Cumulative
        {
            get => this._cumulative;
            set => this._cumulative = value;
        }

        public bool IsEnable
        {
            get => this._isEnable;
            set => this._isEnable = value;
        }

        public IIndividual<T, E, F> Individual => this._individual;

        public PopSizeSlot(IIndividual<T, E, F> chromosome)
        {
            this._probability = .0f;
            this._cumulative = .0f;
            this._isEnable = true;

            this._individual = chromosome;
        }

        public override string ToString()
        {
            return $"(({this._individual.ToString()}) P:{this.Probability}, C:{this.Cumulative})";
        }
    }
}
