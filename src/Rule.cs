using System;
using System.Collections.Generic;
using System.Linq;

namespace Prolog
{
    public class Rule
    {
        public List<Fact> FactList { get; private set; }

        public Fact getFirst()
        {
            return this.FactList.First();
        }

        public Fact getResult()
        {
            return this.FactList.Last();
        }
    }
}