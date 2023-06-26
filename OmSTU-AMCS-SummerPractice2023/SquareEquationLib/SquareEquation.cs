namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        //throw new NotImplementedException();
        double eps = 1e-9;
        if((Math.Abs(a) < eps) || (Double.IsNaN(a)) || (Double.IsNegativeInfinity(a)) || (Double.IsPositiveInfinity(a)) || (Double.IsInfinity(a)) )
            throw new ArgumentException();
        if((Double.IsNaN(b)) || (Double.IsNegativeInfinity(b)) || (Double.IsPositiveInfinity(b)) || (Double.IsInfinity(b)))
            throw new ArgumentException();
        if((Double.IsNaN(c)) || (Double.IsNegativeInfinity(c)) || (Double.IsPositiveInfinity(c)) || (Double.IsInfinity(c)))
            throw new ArgumentException();
        double[] Ansver = new double[] {};
        double D = (b*b) - (4 * c * a);
        if(Math.Abs(D) < eps)
        {
            Ansver = new double[1];
            Ansver[0] = (-b)/2;
        }
        if(eps < D)
        {
            Ansver = new double[2];
            D = Math.Sqrt(D);
            Ansver[0] = (-(b + (Math.Sign(b)*D)))/2;
            Ansver[1] = c/Ansver[0];
        }
        else if(D == eps)
        {
            Ansver = new double[2];
            D = Math.Sqrt(D);
            Ansver[0] = (-(b + (Math.Sign(b)*D)))/2;
            Ansver[1] = c/Ansver[0];
        }
        return Ansver;
    }
}
