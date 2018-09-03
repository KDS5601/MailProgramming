using System;
using System.Collections.Generic;
using System.Text;

namespace MailProgramming.SubClass
{
    public static class Sorter
    {
        public static void QuickSorting(ref List<int> intList_r, int left, int right)
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

        public static void QuickSorting(ref List<int> intList_r)
        {
            QuickSorting(ref intList_r, 0, intList_r.Count - 1);
        }

    }
}
