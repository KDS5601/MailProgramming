using System;
using System.Collections.Generic;
using System.Text;

namespace MailProgramming.SolClass
{
    public static class StringReverseForEachWord
    {
        // 문제
        // 주어진 string 에 모든 단어를 거꾸로 하시오.
        // 
        // Input: “abc 123 apple”
        // Output: “cba 321 elppa”

        // 조건분석
        // string엔 ' '이 발생
        // 공백을 기준으로 단어를 분리하여 뒤집기

        public static string GetAndReverse(string string_p)
        {
            List<char> reverseString = new List<char>();
            char[] charArr = new char[string_p.Length];

            if (string_p == null)
            {
                return null;
            }

            int minInRoop = 0;
            int maxInRoop = 0;

            ///문자열 뒤집기
            for (int i = 0; i <= string_p.Length - 1; ++i)
            {
                if (string_p[i] == ' ' || i == string_p.Length - 1)
                {
                    maxInRoop = i;

                    if (i == string_p.Length - 1)
                    {
                        ++maxInRoop;
                    }

                    for (int j = 0; j < maxInRoop - minInRoop; ++j)
                    {
                        charArr[minInRoop + j] = (string_p[maxInRoop - j - 1]);
                    }

                    if (i != string_p.Length - 1)
                    {
                        charArr[maxInRoop] = ' ';
                    }

                    minInRoop = i + 1;
                }
            }

            return new string(charArr);
        }
    }
}
