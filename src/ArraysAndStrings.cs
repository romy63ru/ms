// Реализуйте алгоритм, определяющий, все ли символы в строке встречаются
// только один раз. А если при этом запрещено использование дополнительных
// структур данных?

using System;

namespace src
{
    public class ArraysAndStrings
    {
        // 1.1 Реализуйте алгоритм, определяющий, все ли символы в строке встречаются
        // только один раз. А если при этом запрещено использование дополнительных
        // структур данных?
        public static bool CheckString(string input)
        {
            if (input.Length > 0)
            {
                string buffer = input[0].ToString();
                for (int i = 1; i < input.Length; i++)
                {
                    for (int j = 0; j < buffer.Length; j++)
                    {
                        if (input[i] == buffer[j])
                        {
                            return false;
                        }
                    }
                    buffer += input[i];
                }
            }
            return true;
        }

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
                if (output[output.Length-1] == input[i])
                {
                    count++;
                } else
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