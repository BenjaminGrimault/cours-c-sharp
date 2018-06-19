namespace Prolog.Model
{
    public class Variable : Expression
    {
        public Variable() {}

        public Variable(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; }

        public override string ToString()
        {
            return $"var:{Name}";
        }
    }
}