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
            string myString = Console.ReadLine();
            Console.WriteLine(StringReverseForEachWord.GetAndReverse(myString));
            Console.ReadKey();
        }
    }
}
