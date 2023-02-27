using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                string roman = Console.ReadLine();
                ConvertRomanToInteger(roman);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ConvertRomanToInteger(string roman)
        {
            var romanSpan = roman.AsSpan();
            int value = 0;
            bool skip = false;
            for (int i = 0; i < romanSpan.Length; i++)
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }

                var current = romanSpan[i];
                var next = (i != romanSpan.Length - 1) ? romanSpan[i + 1] : ' ';

                if (IsRomanPrefix(current, next))
                {
                    value += RomanPrefixValue(current, next);
                    skip = true;
                    continue;
                }
                value += RomanValue(current);
            }
            Console.WriteLine(value);
        }

        public bool IsRomanPrefix(char current, char next)
        {
            bool isPrefix = string.Join("", new[] { current, next }) switch
            {
                "IV" => true,
                "IX" => true,
                "XL" => true,
                "XC" => true,
                "CD" => true,
                "CM" => true,
                _ => false
            };
            return isPrefix;
        }

        public int RomanPrefixValue(char current, char next)
        {
            int value = string.Join("", new[] { current, next }) switch
            {
                "IV" => 4,
                "IX" => 9,
                "XL" => 40,
                "XC" => 90,
                "CD" => 400,
                "CM" => 900,
                _ => 0
            };
            return value;
        }

        public int RomanValue(char roman)
        {
            int value = char.ToUpper(roman) switch
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
            return value;
        }
    }
}
