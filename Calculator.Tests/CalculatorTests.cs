using NUnit.Framework;
using Сalculator;
using Сalculator.ExpressionTree;

namespace Calculator.Tests
{
    [TestFixture]
    class CalculatorTests
    {
        private StringCalculator _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = new StringCalculator();
        }
        //[TestCase("-2-1", ExpectedResult = -3)]
        //[TestCase("6/0", ExpectedResult = 1)]
        // todo как на счет отрицательных чисел в начале?
        // todo умножение на ноль
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1+1", ExpectedResult = 2)]
        [TestCase(" 1 +  1 ", ExpectedResult = 2)]
        [TestCase("1+1+1", ExpectedResult = 3)]
        [TestCase("11+12", ExpectedResult = 23)]
        [TestCase("1,1+1", ExpectedResult = 2.1)]
        [TestCase("2147483647+2147483647", ExpectedResult = 4294967294)]
        [TestCase("2-1", ExpectedResult = 1)]
        [TestCase("2+3-1-0", ExpectedResult = 4)]
        [TestCase("2*3", ExpectedResult = 6)]
        [TestCase("2*3+1", ExpectedResult = 7)]
        [TestCase("1+2*3", ExpectedResult = 7)]
        [TestCase("1+2*3+4*5+10", ExpectedResult = 37)]
        [TestCase("6/2", ExpectedResult = 3)]
        [TestCase("3*6/2", ExpectedResult = 9)]
        [TestCase("6/2*3", ExpectedResult = 1)]
        [TestCase("6/2+5", ExpectedResult = 8)]
        [TestCase("5+0*6/2", ExpectedResult = 5)]
        [TestCase("(1+1)", ExpectedResult = 2)]
        [TestCase("(1+1)+1", ExpectedResult = 3)]
        [TestCase("1+(1+1)", ExpectedResult = 3)]
        [TestCase("2*(1+3)", ExpectedResult = 8)]
        [TestCase("2*(1 - 6/(2 + 1))*(1 - 3)", ExpectedResult = 4)]
        public double Test(string expression)
        {
            return _sut.Resolve(new ExpressionReader(expression));
        }
    }
}
