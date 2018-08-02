using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MailProgramming.SolClass;

namespace MailProgramming
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindSum : ContentPage
    {
        /// <summary>
        /// 문제 : 
        /// 정수 배열과 타겟 숫자가 주어지면, 합이 타겟값이 되는 두 원소의 인덱스를 찾으시오. 
        /// </summary>
        /// 

        List<int> intList = new List<int>();
        int targetNumber = new int();

        public FindSum()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backButton.Clicked += async (sender, e) =>
            await Navigation.PopAsync();
            resetButton.Clicked += (sender, e) =>
            {
                intList.Clear();
                targetNumber = 0;
                ArrayLabel.Text = null;
                FindNumLabel.Text = null;
                OutputLabel.Text = null;
            };

            ArrEntry.TextChanged += EntryTextChanged;
            FindNumEntry.TextChanged += EntryTextChanged;

            ArrEntry.Completed += ArrEntryCompleted;
            FindNumEntry.Completed += FindNumEntryCompleted;
        }

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
            {
                // Completed시 NewTextValue가 null값으로 extChanged하여 진입함
                return;
            }
            else if (e.NewTextValue == "")
            {
                ((Entry)sender).Text = "";
            }
            else if (!(int.TryParse(e.NewTextValue, out int i)))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }

        private void ArrEntryCompleted(object sender, EventArgs e)
        {
            intList.Add(Convert.ToInt32(((Entry)sender).Text));
            ((Entry)sender).Text = null; //null값으로 TextChanged호출됨 !!

            ArrayLabel.Text += (intList[intList.Count - 1] + " ");
        }

        private void FindNumEntryCompleted(object sender, EventArgs e)
        {
            targetNumber = Convert.ToInt32(((Entry)sender).Text);
            ((Entry)sender).Text = null; //null값으로 TextChanged호출됨 !!

            SumFinder finder = new SumFinder();
            if (finder.FindIndex(ref intList, ref targetNumber, out int first, out int second))
            {
                OutputLabel.Text = "찾을 숫자 : " + targetNumber + "\n첫번째 숫자 : " + first + " 두번째 숫자 : " + second;
            }
            else
            {
                OutputLabel.Text = "해당 숫자를 찾을 수 없습니다.\n" + "해당 숫자 : " + targetNumber;
            }
        }
    }
}