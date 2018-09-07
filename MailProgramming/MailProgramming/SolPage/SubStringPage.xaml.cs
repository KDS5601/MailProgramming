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
    public partial class SubStringPage : ContentPage
    {
        public SubStringPage()
        {
            InitializeComponent();

            myEntry.Completed += MyEntryCompleted;
        }

        private void MyEntryCompleted(object sender, EventArgs e)
        {
            InputLabel.Text = myEntry.Text;
            string myString = myEntry.Text;
            OutputLabel.Text = LongestSubstring.FindSubSting(ref myString);

            myEntry.Text = null;
        }
    }
}