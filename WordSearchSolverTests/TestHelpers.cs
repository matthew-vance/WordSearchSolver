using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolver;

namespace WordSearchSolverTests
{
    internal static class TestHelpers
    {
        public static WordSearch GetMockWordSearch()
        {
            var wordsList = new List<Word>();
            var words = new string[] { "BONES", "CHEKOV", "KHAN", "KIRK", "SCOTTY", "SPOCK", "SULU", "UHURA", "COMPUTER"};
            foreach (var word in words)
            {
                wordsList.Add(new Word(word));
            }
            var puzzle = new char[,] { {'U','M','K','H','U','L','K','I','N','V','J','O','C','W','E'},
                                 {'L','L','S','H','K','Z','Z','W','Z','C','G','J','U','Y','G'},
                                 {'H','S','U','P','J','P','R','J','D','H','S','B','X','T','G'},
                                 {'B','R','J','S','O','E','Q','E','T','I','K','K','G','L','E'},
                                 {'A','Y','O','A','G','C','I','R','D','Q','H','R','T','C','D'},
                                 {'S','C','O','T','T','Y','K','Z','R','E','P','P','X','P','R'},
                                 {'B','L','Q','S','L','N','E','E','E','V','U','L','F','E','Z'},
                                 {'O','K','R','I','K','A','M','M','R','M','F','B','T','P','P'},
                                 {'N','U','I','I','Y','H','Q','M','E','M','Q','U','Y','F','S'},
                                 {'E','Y','Z','Y','G','K','Q','J','P','C','P','W','Y','A','K'},
                                 {'S','J','F','Z','M','Q','I','B','D','M','E','M','K','W','D'},
                                 {'T','G','L','B','H','C','B','E','O','H','T','O','Y','I','K'},
                                 {'O','J','Y','E','U','L','N','C','C','L','Y','B','Z','U','H'},
                                 {'W','Z','M','I','S','U','K','U','R','B','I','D','U','X','S'},
                                 {'K','Y','L','B','Q','Q','P','M','D','F','C','K','E','A','B'}
            };
            return new WordSearch(wordsList, puzzle);
        }
    }
}
