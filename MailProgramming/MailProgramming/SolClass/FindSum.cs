using System;
using System.Collections.Generic;
using System.Text;

using static MailProgramming.SubClass.Sorter;

namespace MailProgramming.SolClass
{
    public class SumFinder
    {
        public bool FindIndex(ref List<int> intList_r, ref int targetNumber_p, out int first, out int second)
        {
            first = 0;
            second = 0;

            if (intList_r.Count <= 1)
            {
                return false;
            }

            QuickSorting(ref intList_r);

            for (int i = 0; i < intList_r.Count - 1; ++i)
            {
                for (int j = 1; j < intList_r.Count; ++j)
                {
                    if (intList_r[i] + intList_r[j] == targetNumber_p)
                    {
                        first = intList_r[i];
                        second = intList_r[j];
                        return true;
                    }
                }
            }
            return false;            
        }
    }
}
