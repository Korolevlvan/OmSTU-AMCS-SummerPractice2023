using Xunit;
using SquareEquationLib;

namespace SquareEquationLib.Tests
{
    public class UnitTest1
    {
        //Проверка на ошибку при неподходящих данных.
        [Theory]
        [InlineData(0.0 , 2.0, 3.0)]
        [InlineData(Double.NaN, 2.0, 30.0)]
        [InlineData(1.0 , Double.NaN, 30.0)]
        [InlineData(1.0 , 2.0, Double.NaN)]
        [InlineData(Double.PositiveInfinity , 2.0, 30.0)]
        [InlineData(1.0 , Double.PositiveInfinity, 30.0)]
        [InlineData(1.0 , 2.0, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity , 2.0, 30.0)]
        [InlineData(1.0 , Double.NegativeInfinity, 30.0)]
        [InlineData(1.0 , 2.0, Double.NegativeInfinity)]
        public void UnsuitableValues(double a, double b, double c)
        {
            bool flag = false;
            try
            {

                double[] Value = SquareEquation.Solve(a, b, c);
                Console.WriteLine(Value);
            }
            catch(ArgumentException)
            {
                flag = true;
            }
            Assert.True(flag);
        }
        //проверка на корректную работу при -eps<D<0 и 0<D<eps.
        [Fact]
        public void EpsilonValues()
        {
            double a = 1.0;
            double b = 0.0;
            double c = (Convert.ToDouble(1e-9)/5.0);
            double[] Value1 = SquareEquation.Solve(a, b, c);
            double[] Value2 = SquareEquation.Solve(a, b, -c);
            bool flag = false;
            if(Value1.Length == 1 && Value2.Length == 1)flag = true;
            Assert.True(flag);
        }
        //Проверка на задачи с одним корнем
        [Fact]
        public void OneSolutions()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 0.0;
            double[] Value = SquareEquation.Solve(a, b, c);
            bool flag = false;
            if(Value.Length == 1)flag = true;
            Assert.True(flag);
        }
        //Проверка на задачи без корней
        [Fact]
        public void ZeroSolutions()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 10.0;
            double[] Value = SquareEquation.Solve(a, b, c);
            bool flag = false;
            if(Value.Length == 0)flag = true;
            Assert.True(flag);
        }
    }
}