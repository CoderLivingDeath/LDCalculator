namespace StackMachine
{
    public class MathConvertParametrs
    {
        public readonly List<MathOperator> operatorList;

        public IEnumerable<string> Separators
        {
            get
            {
                foreach (var op in operatorList)
                {
                    if(op is MathOperatorConvolution)
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
            { foreach (var op in operatorList)
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
                foreach(var op in ConvolutionOperators)
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

        public static readonly MathConvertParametrs DefaultParameters = new MathConvertParametrs(DefaultOperators);

        public MathConvertParametrs(List<MathOperator> operators)
        {
            operatorList = operators ?? throw new ArgumentNullException(nameof(operators));
        }
    }
}
