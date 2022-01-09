using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace BuilderPattern
{
    public  class Person
    {
        public string Name, Position;

        public override string ToString()
        {
            return $" {nameof(Name)} : {Name} , {nameof(Position)} : {Position}";
        }
        public static Builder New = new Builder();

        public class Builder : PersonJobBuilder<Builder>
        {

        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<T> :PersonBuilder where T : PersonInfoBuilder<T>
    {
        
        public T Called(string name)
        {
            person.Name = name;
            return (T) this;
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorksAs(string position)
        {
            person.Position = position;
            return (T) this;
        }
    }
    public class FluentInhertitanceWithGenerics
    {

        //static void Main(string[] args)
        //{
        //    var buider = Person.New.Called("MSN").WorksAs("Dev").Build() ;
        //    WriteLine(buider.ToString());

        //}
    }
}
