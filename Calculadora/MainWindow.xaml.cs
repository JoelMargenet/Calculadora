using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        private string currentInput = ""; // to keep what the user is writing
        private string operation = ""; // to keep the operation
        private bool isResultDisplayed = false; // it shows if the result was disp`layed in the screen

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
            // operation to avoid more than one operation at the same time
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
            try
            {
                // process the Roots and powers first
                string processedOperation = ProcessRootsAndPowers(operation);
                processedOperation = processedOperation.Replace(',', '.');

                // Do the operation
                var result = new DataTable().Compute(processedOperation, null);
                Display.Text = result.ToString();
                operation = result.ToString();
                currentInput = "";
                isResultDisplayed = true; 
            }
            catch
            {
                Display.Text = "Error"; // Showing error if something is wrong
                operation = "";
                currentInput = "";
            }
        }

        private string ProcessRootsAndPowers(string operation)
        {
            // doing the roots calculations
            operation = ProcessSquareRoots(operation);

            // doing the power calculations
            operation = ProcessPower(operation);

            return operation;
        }

        private string ProcessPower(string operation)
        {
           
            return Regex.Replace(operation, @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)", match =>
            {
                double baseValue = Convert.ToDouble(match.Groups[1].Value);
                double exponent = Convert.ToDouble(match.Groups[3].Value);
                return Math.Pow(baseValue, exponent).ToString();
            });
        }

        private string ProcessSquareRoots(string operation)
        {
           
            return Regex.Replace(operation, @"√(\d+(\.\d+)?)", match =>
            {
                double value = Convert.ToDouble(match.Groups[1].Value);
                double result = Math.Sqrt(value); 

                return result.ToString("0.###");
            });
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
