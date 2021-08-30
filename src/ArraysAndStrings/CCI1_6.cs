using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class CCI1_6
    {
        //1.6 Реализуйте метод для выполнения простейшего сжатия строк с использованием счетчика повторяющихся символов. Например, строка ааЬсссссааа превращается в а2Ыс5аЗ. Если ~сжатая» строка не становится короче исходной,
        //то метод возвращает исходную строку.Предполагается, что строка состоит
        //только из букв верхнего и нижнего регистра(a-z).

        //todo разобрать решение и сделать проще

        public static string CompressString(string input)
        {
            string output = input[0].ToString();
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (output[output.Length - 1] == input[i])
                {
                    count++;
                }
                else
                {
                    output += count.ToString();
                    output += input[i];
                    count = 1;
                }
            }

            output += count.ToString();

            if (output.Length >= input.Length)
            {
                return input;
            }
            else
            {
                return output;
            }
        }
    }
}
