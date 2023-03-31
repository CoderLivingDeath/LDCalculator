using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMachine
{
    public class MathExpression
    {
        public string InFix { get; set; }

        public string[] PostFix { get; set; }

        public List<string> Tokens
        {
            get => MathParser.Parse(InFix).ToList();
        }

        public MathExpression(string expression)
        {
            InFix = expression.Replace(" ", string.Empty) ?? throw new ArgumentNullException(nameof(expression));

            PostFix = MathConverter.ConvertToPostfixNotation(expression);
        }
    }
}
