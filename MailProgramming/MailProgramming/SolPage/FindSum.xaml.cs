using System;
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
		public FindSum ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public (bool resurt, int first, int seceond) FindIndex(ref List<int> intList_r)
        {
            int a = 0, b = 0;
            bool resurt = false;



            return (resurt, a, b);
        }

        public void QuickSorting(ref List<int> intList_r)
        {

        }
    }
    

}