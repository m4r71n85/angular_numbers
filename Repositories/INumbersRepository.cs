namespace numbers.Repositories
{
    /// <summary>
    /// Service layer allowing working with numbers and storing them to memory
    /// </summary>
    public interface INumbersRepository
    {
        /// <summary>
        /// Clears memory from all generated numbers
        /// </summary>
        void ClearNumbers();

        /// <summary>
        /// Generates random number and adds it to memory
        /// </summary>
        /// <returns>Generated number</returns>
        int GetRandomNumber();

        /// <summary>
        /// Returns all numbers from memory in json string format
        /// </summary>
        /// <returns>All generated numbers</returns>
        string GetStored();

        /// <summary>
        /// Calculates the sum of all numbers in memory
        /// </summary>
        /// <returns>The sym of all numbers in memory</returns>
        int GetSum();

        /// <summary>
        /// Saves a number to memory
        /// </summary>
        /// <param name="randomNumber">The number that should be saved</param>
        void SaveNumberToMemory(int randomNumber);
    }
}