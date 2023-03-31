namespace StackMachine
{
    public class StackMachineParametres
    {
        public readonly List<MathOperator> operatorList;

        public IEnumerable<string> Separators
        {
            get
            {
                foreach (var op in operatorList)
                {
                    if (op is MathOperatorConvolution)
                    {
                        yield return (op as MathOperatorConvolution).Close;
                    }
                    yield return op.Id;
                }
            }
        }

        public IEnumerable<MathOperatorConvolution> ConvolutionOperators
        {
            get
            {
                foreach (var op in operatorList)
                {
                    if (op is MathOperatorConvolution)
                        yield return op as MathOperatorConvolution ?? throw new NullReferenceException(nameof(op));
                }
            }
        }

        public IEnumerable<string> ConvolutionOpen
        {
            get
            {
                foreach (var op in ConvolutionOperators)
                {
                    yield return op.Id;
                }
            }
        }

        public IEnumerable<string> ConvolutionClose
        {
            get
            {
                foreach (var op in ConvolutionOperators)
                {
                    yield return op.Close;
                }
            }
        }

        public static readonly List<MathOperator> DefaultOperators = new List<MathOperator>
        {
            new MathOperatorConvolution("(", ")", 0),
            new MathOperator("+", MathOperator.AddOperation, 1),
            new MathOperator("-",MathOperator.SubOperation, 1),
            new MathOperator("*",MathOperator.MultOperation, 2),
            new MathOperator("/",MathOperator.DivOperation, 2),
            new MathOperator("%",MathOperator.ModOperation, 2),
            new MathOperator("^",MathOperator.PowOperation, 3),
        };

        public static readonly StackMachineParametres DefaultParameters = new StackMachineParametres(DefaultOperators);


        public StackMachineParametres(List<MathOperator>? operators = null)
        {
            operatorList = operators ?? DefaultOperators;
        }

        public MathOperator GetOperation(string str)
        {
            foreach (var item in operatorList)
            {
                if(item is MathOperatorConvolution)
                {
                    continue;
                }
                if(item.Id == str)
                {
                    return item;
                }
            }
            throw new Exception("Operation not found. " + nameof(str));
        }
    }
}