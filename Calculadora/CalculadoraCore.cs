using System;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public class CalculadoraCore
    {
        public string EvaluateExpression(string operation)
        {
            try
            {
                operation = operation.Replace(" ", "").Replace(",", ".");

                if (!IsValidExpression(operation))
                {
                    return "Error";
                }

                operation = ProcessRootsAndPowers(operation);

                if (Regex.IsMatch(operation, @"\d\(") || Regex.IsMatch(operation, @"\)\d"))
                {
                    return "Error";
                }

                while (operation.Contains("("))
                {
                    operation = ProcessParentheses(operation);
                }

                operation = ResolveOperations(operation);

                return operation;
            }
            catch
            {
                return "Error";
            }
        }

        private bool IsValidExpression(string operation)
        {
            int openParentheses = operation.Split('(').Length - 1;
            int closeParentheses = operation.Split(')').Length - 1;
            if (openParentheses != closeParentheses)
            {
                return false;
            }

            string pattern = @"^[\d\.\+\-\*/\^\(\)√]+$";
            return Regex.IsMatch(operation, pattern);
        }

        private string ProcessRootsAndPowers(string operation)
        {
            operation = ProcessSquareRoots(operation);
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
            if (Regex.IsMatch(operation, @"\d√"))
            {
                return "Error";
            }

            return Regex.Replace(operation, @"√(\-?\d+(\.\d+)?)", match =>
            {
                double value = Convert.ToDouble(match.Groups[1].Value);
                if (value < 0)
                    return "Error";
                double result = Math.Sqrt(value);
                return result.ToString("0.###");
            });
        }

        private string ProcessParentheses(string operation)
        {
            var match = Regex.Match(operation, @"\(([^()]+)\)");
            if (match.Success)
            {
                string innerExpression = match.Groups[1].Value;
                string result = ResolveOperations(innerExpression);
                return operation.Replace(match.Value, result);
            }

            return operation;
        }

        private string ResolveOperations(string operation)
        {
            operation = ResolveMultiplicationAndDivision(operation);
            operation = ResolveAdditionAndSubtraction(operation);
            return operation;
        }

        private string ResolveMultiplicationAndDivision(string operation)
        {
            operation = Regex.Replace(operation, @"(\d+(\.\d+)?)\s*\*\s*(\d+(\.\d+)?)", match =>
            {
                double left = Convert.ToDouble(match.Groups[1].Value);
                double right = Convert.ToDouble(match.Groups[3].Value);
                return (left * right).ToString();
            });

            operation = Regex.Replace(operation, @"(\d+(\.\d+)?)\s*/\s*(\d+(\.\d+)?)", match =>
            {
                double left = Convert.ToDouble(match.Groups[1].Value);
                double right = Convert.ToDouble(match.Groups[3].Value);
                if (right == 0) return "Error";
                return (left / right).ToString();
            });

            return operation;
        }

        private string ResolveAdditionAndSubtraction(string operation)
        {
            operation = Regex.Replace(operation, @"(\d+(\.\d+)?)\s*\+\s*(\d+(\.\d+)?)", match =>
            {
                double left = Convert.ToDouble(match.Groups[1].Value);
                double right = Convert.ToDouble(match.Groups[3].Value);
                return (left + right).ToString();
            });

            operation = Regex.Replace(operation, @"(\d+(\.\d+)?)\s*-\s*(\d+(\.\d+)?)", match =>
            {
                double left = Convert.ToDouble(match.Groups[1].Value);
                double right = Convert.ToDouble(match.Groups[3].Value);
                return (left - right).ToString();
            });

            return operation;
        }
    }
}
