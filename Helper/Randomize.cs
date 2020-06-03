using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Helper
{
    public sealed class Randomize
    {
        private static Randomize instance = null;
        private static readonly object padlock = new object();
        private static readonly Random rnd = new Random();

        public Random GetRandom { get { return rnd; } }

        static Randomize()
        {
            rnd = new Random();
        }
    }
}
