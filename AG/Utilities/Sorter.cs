using System;

namespace GA.Utilities
{
    public class Sorter
    {
        public int cacheSort;
        private Random _generator;

        public Sorter()
        {
            this._generator = new Random();
        }

        public bool SortBinary()
        {
            return (this._generator.Next(2) < 1? false : true);
        }

        public double SortContinue(double lInf, double lSup)
        {
            return this._generator.NextDouble() * (lSup - lInf) + lInf;
        }

        // inclusivo
        public int SortBefore(int last)
        {
            return cacheSort = this._generator.Next(last + 1);
        }

        public int SortAfter(int first)
        {
            return this._generator.Next() + first;
        }

        public int SortBetween(int first, int last)
        {
            return this._generator.Next(last - first + 1) + first;
        }

    } // end : Sorter

} // end : namespace (.Utilities)
