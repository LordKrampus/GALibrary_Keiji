namespace GALibrary.Structures.BasicInterfaces
{
    public interface BIGeneric
    {
        /// <summary>
        /// Gets an Specífic Type in array. It´s nice for reduce complexities of out this looking type generics.
        /// </summary>
        /// <param name="length">Size of the array.</param>
        /// <returns>An array for objects like this.</returns>
        public object[] GenerateArray(int length);

        /// <summary>
        /// Constructor withou generics means.
        /// </summary>
        /// <param name="arguments">Semantic arguments.</param>
        /// <returns>A new object like this.</returns>
        public object New(object[] arguments);
    }
}
