using System;
using System.Collections.Generic;
using System.Text;

using static MailProgramming.SubClass.Sorter;

namespace MailProgramming.SolClass
{
    public class SeconderyLargeNumber
    {
        /*
         * 정수 배열(int array)이 주어지면 두번째로 큰 값을 프린트하시오.
         * Given an integer array, find the second largest element.
         * 
         * 예제)
         * Input: [10, 5, 4, 3, -1]
         * Output: 5
         * 
         * Input: [3, 3, 3]
         * Output: Does not exist.
         */

        public (bool, int) GetAndFind(ref List<int> inputList_p)
        {
            ///<summary>
            ///bool과 int를 동시 반환
            ///bool이 True일때, int값 : 2번째로 큰 숫자
            ///bool이 False일때, int값 : 오류코드
            ///
            /// 오류코드 목록
            /// -1 : 알수없는 오류
            /// 0 : 2번째로 큰 숫자가 2개이상 존재
            /// 1 : 입력된 int리스트가 2개 미만
            /// </summary>
            /// 

            if (inputList_p.Count < 2)
            {
                return (false, 1);
            }

            QuickSorting(ref inputList_p);

            int TempNum = inputList_p[inputList_p.Count - 2];
            int i = 0;
            foreach (int index in inputList_p)
            {
                if (index == TempNum)
                {
                    ++i;
                }
            }

            if (i > 1)
            {
                return (false, 0);
            }
            else if (i == 1)
            {
                return (true, TempNum);
            }
            else
            {
                return (false, -1);
            }
        }
    }
}
