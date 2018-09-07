using System;
using System.Collections.Generic;
using System.Text;

namespace MailProgramming.SolClass
{
    /*
     * String이 주어지면, 중복된 char가 없는 가장 긴 서브스트링 (substring)의 길이를 찾으시오. 
     * Given a string, find the longest substring that does not have duplicate characters.
     */

    static class LongestSubstring
    {
        static public string FindSubSting(ref string target_p)
        {
            ///<summary>
            ///정상 반환 : charList
            ///오류 발생 : null
            /// </summary>
            /// 

            List<char> CharList = new List<char>();
            List<char> LongChar = new List<char>();

            //이하 방어코드
            if (target_p == null || target_p.Length <= 1)
            {
                return null;
            }

            CharList.Add(target_p[0]);

            for (int i = 1; i < target_p.Length; i++)
            {
                if (!OverLapChack(target_p[i], ref CharList))
                {
                    CharList.Clear();
                }
                else
                {
                    CharList.Add(target_p[i]);
                }

                if (CharList.Count >= LongChar.Count)
                {
                    LongChar.Clear();

                    foreach (char index in CharList)
                    {
                        LongChar.Add(index);
                    }
                }
            }
            return string.Concat(LongChar);
        }

        static bool OverLapChack(char Index, ref List<char> CharList)
        {
            ///<summary>
            /// 중복이 있거나 오류가 있을시 : false
            /// 중복된 문자가 없을 경우 : true
            /// </summary>
            /// 

            if (CharList == null)
            {
                return false;
            }

            foreach (char j in CharList)
            {
                if (j == Index)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
