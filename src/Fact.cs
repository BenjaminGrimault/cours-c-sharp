using System.Collections.Generic;
using System.Linq;

namespace Prolog
{
    public class Fact
    {
        public Atom Name { get; private set; }
        public List<Atom> Parameters { get; private set; }
        
        public Fact(Atom[] parameters)
        {
            this.Name = parameters.First();
            this.Parameters = new List<Atom>(parameters.Skip(1));
        }
    }
}