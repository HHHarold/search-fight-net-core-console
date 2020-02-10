using SearchFight.IServices;
using SearchFight.Models;
using System;
using System.Linq;

namespace SearchFight.ConsoleProgram
{
    public class ConsoleApplication
    {
        private readonly ISearchEngineFight _searchEngineFight;

        public ConsoleApplication(ISearchEngineFight searchEngineFight)
        {
            _searchEngineFight = searchEngineFight;
        }

        public void Run(string[] args)
        {
            if (args.Length > 0)
            {
                var result = _searchEngineFight.GetResult(args.ToList());

                PrintResults(result);
            }
            else
            {
                Console.WriteLine("No arguments");
                Console.ReadLine();
            }            
        }

        private void PrintResults(SearchFightResult result)
        {
            if (result != null)
            {
                for (int i = 0; i < result.SearchEngineValueResults.Count; i++)
                {
                    Console.WriteLine($"\nSearched value: {result.SearchEngineValueResults[i].Value}");
                    for (int j = 0; j < result.SearchEngineValueResults[i].SearchEngineMatchResults.Count; j++)
                    {
                        Console.WriteLine($"    {result.SearchEngineValueResults[i].SearchEngineMatchResults[j].TotalNumberMatches} - {result.SearchEngineValueResults[i].SearchEngineMatchResults[j].SearchEngineName}");
                    }
                }
                Console.WriteLine("\nWinners:");
                Console.WriteLine($"Google winner: {result.GoogleWinner}");
                Console.WriteLine($"Bing winner: {result.BingWinner}");
                Console.WriteLine($"Total winner: {result.TotalWinner}");

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Something is wrong");
                Console.ReadLine();
            }
        }
    }
}
