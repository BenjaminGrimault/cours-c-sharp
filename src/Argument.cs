namespace Prolog
{
    public class Argument
    {
        public string Name { get; private set; }

        public Argument(string name)
        {
            this.Name = name;
        }
    }
}