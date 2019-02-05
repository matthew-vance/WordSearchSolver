using System;
using WordSearchSolver;

namespace WordSearchSolverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("A file path must be provided.");
                Exit();
            }

            var path = args[0];
            var fileProcessor = new FileProcessor();
            var wordSearch = fileProcessor.Process(path);

            var solver = new Solver();
            solver.Solve(wordSearch);

            var output = OutputGenerator.Generate(wordSearch);
            Console.WriteLine(output);
            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
