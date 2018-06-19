namespace Prolog.Model
{
    public class Atom : Expression
    {
        public string Name { get; }

        public Atom() {}

        public Atom(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"atom:{Name}";
        }
    }
}