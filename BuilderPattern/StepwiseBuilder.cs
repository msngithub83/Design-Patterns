using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public enum CarType
    {
        Sedan,//15-17 inch
        CrossOver //17-20 inch
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType carType);  
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WheelsWithSize(int wheelSize);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    public class CarBuilder
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
        {
            private Car car = new Car();
            public Car Build()
            {
                return car;
            }

            public ISpecifyWheelSize OfType(CarType carType)
            {
                car.Type = carType;
                return this;
            }

            public IBuildCar WheelsWithSize(int wheelSize)
            {
                switch(car.Type)
                {
                    case CarType.CrossOver when wheelSize < 17 || wheelSize > 20:
                    case CarType.Sedan when  wheelSize < 15 || wheelSize > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}");

                }

                car.WheelSize = wheelSize;
                return this;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }

    class StepwiseBuilder
    {
        //public static void Main(string[] args)
        //{
        //    var car = CarBuilder.Create().OfType(CarType.CrossOver).WheelsWithSize(19).Build();

        //}

    }
}
