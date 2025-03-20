using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private char SelectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            lastNumber = 0;
            result = 0;
            ACButton.Click += ACButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PercentageButton.Click += PercentageButton_Click;
            EqualsButton.Click += EqualsButton_Click;
        }

        private static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        private static double Substract(double number1, double number2)
        {
            return number1 - number2;
        }

        private static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        private static double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return number1 / number2;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out currentNumber))
            {
                switch (SelectedOperator)
                {
                    case '+':
                        result = Add(lastNumber, currentNumber);
                        break;
                    case '-':
                        result = Substract(lastNumber, currentNumber);
                        break;
                    case '*':
                        result = Multiply(lastNumber, currentNumber);
                        break;
                    case '/':
                        result = Divide(lastNumber, currentNumber);
                        break;
                }
                resultLabel.Content = result;
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                resultLabel.Content = "0";

            if (sender == MultiplicationButton)
                SelectedOperator = '*';
            else if (sender == DivisionButton)
                SelectedOperator = '/';
            else if (sender == PlusButton)
                SelectedOperator = '+';
            else
                SelectedOperator = '-';
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            
            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = selectedValue.ToString();
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }
}