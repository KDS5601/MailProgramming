using System;
using System.Collections.Generic;
using System.Text;

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
                for (int j = 0; j < intList_r.Count; ++j)
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

        private void QuickSorting(ref List<int> intList_r, int left, int right)
        {
            int i = left, j = right;
            int pivot = intList_r[(left + right) / 2];
            int temp;

            do
            {
                while (intList_r[i] < pivot)
                    i++;
                while (intList_r[j] > pivot)
                    j--;
                if (i <= j)
                {
                    temp = intList_r[i];
                    intList_r[i] = intList_r[j];
                    intList_r[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j)
                QuickSorting(ref intList_r, left, j);

            if (i < right)
                QuickSorting(ref intList_r, i, right);
        }

        private void QuickSorting(ref List<int> intList_r)
        {
            QuickSorting(ref intList_r, 0, intList_r.Count - 1);
        }


    }
}
