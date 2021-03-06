﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MailProgramming.SolPage;

namespace MailProgramming
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            NaviButton toChackPalindrome = new NaviButton("숫자 회문 체크");
            toChackPalindrome.Clicked += async (sender, e) => await Navigation.PushAsync(new ChackPalindrome());
            NaviButton toFibonacciSQ = new NaviButton("짝수 피보나치수열 합");
            toFibonacciSQ.Clicked += async (sender, e) => await Navigation.PushAsync(new FibonacciSQ());
            NaviButton toFindSum = new NaviButton("배열중 합이 되는 숫자 찾기");
            toFindSum.Clicked += async (sender, e) => await Navigation.PushAsync(new FindSum());
            NaviButton toStringReverseForEachWordPage = new NaviButton("문자열 단어별로 뒤집기");
            toStringReverseForEachWordPage.Clicked += async (sender, e) => await Navigation.PushAsync(new StringReverseForEachWordPage());
            NaviButton toSeconderyLargeNumberPage = new NaviButton("배열에서 두번째로 큰 숫자 찾기");
            toSeconderyLargeNumberPage.Clicked += async (sender, e) => await Navigation.PushAsync(new SeconderyLargeNumberPage());
            NaviButton toSubStringPage = new NaviButton("문자 열 내에서 중복되지 않는 가장 긴 문자열");
            toSubStringPage.Clicked += async (sender, e) => await Navigation.PushAsync(new SubStringPage());


            contentStack.Children.Add(toChackPalindrome);
            contentStack.Children.Add(toFibonacciSQ);
            contentStack.Children.Add(toFindSum);
            contentStack.Children.Add(toStringReverseForEachWordPage);
            contentStack.Children.Add(toSeconderyLargeNumberPage);
            contentStack.Children.Add(toSubStringPage);
        }

        private sealed class NaviButton : Button
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