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
    public partial class FibonacciSQ : ContentPage
    {
        public FibonacciSQ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backButton.Clicked += async (sender, e) =>
            await Navigation.PopAsync();

            inputLabel.Text = "";

            Button[] inputNumberButtons = new Button[10];
            Button clearButton = new Button { Text = "clr" };

            List<UInt64> fibonocciSQList = new List<UInt64>();
            List<UInt64> evenFibonocciSQList = new List<UInt64>();

            const UInt64 maxNumber = 999_999_999_999_999;
            UInt64 chackNumber = 0;

            clearButton.Clicked += (sender, e) =>
            {
                inputLabel.Text = "";
                fibonacciSQLabel.Text = "0";
                evenFibonacciSQLabel.Text = "0";
                sumNumberLabel.Text = "0";
                fibonocciSQList.Clear();
                evenFibonocciSQList.Clear();
                chackNumber = 0;
            };

            for (int i = 0; i < 10; ++i)
            {
                inputNumberButtons[i] = new Button();
                inputNumberButtons[i].Text = (i).ToString();
            }

            foreach (Button button in inputNumberButtons)
            {
                if (button.Text == "0")
                {
                    button.Clicked += (sender, e) =>
                    {
                        if (inputLabel.Text != "")
                        {
                            chackNumber = Convert.ToUInt64(inputLabel.Text);

                            if (chackNumber < maxNumber)
                                inputLabel.Text += inputNumberButtons[0].Text;
                        }
                    };
                }
                else if (button.Text != "0")
                    button.Clicked += (sender, e) =>
                    {
                        if (inputLabel.Text != "")
                            chackNumber = Convert.ToUInt64(inputLabel.Text);
                        if (chackNumber < maxNumber)
                            inputLabel.Text += button.Text;
                    };

                button.Clicked += (sender, e) =>
                {
                    if (inputLabel.Text != "")
                    {
                        FibonacciSQ.MakeFibonacciSQ(ref fibonocciSQList, Convert.ToUInt64(inputLabel.Text));
                        FibonacciSQ.GetEvenFibonacciSQ(ref fibonocciSQList, ref evenFibonocciSQList);

                        fibonacciSQLabel.Text = "";
                        evenFibonacciSQLabel.Text = "";
                        foreach (UInt64 sqList in fibonocciSQList)
                            fibonacciSQLabel.Text += sqList.ToString() + " ";

                        foreach (UInt64 sqList in evenFibonocciSQList)
                            evenFibonacciSQLabel.Text += sqList.ToString() + " ";

                        sumNumberLabel.Text = FibonacciSQ.GetEvenSum(ref evenFibonocciSQList).ToString();
                    }
                };
            }

            int count = 0;

            inputNumbersGrid.Children.Add(clearButton, 2, 3);
            inputNumbersGrid.Children.Add(inputNumberButtons[count], 0, 3);


            Grid.SetColumnSpan(inputNumberButtons[count], 2);

            count++;

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                {
                    inputNumbersGrid.Children.Add(inputNumberButtons[count++], j, i);
                }

        }


        public static void MakeFibonacciSQ(ref List<UInt64> FibonacciList, UInt64 MaxNumber)
        {
            ///<summary>
            ///피보나치 수열 생성 함수
            ///int형 리스트와 최대값을 받음
            ///들어온 리스트를 최대값보다 작은 피보나치 수열로 변경
            /// </summary>
            /// 

            FibonacciList.Clear();

            if (MaxNumber < 2)
                return;

            FibonacciList.Add(1);
            FibonacciList.Add(1);

            for (int i = 0; FibonacciList[FibonacciList.Count - 1] < MaxNumber; i++)
                FibonacciList.Add(FibonacciList[i] + FibonacciList[i + 1]);

            FibonacciList.RemoveAt(FibonacciList.Count - 1);
        }

        public static void GetEvenFibonacciSQ(ref List<UInt64> OriginalFibonacciSQ, ref List<UInt64> EvenFibonacciSQ)
        {
            ///<summary>
            ///짝수 피보나치수열 추출
            ///OriginalFibonacciSQ : 원본 피보나치 수열
            ///EvenFibonacciSQ : 나갈 피보나치 수열 (짝수)
            /// </summary>
            /// 

            EvenFibonacciSQ.Clear();

            foreach (UInt64 key in OriginalFibonacciSQ)
            {
                if (key % 2 == 0)
                    EvenFibonacciSQ.Add(key);
            }
        }

        public static UInt64 GetEvenSum(ref List<UInt64> EvenFibonacciSQ)
        {
            UInt64 SumNumber = 0;

            foreach (UInt64 key in EvenFibonacciSQ)
                SumNumber += key;

            return SumNumber;
        }
    }
}