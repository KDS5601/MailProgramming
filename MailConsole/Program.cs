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
            List<int> intList = new List<int>();
            int findNum = 0;
            SumFinder finder = new SumFinder();

            Console.WriteLine("수열의 원소를 입력하시오. 공란 입력시 다음단계로 넘어갑니다.");
            for (; ; )
            {
                string myString = Console.ReadLine();
                if (int.TryParse(myString, out int i))
                {
                    intList.Add(i);
                }
                else if (myString == null || myString == "")
                {
                    break;
                }
            }
            Console.WriteLine("찾을 숫자를 입력하시오. 숫자가 입력될 때까지 입력을 받습니다.");
            for(; ; )
            {
                if (int.TryParse(Console.ReadLine(), out findNum))
                {
                    break;
                }
            }

            if(finder.FindIndex(ref intList, ref findNum,out int first, out int second))
            {
                Console.WriteLine("첫번째 인자 : " + first + "두번째 인자 : " + second);
            }
            else
            {
                Console.WriteLine("입력하신 숫자를 찾지 못하였습니다.");
            }
            Console.ReadKey();
        }
    }
}
