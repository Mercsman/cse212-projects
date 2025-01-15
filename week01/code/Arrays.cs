public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create array to hold the multiples
        double[] multiples = new double[length];

        // Fill array with multiples of number
        for (int i = 0; i < length; i++) {
            // Calculate each multiple
            multiples[i] = number * (i + 1);
        }

        // Return arrays with multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // In case of empty array
        if (data.Count == 0 || amount == 0) {
            return;
        }

        // Normalize amount if amount is greater than list
        amount = amount % data.Count;
        if (amount == 0) {
            return;
        }

        // Split list into 2
        // Last amount elements
        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        // The first data.Count - amount elements
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        // Combine the two parts, last part coming first
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
