using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Define the number of random variates (N) and the number of class intervals (k).
        int N = 1000;
        int k = 10;

        // Initialize a random number generator.
        Random random = new Random();

        // Initialize an array to store the counts for each class interval.
        int[] counts = new int[k];

        // Generate random variates and count them in class intervals.
        for (int i = 0; i < N; i++)
        {
            double randomValue = random.NextDouble(); // Generate a random value in [0,1).
            int interval = (int)(randomValue * k);    // Determine the interval index.
            counts[interval]++;                        // Increment the count for the interval.
        }

        // Display the counts for each class interval.
        Console.WriteLine("Class Intervals and Counts:");
        for (int i = 0; i < k; i++)
        {
            double lowerBound = (double)i / k;
            double upperBound = (double)(i + 1) / k;
            Console.WriteLine($"[{lowerBound:f2}, {upperBound:f2}): {counts[i]}");
        }
    }
}
