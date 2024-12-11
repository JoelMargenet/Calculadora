using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string operation = "";
        private bool isResultDisplayed = false;

        // Using CalculadoraCore for the operations
        private CalculadoraCore calculadoraCore = new CalculadoraCore();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (isResultDisplayed)
            {
                operation = "";
                isResultDisplayed = false;
            }
            currentInput += button.Content.ToString();
            operation += button.Content.ToString();
            Display.Text = operation;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (!string.IsNullOrEmpty(currentInput) || isResultDisplayed)
            {
                currentInput = "";
                operation += $" {button.Content.ToString()} ";
                Display.Text = operation;
                isResultDisplayed = false;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            string result = calculadoraCore.EvaluateExpression(operation);
            Display.Text = result;
            operation = result;
            currentInput = "";
            isResultDisplayed = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            operation = "";
            Display.Text = "0";
            isResultDisplayed = false;
        }

        private void ParenthesisLeft_Click(object sender, RoutedEventArgs e)
        {
            operation += "(";
            Display.Text = operation;
        }

        private void ParenthesisRight_Click(object sender, RoutedEventArgs e)
        {
            operation += ")";
            Display.Text = operation;
        }

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            operation += "√";
            Display.Text = operation;
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            operation += "^";
            Display.Text = operation;
        }
    }
}
