using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MailProgramming.SolClass;

using static MailProgramming.SolClass.FindSum;

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
        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(int.TryParse(e.NewTextValue, out int i)))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }

    }
}