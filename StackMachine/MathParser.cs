namespace StackMachine
{
    public static class MathParser
    {
        public static readonly List<string> DefaultSeparators = new List<string>
        {
            "+", "-", "*", "/", "%", "(",")","^"
        };

        public static IEnumerable<string> Parse(string input, List<string> separators = null)
        {
            separators ??= DefaultSeparators;
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!separators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
    }
}
