using FluentAssertions;
using NUnit.Framework;
using Сalculator;
using Сalculator.ExpressionTree;

namespace Calculator.Tests
{
    [TestFixture]
    class CalculatorTests
    {
        [TestCase("1", 1)]
        [TestCase("1+1", 2)]
        [TestCase(" 1 +  1 ", 2)]
        [TestCase("1+1+1", 3)]
        [TestCase("11+12", 23)]
        [TestCase("1,1+1", 2.1)]
        [TestCase("2147483647+2147483647", 4294967294)]
        [TestCase("2-1", 1)]
        [TestCase("2+3-1-0", 4)]
        [TestCase("2*3", 6)]
        [TestCase("2*3+1", 7)]
        [TestCase("1+2*3", 7)]
        [TestCase("1+2*3+4*5+10", 37)]
        [TestCase("2+3+10+4*5*1*1+5+5+5", 50)]
        [TestCase("6/2", 3)]
        [TestCase("3*6/2", 9)]
        [TestCase("6/2*3", 1)]
        [TestCase("6/2+5", 8)]
        [TestCase("5+0*6/2", 5)]
        [TestCase("(1+1)", 2)]
        [TestCase("(1+1)+1", 3)]
        [TestCase("1+(1+1)", 3)]
        [TestCase("2*(1+3)", 8)]
        [TestCase("2*(1-6/(2+1))*(1-3)", 4)]
        [TestCase("(2,0*(1-6/(2+1))*(1,3-3,3))*1,1", 4.4)]
        [TestCase("-1", -1)]
        [TestCase("-1*5+1", -4)]
        [TestCase("-2-1", -3)]
        [TestCase("-2+(-1*3)", -5)]
        [TestCase("-2+(1/(-1))", -3)]

        public void Test(string expression, double expectedResult)
        {
            var result = MyCalculator.Resolve(new StringExpressionReader(expression));
            result.Should().BeApproximately(expectedResult, 0.000001);
        }
    }
}
