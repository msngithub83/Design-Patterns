using System;

namespace FactoryPattern
{
    //public enum CoordinateSystem
    //{
    //    Cartesian,
    //    Polar
    //}
    public class Point
    {
        double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)} : {x} ,{nameof(y)} : {y}";
        }
        public static Point Origin => new Point(0, 0);

        public static Point Origin2 = new Point(0, 0);


        public static class Factory
        {
            public static Point NewCartesianProduct(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

        }
    }
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            //    var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            //    Console.WriteLine(point);

            //Factory 
            //var point = Point.Factory.NewCartesianProduct(1.0, Math.PI / 2);
            //Console.WriteLine(point);

        }
    }

    
}
