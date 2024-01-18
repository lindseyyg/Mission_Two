using System;

public class DiceSimulator
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");

        Console.Write("How many dice rolls would you like to simulate? ");
        int numRolls = int.Parse(Console.ReadLine());

        // Create an instance of the DiceRoller class
        DiceRoller diceRoller = new DiceRoller();

        // Call the SimulateRolls method to get the array of results
        int[] results = diceRoller.SimulateRolls(numRolls);

        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");

        Console.WriteLine($"Total number of rolls = {numRolls}.\n");

        // Print the histogram
        for (int i = 2; i <= 12; i++)
        {
            // Calculate the percentage for each sum
            int percentage = results[i] * 100 / numRolls;

            // Create a string of asterisks to represent the percentage
            string asterisks = new string('*', percentage);

            // Print the result and the corresponding asterisks
            Console.WriteLine($"{i}: {asterisks}");
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}

public class DiceRoller
{
    public int[] SimulateRolls(int numRolls)
    {
        // Initialize an array to store the count of each sum (2 to 12)
        int[] results = new int[13]; // Index 0 is not used, results[2] to results[12] represent sums 2 to 12.

        // Create a random number generator
        Random random = new Random();

        // Simulate dice rolls
        for (int i = 0; i < numRolls; i++)
        {
            // Generate random values for two six-sided dice
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            // Calculate the sum of the two dice
            int sum = dice1 + dice2;

            // Increment the count for the corresponding sum
            results[sum]++;
        }

        // Return the array of results
        return results;
    }
}