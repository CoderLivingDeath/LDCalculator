namespace StackMachine
{
    public static class MathConverter
    {
        public static string[] ConvertToPostfixNotation(string input, MathConvertParametrs? parametrs = null)
        {
            parametrs = parametrs ?? MathConvertParametrs.DefaultParameters;
            input = input.Replace(" ", string.Empty);

            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();

            foreach (string c in MathParser.Parse(input, parametrs.Separators.ToList()))
            {
                if (parametrs.Separators.Contains(c))
                {
                    if (stack.Count > 0 && !IsOpenOperationConvolution(c))
                    {
                        if (IsCloseOperationConvolution(c))
                        {
                            string s = stack.Pop();
                            while (!IsOpenOperationConvolution(s))
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) > GetPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated.ToArray();

            bool IsOpenOperationConvolution(string value)
            {
                foreach (var item in parametrs.ConvolutionOpen)
                {
                    if (item.Equals(value)) return true;
                }
                return false;
            }

            bool IsCloseOperationConvolution(string value)
            {
                foreach (var item in parametrs.ConvolutionClose)
                {
                    if (item.Equals(value)) return true;
                }
                return false;
            }
        }
        private static byte GetPriority(string s) //TODO убрать
        {
            switch (s)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 4;
            }
        }
    }
}
