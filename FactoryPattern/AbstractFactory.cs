using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FactoryPattern
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("this tea ia nice but  i'd prefer with milk");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
           WriteLine("This is sensational! ");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon , enjoy");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar , enjoy");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Tea,Coffee
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
        public HotDrinkMachine()
        {
            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory) Activator.CreateInstance(Type.GetType($"Design Patterns."))
            }

        }
    }

    public class AbstractFactory
    {

        static void Main(string[] args)
        {

        }
    }
}
