using System;
using System.Text;

using GA.Structures.BasicInterfaces;

using GA.Functions.Interfaces;
using GA.Structures.Interfaces;
using GA.Methods.Interfaces;
using GA.Operators.Interfaces;

using GA.Procedures;
using GA.Structures.Individuals;


namespace GA.Algoritmos
{
    public class GeneticAlgorithm<T, E, F> : IGeneticAlgorithm<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        protected IPopulation<T, E, F> _population;
        protected int _limitGenerations;
        protected double _crossoverRate;
        protected double _mutationRate;
        protected IFunction _function;

        private ISelectionMethod<T, E, F> _sMethod;
        private IOperator<T, E, F>[] _operators;
        private Elitismo<T, E, F> _elitismo;

        private bool _hasElitismo;

        private IIndividual<T, E, F>? _bestIndividual;
        private bool _hasFinished;

        private List<string> _cacheGenerations;
        private List<IIndividual<T, E, F>> _cacheBestIndividuals;
        private List<double> _cacheMeans;
        private double _cacheMean;

        public int PopulationSize { get => this._population.Size; set => new NotImplementedException(); }
        public int IndividualSize { get => this._population.Individuals [0].Size; set => throw new NotImplementedException(); }
        public int LimitGenerations { get => this._limitGenerations; set => this._limitGenerations = value; }

        public double CrossoverRate { get => this._crossoverRate; set => this._crossoverRate = value; }
        public double MutationRate { get => this._mutationRate; set => this._mutationRate = value; }

        public IPopulation<T, E, F> Population => this._population;
        public BIPopulation ObjPopulation { get => this._population; 
            set => this._population = (IPopulation<T, E, F>)value; }

        public int Generation => this._population.Generation;
        public IIndividual<T, E, F>? BestIndividual => this._bestIndividual;
        public BIIndividual? ObjBestIndividual => this._bestIndividual;
        public bool HasFinished => this._hasFinished;

        public double Mean => this._population.Mean;

        public string[] CacheGenerations => this._cacheGenerations.ToArray();
        public IIndividual<T, E, F>[] CacheBestIndividuals => this._cacheBestIndividuals.ToArray();
        public BIIndividual[] ObjCacheBestIndividuals => this._cacheBestIndividuals.ToArray();
        public double[] CacheMeans => this._cacheMeans.ToArray();

        public GeneticAlgorithm(IPopulation<T, E, F> population, int limitGenerations, double crossoverRate, double mutationRate,
            IFunction function, ISelectionMethod<T, E, F> selectionMethods, IOperator<T, E, F>[] operators, bool hasElitismo = false)
        {
            this._population = population;
            this._limitGenerations = limitGenerations;
            this._crossoverRate = crossoverRate;
            this._mutationRate = mutationRate;

            this._function = function;

            this._sMethod = selectionMethods;
            this._operators = operators;

            this._hasElitismo = hasElitismo;
            this._elitismo = new Elitismo<T, E, F>();

            this._bestIndividual = null;
            this._hasFinished = false;

            this._cacheGenerations = new List<string>();
            this._cacheBestIndividuals = new List<IIndividual<T, E, F>>();
            this._cacheMeans = new List<double>();
            this._cacheMean = 0;

            this._hasFinished = false;

            this.EvaluatePopulation();
            this._population.Generation++;
        }

        public virtual double CalcFitness(IIndividual<T, E, F> individual)
        {
            return this._function.Calc(individual);
        }

        public virtual bool EvaluatePopulation()
        {
            foreach(IIndividual<T, E, F> individual in this._population.Individuals)
                individual.Fitness = this.CalcFitness(individual);

            this.CacheGenerationInfo();
            IIndividual<T, E, F> localBestIndividual = this._population.CacheBestIndividual;

            if (this._bestIndividual == null ||
                this._bestIndividual.Fitness < localBestIndividual.Fitness && !this._sMethod.IsMinimization ||
                localBestIndividual.Fitness < this._bestIndividual.Fitness && this._sMethod.IsMinimization)
            {
                this._bestIndividual = localBestIndividual;
            }

            return this.Generation < this.LimitGenerations;
        }

        public void Run()
        {
            IIndividual<T, E, F>[] individuals = new Individual<T, E, F>[2];
            while (!HasFinished)
            {
                this.RunStep(individuals);
                this._population.Generation++;
            }
        }

        public void RunStep()
        {
            IIndividual<T, E, F>[] individuals = new Individual<T, E, F>[2];

            this.RunStep(individuals);
            this._population.Generation++;
        }

        public void RunStep(IIndividual<T, E, F>[] individuals)
        {
            int eLimit;
            T[] chromosomes = new T[2];
            this._sMethod.SetupPopulation(this._population.Individuals);

            int i = 0;
            if (this._hasElitismo)
            {
                for(; i < 2; i++)
                    this._population.Individuals[i] =
                        this._elitismo.Proced(this._population.Individuals, this._sMethod.IsMinimization);   
            }

            for (; i < this.PopulationSize; i += 2)
            {
                individuals = this._sMethod.RunSelection(2); //!!! 2

                eLimit = this._operators.Length;
                for (int e = 0; e < eLimit; e++)
                {
                    chromosomes = this._operators[e].Apply(
                        new T[] { individuals[0].Chromosome, individuals[1].Chromosome} );
                }

                this._population.Individuals[i] = individuals[0];
                this._population.Individuals[i + 1] = individuals[1];
            }

            if (!this.EvaluatePopulation())
                this._hasFinished = true;
        }

        private void CacheGenerationInfo()
        {
            this._cacheGenerations.Add(this._population.ToString()); // executa bestindividual - busca
            this._cacheBestIndividuals.Add(this._population.CacheBestIndividual); // economiza busca (proxy?)
            this._cacheMeans.Add(this._population.Mean);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string generation in this.CacheGenerations)
                sb.Append(generation + "\n");

            return sb.ToString();
        }

    } // end : abstract class (AG)

} // end : namespace(*.Algoritmos)
