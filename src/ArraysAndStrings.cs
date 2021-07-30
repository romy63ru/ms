// Реализуйте алгоритм, определяющий, все ли символы в строке встречаются
// только один раз. А если при этом запрещено использование дополнительных
// структур данных?

using System;

namespace src
{
    public class ArraysAndStrings
    {
        // Реализуйте алгоритм, определяющий, все ли символы в строке встречаются
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
    }
}