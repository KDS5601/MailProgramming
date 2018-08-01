﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MailProgramming
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindSum : ContentPage
    {
        public FindSum()
        {
            List<int> intList = new List<int>();

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backButton.Clicked += async (sender, e) =>
            await Navigation.PopAsync();

            ArrEntry.TextChanged += EntryTextChanged;
            FindNumEntry.TextChanged += EntryTextChanged;

            ArrEntry.Completed += (sender, e) =>
            {
                ((Entry)sender).Text = null;
            };
        }

        public (bool result, int first, int seceond) FindIndex(ref List<int> intList_r, ref int targetNumber_p)
        {
            int a = 0, b = 0;
            bool result = false;

            if (intList_r.Count == 1)
            {
                return (false, 0, 0);
            }

            QuickSorting(ref intList_r);

            for (int i = 0; i < intList_r.Count - 2 ; ++i )
            {
                for (int j = 0; j < intList_r.Count -1; ++j)
                {
                    if (i + j == targetNumber_p)
                    {
                        result = true;
                        a = i; b = j;
                        goto ForOut;
                    }
                }
            }
            return (result, a, b);
            ForOut:;

            return (result, a, b);
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
            int left = intList_r[0];
            int right = intList_r[intList_r.Count - 1];

            QuickSorting(ref intList_r, left, right);
        }

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(int.TryParse(e.NewTextValue, out int i)))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }
}