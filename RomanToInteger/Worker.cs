using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int ConvertRomanToEnglish(ReadOnlySpan<char> roman)
        {
            int value = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                var current = roman[i];
                var next = (i != roman.Length - 1) ? roman[i + 1] : ' ';

                if (IsRomanPrefix(current, next))
                {
                    value += GetPrefixValue(current, next);
                    i++; // Skipping next iteration
                    continue;
                }
                value += GetRomanValue(current);
            }
            return value;
        }

        public bool IsRomanPrefix(char current, char next)
        {
            return (current, next) switch
            {
                ('I', 'V') => true,
                ('I', 'X') => true,
                ('X', 'L') => true,
                ('X', 'C') => true,
                ('C', 'D') => true,
                ('C', 'M') => true,
                _ => false
            };
        }

        public int GetPrefixValue(char current, char next)
        {
            return (current, next) switch
            {
                ('I', 'V') => 4,
                ('I', 'X') => 9,
                ('X', 'L') => 40,
                ('X', 'C') => 90,
                ('C', 'D') => 400,
                ('C', 'M') => 900,
                _ => 0
            };
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
