namespace Prolog.Model
{
    public class BinaryExpression : Expression
    {
        public BinaryExpression() {}

        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public int Id { get; set; }

        public Expression Left { get; }

        public Expression Right { get; }

        public override string ToString()
        {
            return $"({Left} And {Right})";
        }
    }
}