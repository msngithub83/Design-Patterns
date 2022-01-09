using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class PersonOne
    {
        public string Name, Position;

        public override string ToString()
        {
            return $" {nameof(Name)} : {Name} , {nameof(Position)} : {Position}";
        }
    }

    public abstract class FunctionalBuilder<TSubject,TSelf> where TSelf : FunctionalBuilder<TSubject,TSelf>
        where TSubject: new()
    {
        private List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSelf)this;
        }

        public TSelf Do(Action<TSubject> action)
        {
            return AddAction(action); ;
        }

        public TSubject Build()
        {
            return actions.Aggregate(new TSubject(), (p, f) => f(p));
        }
    }

    public class PersonOneBuilder : FunctionalBuilder<PersonOne, PersonOneBuilder>
    {
        public PersonOneBuilder Called(string name)
        {
            return Do(p => p.Name = name);
        }
    }


    //public sealed class PersonOneBuilder
    //{
    //    private List<Func<PersonOne, PersonOne>> actions = new List<Func<PersonOne, PersonOne>>();

    //    public PersonOneBuilder Called(string name)
    //    {
    //        return  Do(p => p.Name = name);
    //    }

    //    private PersonOneBuilder AddAction(Action<PersonOne> action)
    //    {
    //        actions.Add(p => { action(p);return p; });
    //        return this;
    //    }

    //    public PersonOneBuilder Do(Action<PersonOne> action)
    //    {
    //        return AddAction(action); ;
    //    }

    //    public PersonOne Build()
    //    {
    //        return actions.Aggregate(new PersonOne(), (p,f) => f(p));
    //    }
    //}

    public static class PersonOneBuilderExtensions
    {
        public static PersonOneBuilder WorksAs(this PersonOneBuilder builder, string position)
        {
           return  builder.Do(x => x.Position = position);
        }
    }

    static class FunctionalBuilder
    {
        //public static void Main(string[] args)
        //{
        //    var person = new PersonOneBuilder().Called("Senthilnathan")
        //        .WorksAs("developer")
        //        .Build();

        //    Console.WriteLine(person.ToString());
        //}
    }
}
