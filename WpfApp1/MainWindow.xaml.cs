using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        double number1 = 0;
        double number2 = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            string buttonValue = GetButtonNumber(sender);

            if ((textValue.Text == "0" || operation != "") && textValue.Text == number1.ToString())
            {
                textValue.Text = buttonValue;
            }
            else
            {
                textValue.Text += buttonValue;
            }

            double number;
            if (Double.TryParse(textValue.Text, out number))
            {
                if (operation == "")
                {
                    number1 = number;
                }
                else
                {
                    number2 = number;
                }
            }
            else
            {
                textValue.Text = "Error";
            }
        }

        private string GetButtonNumber(object sender)
        {
            Button button = (Button)sender;
            string buttonValue = button.Content.ToString();
            return buttonValue;
        }

        private string GetButtonOperation(object sender)
        {
            Button button = (Button)sender;
            string value = button.Content.ToString();
            return value;
        }

        private void OnButtonOperationClick(object sender, RoutedEventArgs e)
        {
            operation = GetButtonOperation(sender);
        }

        private void Btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;

                case "-":
                    result = number1 - number2;
                    break;

                case "*":
                    result = number1 * number2;
                    break;

                case "/":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                    }
                    else
                    {
                        textValue.Text = "Error";
                        return;
                    }
                    break;

                case "min":
                    result = Math.Min(number1, number2);
                    break;

                case "max":
                    result = Math.Max(number1, number2);
                    break;

                case "avg":
                    result = (number1 + number2) / 2;
                    break;

                case "x^y":
                    result = PowRecursion(number1, (int)number2);
                    break;

                default:
                    textValue.Text = "Error";
                    return;
            }

            textValue.Text = result.ToString();
            operation = "";
            number1 = result;
            number2 = 0;
        }

        private double PowRecursion(double x, int y)
        {
            if (y == 0)
                return 1;

            double result = x;

            for (int i = 1; i < y; i++)
            {
                result *= x;
            }

            return result;
        }

        private void btn_clean_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            textValue.Text = "0";
        }

        private void btn_cleanEntry_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }

            textValue.Text = "0";
        }

        private void btn_backSpace_Click(object sender, RoutedEventArgs e)
        {
            textValue.Text = DropLastChar(textValue.Text);

            if (operation == "")
            {
                number1 = double.Parse(textValue.Text);
            }
            else
            {
                number2 = double.Parse(textValue.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
            {
                return "0";
            }
            else
            {
                text = text.Remove(text.Length - 1, 1);

                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }

            return text;
        }

        private void btn_plusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= -1;
                textValue.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                textValue.Text = number2.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                SetComma(number1);
            }
            else
            {
                SetComma(number2);
            }
        }

        private void SetComma(double number)
        {
            if (textValue.Text.Contains(','))
            {
                return;
            }

            textValue.Text += ',';
        }
    }
}
