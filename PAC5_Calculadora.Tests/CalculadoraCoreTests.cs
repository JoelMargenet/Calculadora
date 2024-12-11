using System;
using Xunit;
using Calculadora;

namespace PAC5_Calculadora.Tests
{
    public class CalculadoraCoreTests
    {
        private readonly CalculadoraCore _calculadora;

        public CalculadoraCoreTests()
        {
            _calculadora = new CalculadoraCore();
        }

        [Fact]
        public void TestSuma_Success()
        {
            var result = _calculadora.EvaluateExpression("5 + 3");
            Assert.Equal("8", result);
        }

        [Fact]
        public void TestResta_Success()
        {
            var result = _calculadora.EvaluateExpression("5 - 3");
            Assert.Equal("2", result);
        }

        [Fact]
        public void TestMultiplicacio_Success()
        {
            var result = _calculadora.EvaluateExpression("5 * 3");
            Assert.Equal("15", result);
        }


        [Fact]
        public void TestDivisio_Success()
        {
            var result = _calculadora.EvaluateExpression("5 / 2");
            Assert.Equal("2,5", result);
        }

        [Fact]
        public void TestDivisio_PerZero_ThrowsException()
        {
            var result = _calculadora.EvaluateExpression("5 / 0");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestOperacioComplexa_Success()
        {
            var result = _calculadora.EvaluateExpression("5 + 3 * 2 - 4 / 2");
            Assert.Equal("9", result);
        }

        [Fact]
        public void TestPotencia_Success()
        {
            var result = _calculadora.EvaluateExpression("2^3");
            Assert.Equal("8", result);
        }

        [Fact]
        public void TestPotenciaCero_Success()
        {
            var result = _calculadora.EvaluateExpression("0^5");
            Assert.Equal("0", result);
        }

        [Fact]
        public void TestArrelQuadrada_Success()
        {
            var result = _calculadora.EvaluateExpression("√16");
            Assert.Equal("4", result);
        }

        [Fact]
        public void TestArrelQuadrada_Zero_Success()
        {
            var result = _calculadora.EvaluateExpression("√0");
            Assert.Equal("0", result);
        }

        [Fact]
        public void TestArrelQuadrada_FormatException()
        {
            var result = _calculadora.EvaluateExpression("3 √ 6");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestMultiplicacioPerArrel_Success()
        {
            var result = _calculadora.EvaluateExpression("3 * √9");
            Assert.Equal("9", result);
        }

        [Fact]
        public void TestArrelQuadrada_Negativa_ThrowsException()
        {
            var result = _calculadora.EvaluateExpression("√-4");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestOperacioParentesis_Success()
        {
            var result = _calculadora.EvaluateExpression("( 5 + 3 ) * 2");
            Assert.Equal("16", result);
        }

        [Fact]
        public void TestOperacioParentesisComplexa_Success()
        {
            var result = _calculadora.EvaluateExpression("( ( 2 + 3 ) * 2 )");
            Assert.Equal("10", result);
        }

        [Fact]
        public void TestFormatIncorrecte_ThrowsFormatException()
        {
            var result = _calculadora.EvaluateExpression("5 + ( 3 * 2");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestFormatIncorrecte_ThrowsFormatException_ClosingParenthesis()
        {
            var result = _calculadora.EvaluateExpression("5 + 3 ) * 2");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestOperacioComplexaAmbParentesis_Success()
        {
            var result = _calculadora.EvaluateExpression("3 + 5 * ( 2^3 ) - √16");
            Assert.Equal("39", result);
        }

        [Fact]
        public void TestFormatIncorrecte_ThrowsFormatException_ExpressionWithoutOperator()
        {
            var result = _calculadora.EvaluateExpression("2(8 + 2)");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestFormatIncorrecte_ThrowsFormatException_ExpressionWithNumberAndParenthesis()
        {
            var result = _calculadora.EvaluateExpression("(8 + 2)2");
            Assert.Equal("Error", result);
        }


        [Fact]
        public void TestFormatIncorrecte_ThrowsFormatException_ParenthesisAndNumber()
        {
            var result = _calculadora.EvaluateExpression("(5)3 + 2");
            Assert.Equal("Error", result);
        }

        [Fact]
        public void TestOperacioEspais_Success()
        {
            var result = _calculadora.EvaluateExpression("5    * 3 + 2");
            Assert.Equal("17", result);
        }
    }
}
