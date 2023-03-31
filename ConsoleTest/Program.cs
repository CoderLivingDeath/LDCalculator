using StackMachine;
using System.Linq;

string str = "2+2*2+(10*10-(10*10))+(100+(10*10))";
Console.WriteLine(str);

string[] str2 = MathConverter.ConvertToPostfixNotation(str);

foreach (var item in str2)
{
    Console.Write(item + " ");
}

Console.WriteLine();

Console.WriteLine(StackMachineCalculator.result(str));