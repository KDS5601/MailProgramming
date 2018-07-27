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
    public partial class ChackPalindrome : ContentPage
    {
        public ChackPalindrome()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            backButton.Clicked += async (sender, e) =>
            await Navigation.PopAsync();

            /*
             - 문제 -
             정수(int)가 주어지면, 팰린드롬(palindrome)인지 알아내시오.
             팰린드롬이란, 앞에서부터 읽으나 뒤에서부터 읽으나 같은 단어를 말합니다.
             단, 정수를 문자열로 바꾸면 안됩니다.
             */

            /*
             = 답 -
             정수를 각 자리수별로 나누어서 저장하는 List를 이용
             자리수별로 비교연산 실행

            비교 실행 함수 : ChackPalindrome
            위 함수에선 들어온 정수가 회문이면 true, 아니면 fales를 반환하는 방법
            그외에는 버튼 클릭 이벤트에 구현되어 있음
             */

            inputLabel.Text = "";
            Button[] inputNumberButtons = new Button[10];
            Button clearButton = new Button { Text = "clr" };

            const int maxNumber = 99_999_999;
            int chackNumber = 0;

            clearButton.Clicked += (sender, e) =>
            {
                inputLabel.Text = "";
                chackNumber = 0;
                chackLabel.Text = "대기중";
            };

            for (int i = 0; i < 10; ++i)
            {
                inputNumberButtons[i] = new Button
                {
                    Text = (i).ToString()
                };
            }

            foreach (Button button in inputNumberButtons)
            {
                if (button.Text == "0")
                {
                    button.Clicked += (sender, e) =>
                    {
                        if (inputLabel.Text != "")
                        {
                            chackNumber = Convert.ToInt32(inputLabel.Text);

                            if (chackNumber < maxNumber)
                            {
                                inputLabel.Text += inputNumberButtons[0].Text;
                            }
                        }
                    };
                }
                else if (button.Text != "0")
                    button.Clicked += (sender, e) =>
                    {
                        if (inputLabel.Text != "")
                            chackNumber = Convert.ToInt32(inputLabel.Text);
                        if (chackNumber < maxNumber)
                            inputLabel.Text += button.Text;
                    };

                button.Clicked += (sender, e) =>
                {
                    if (inputLabel.Text != "")
                    {
                        if (ChackPalindromeAlorithm(Convert.ToInt32(inputLabel.Text)))
                        {
                            chackLabel.Text = "입력하신 숫자는 회문입니다.";
                        }
                        else
                        {
                            chackLabel.Text = "입력하신 숫자는 회문이 아닙니다.";
                        }
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

        private bool ChackPalindromeAlorithm(int input_p)
        {
            ///<summary>
            ///숫자 회문 판별 함수
            ///텍스트로 변경 x 이므로 자리별로 나누어서 판별
            ///</summary>
            ///

            if (input_p < 10)
            {
                return true;
            }

            List<int> numbers = new List<int>();

            for (int i = 0; ; ++i)
            {
                numbers.Add((input_p % (int)(Math.Pow(10, (i + 1)))) / (int)(Math.Pow(10, i)));
                input_p -= numbers[i] * (int)(Math.Pow(10, i));

                if (input_p == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < numbers.Count / 2; ++i)
            {
                if (numbers[i] != numbers[numbers.Count - 1 - i])
                {
                    return false;
                }
            }
            return true;

        }
    }
}
