using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StackMachine
{
    public static class StackMachineCalculator
    {
        public static decimal result(string input, StackMachineParametres? parametres = null)
        {
            parametres = parametres ?? new StackMachineParametres();

            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>(MathConverter.ConvertToPostfixNotation(input));

            string str = queue.Dequeue();
            while (queue.Count >= 0)
            {
                if (!parametres.Separators.Contains(str))
                {
                    stack.Push(str);
                    str = queue.Dequeue();
                }
                else
                {
                    decimal summ = 0;
                    try
                    {
                        MathOperator mathOperator = parametres.GetOperation(str);
                        decimal a = Convert.ToDecimal(stack.Pop());
                        decimal b = Convert.ToDecimal(stack.Pop());
                        summ = mathOperator.calculate(b, a);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    stack.Push(summ.ToString());
                    if (queue.Count > 0)
                        str = queue.Dequeue();
                    else
                        break;
                }

            }
            return Convert.ToDecimal(stack.Pop());
        }
    }
}
