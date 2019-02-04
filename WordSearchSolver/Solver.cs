﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class Solver
    {
        private readonly IWordFinder _wordFinder;

        public Solver(IWordFinder wordFinder = null)
        {
            _wordFinder = wordFinder ?? new DefaultWordFinder();
        }
    }
}
