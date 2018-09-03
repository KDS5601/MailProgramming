using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MailProgramming.SolClass;

namespace MailProgramming.SolPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeconderyLargeNumberPage : ContentPage
    {
        List<int> intList = new List<int>();

        public SeconderyLargeNumberPage()
        {
            InitializeComponent();
            backButton.Clicked += async (sender, e) =>
            await Navigation.PopAsync();
            resetButton.Clicked += (sender, e) =>
            {
                intList.Clear();
                ArrayLabel.Text = null;
                OutputLabel.Text = null;
            };

            ArrEntry.TextChanged += EntryTextChanged;
            ArrEntry.Completed += ArrEntryCompleted;
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

            ////////??

            SeconderyLargeNumber finder = new SeconderyLargeNumber();
            (bool resurtbool, int resurtint) = finder.GetAndFind(ref intList);

            if (!resurtbool)
            {
                switch (resurtint)
                {
                    case -1:
                        OutputLabel.Text = "알 수 없는 오류";
                        break;
                    case 0:
                        OutputLabel.Text = "2번째로 큰 숫자가 2개이상 존재";
                        break;
                    case 1:
                        OutputLabel.Text = "입력된 숫자가 너무 적습니다.";
                        break;
                    default:
                        break;
                }
            }
            if (resurtbool)
            {
                OutputLabel.Text = "찾은 숫자 : " + resurtint;
            }
        }
    }
}