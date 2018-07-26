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
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
            NavigationPage.SetHasBackButton(this, false);
			InitializeComponent ();

            NaviButton toChackPalindrome = new NaviButton("숫자 회문 체크");
            toChackPalindrome.Clicked += async (sender, e) => await Navigation.PushAsync(new ChackPalindrome());

            contentStack.Children.Add(toChackPalindrome);
        }

        class NaviButton : Button
        {
            public NaviButton(string Name_p)
            {
                HeightRequest = 50;
                WidthRequest = 200;
                Text = Name_p;
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
                BackgroundColor = Color.Aqua;
            }
        }
    }
}