using System;
using System.IO;
using LinqInManhattan.JsonClasses;
using Newtonsoft.Json;

namespace LinqInManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataPath = @"..\..\..\..\data.json";
            string horizontalLine = new string('\u2550', Console.WindowWidth - 1);

            FeatureCollection fc = JsonConvert.DeserializeObject<FeatureCollection>(
                File.ReadAllText(dataPath));

            // Display all of the neighborhoods mentioned in data.json
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"All neighborhoods in {dataPath}:");
            Console.WriteLine(horizontalLine);

            Console.ForegroundColor = ConsoleColor.White;
            string[] neighborhoods = fc.GetAllNeighborhoods();
            DisplayStringsInTwoColumns(neighborhoods);
            Console.Clear();

            // Display all of the non-empty neighborhoods in data.json
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"All non-empty neighborhoods in {dataPath}:");
            Console.WriteLine(horizontalLine);

            Console.ForegroundColor = ConsoleColor.White;
            neighborhoods = fc.GetAllNonEmptyNeighborHoods();
            DisplayStringsInTwoColumns(neighborhoods);
            Console.Clear();

            // Display all of the unique, non-empty neighborhoods in data.json
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"All unique, non-empty neighborhoods in {dataPath}:");
            Console.WriteLine(horizontalLine);

            Console.ForegroundColor = ConsoleColor.White;
            neighborhoods = fc.GetAllUniqueNonEmptyNeighborhoods();
            DisplayStringsInTwoColumns(neighborhoods);
            Console.Clear();

            // Display all of the unique, non-empty neighboords in data.json as one single query
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"All unique, non-empty neighborhoods in {dataPath} as one query:");
            Console.WriteLine(horizontalLine);

            Console.ForegroundColor = ConsoleColor.White;
            neighborhoods = fc.GetAllUniqueNonEmptyNeighborhoodsConsolidated();
            DisplayStringsInTwoColumns(neighborhoods);
            Console.Clear();
        }

        /// <summary>
        /// Pretty prints an array of strings in two columns, scaled to the
        /// dimensions of the user's console
        /// </summary>
        /// <param name="strings">An array of strings to display</param>
        static void DisplayStringsInTwoColumns(string[] strings)
        {
            string horizontalLine = new string('\u2550', Console.WindowWidth - 1);

            for (int i = 0; i < strings.Length; i += 2)
            {
                // When we have reached the end of the output buffer, allow the user
                // to press a key to paginate the results.
                if (i > 0 && i % ((Console.WindowHeight - 4) * 2) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(horizontalLine);
                    Console.Write("Please press a key to display the remaining results...");
                    Console.ReadKey(true);

                    Console.Clear();
                    Console.WriteLine("Continued...");
                    Console.WriteLine(horizontalLine);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(strings[i]);

                // Every other string will be shifted over half of the screen width
                if (i + 1 < strings.Length)
                {
                    Console.CursorLeft = Console.WindowWidth / 2;
                    Console.WriteLine(strings[i + 1]);
                }
            }

            // End of each array message displayed in green to grab user's attention
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(horizontalLine);
            Console.Write("All results displayed. Please press a key for next demo...");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
