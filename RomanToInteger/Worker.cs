namespace RomanToInteger
{
    public class Worker
    {
        public Worker()
        {
            Work();
        }
        public void Work()
        {
            try
            {
                Console.Write("Roman: ");
                ReadOnlySpan<char> roman = Console.ReadLine().ToUpper().AsSpan();
                int english = ConvertRomanToEnglish(roman);
                Console.WriteLine($"English: {english}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int ConvertRomanToEnglish(ReadOnlySpan<char> romanSpan)
        {
            int value = 0;
            for (int i = 0; i < romanSpan.Length; i++)
            {
                var current = GetRomanValue(romanSpan[i]);
                var next = (i != romanSpan.Length - 1) ? GetRomanValue(romanSpan[i + 1]) : 0;

                if (current < next)
                {
                    value += (next - current);
                    i++;
                    continue;
                }
                value += current;
            }
            return value;
        }

        public int GetRomanValue(char roman)
        {
            return roman switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }
    }
}
