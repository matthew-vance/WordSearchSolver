using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordSearchSolver;

namespace WordSearchSolverApp
{
    public static class OutputGenerator
    {
        public static string Generate(WordSearch wordSearch)
        {
            var wordStringBuilder = new StringBuilder();
            wordSearch.Words.Where(w => w.Location != null).ToList()
                .ForEach(w => wordStringBuilder.AppendLine(CreateWordString(w)));

            return wordStringBuilder.ToString();
        }

        private static string CreateWordString(Word word)
        {
            var wordStrings = new List<string>();
            word.Location.ToList().ForEach(c => wordStrings.Add($"({c.Column},{c.Row})"));

            return $"{word.Text}: {string.Join(',', wordStrings)}";
        }
    }
}
