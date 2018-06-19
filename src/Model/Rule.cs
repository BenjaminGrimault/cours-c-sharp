namespace Prolog.Model
{
    public class Rule : Expression
    {
        public Rule() {}

        public Rule(Expression condition, Fact result)
        {
            this.Condition = condition;
            this.Result = result;
        }

        public Expression Condition { get; }

        public Fact Result { get; }

        public override string ToString()
        {
            return $"rule {Condition} -> {Result}";
        }
    }
}