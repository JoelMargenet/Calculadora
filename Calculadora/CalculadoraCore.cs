using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public class CalculadoraCore
    {
        public string ProcessRootsAndPowers(string operation)
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
            return Regex.Replace(operation, @"√(\d+(\.\d+)?)", match =>
            {
                double value = Convert.ToDouble(match.Groups[1].Value);
                double result = Math.Sqrt(value);
                return result.ToString("0.###");
            });
        }

        public string EvaluateExpression(string operation)
        {
            try
            {
                // Comprobar si la operación contiene una división por cero
                if (operation.Contains("/ 0"))
                {
                    return "Error";
                }

                // Procesar la operación para manejar raíces y potencias
                string processedOperation = ProcessRootsAndPowers(operation);
                processedOperation = processedOperation.Replace(',', '.');

                // Evaluar la expresión final utilizando DataTable.Compute
                var result = new DataTable().Compute(processedOperation, null);
                return result.ToString();
            }
            catch
            {
                // En caso de error, devolver un mensaje genérico
                return "Error";
            }
        }
    }
}
