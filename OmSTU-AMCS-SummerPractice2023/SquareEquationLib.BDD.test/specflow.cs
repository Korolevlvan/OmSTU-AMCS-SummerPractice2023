
using Xunit;
using SquareEquationLib;
using TechTalk.SpecFlow;
namespace SquareEquationLib.BDD.test
{
    [Binding]
    public class UnitTest1
    {
        /*
        */
        public double a, b, c;
        public double[] Value;
        public bool flag = false;
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void Giv(string aa, string bb, string cc)
        {
            try
            {
            a = Convert.ToDouble(aa);
            b = Convert.ToDouble(bb);
            c = Convert.ToDouble(cc);
            }
            catch(FormatException)
            {
                flag = true;
            }
        }

        [When("вычисляются корни квадратного уравнения")]
        public void Whe()
        {
            if (flag == false){
                try
                {
                    Value = SquareEquation.Solve(a, b, c);
                }
                catch(ArgumentException)
                {
                    flag = true;
                }
            }
        }

        [Then("выбрасывается исключение ArgumentException")]
        public void The1()
        {
            Assert.True(flag);
        }

        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void The2(double value1, double value2)
        {
            double eps = 1e-6;
            if(((Math.Abs(Value[0] - value1) < eps) && (Math.Abs(Value[1] - value2) < eps)) 
            || ((Math.Abs(Value[1] - value1) <= eps) && (Math.Abs(Value[0] - value2) <= eps)))flag = true;
            Assert.True(flag);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void The3(double value1)
        {
            double eps = 1e-6;
            if(Math.Abs(Value[0] - value1) < eps)flag = true;
            Assert.True(flag);
        }

        [Then(@"множество корней квадратного уравнения пустое")]
        public void The4()
        {
            if(Value.Length == 0)flag = true;
            Assert.True(flag);
        }
    }
}