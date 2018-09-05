using System;
using System.Collections.Generic;
using MailProgramming.SolClass;

namespace MailConsole
{
    class Program
    {
        /// <summary>
        /// 알고리즘 테스트용 콘솔
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (; ; )
            {
                string myString = Console.ReadLine();

                List<char> myCharList = LongestSubstring.FindSubSting(ref myString);

                if (myCharList != null)
                {
                    foreach (char i in myCharList)
                    {
                        Console.Write(i);
                    }
                }

                Console.Write('\n');

                Console.ReadKey();
            }
        }
    }
}
