namespace StackMachine
{
    public class MathOperator
    {
        public string Id { get; set; }

        public byte Priority { get; set; }

        public Func<decimal, decimal, decimal> MathOperatorHandler;

        public decimal calculate(decimal left, decimal right)
        {
            return MathOperatorHandler.Invoke(left, right);
        }

        public MathOperator(string id, Func<decimal, decimal, decimal> operation, byte priority = 4)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            MathOperatorHandler = operation; // TODO
            Priority = priority;
        }

        public static decimal AddOperation(decimal left, decimal right)
        {
            return left + right;
        }
        public static decimal SubOperation(decimal left, decimal right)
        {
            return left - right;
        }
        public static decimal MultOperation(decimal left, decimal right)
        {
            return left * right;
        }
        public static decimal DivOperation(decimal left, decimal right)
        {
            return left / right;
        }
        public static decimal ModOperation(decimal left, decimal right)
        {
            return left % right;
        }
        public static decimal PowOperation(decimal left, decimal right)
        {
            return (decimal)Math.Pow((double)left, (double)right);
        }
    }

    public class MathOperatorConvolution : MathOperator
    {
        public string Close { get; set; }

        public MathOperatorConvolution(string open, string close, byte priority = 4, Func<decimal, decimal, decimal> operation = null) : base(open,operation, priority)
        {
            Close = close;
        }
    }
}
