using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BuilderPattern
{
    public class PersonTwo
    {
        //address
        public string StreetAddress, Postcode, City;

        //employment
        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonTwoBuilder
    {
        protected PersonTwo person = new PersonTwo();

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonTwoJobBuilder Works => new PersonTwoJobBuilder(person);

        public static implicit operator PersonTwo(PersonTwoBuilder personTwoBuilder)
        {
            return personTwoBuilder.person;
        }

        //public override string ToString()
        //{
        //    return $"{nameof(person.StreetAddress)}: {person.StreetAddress}, {nameof(person.Postcode)}: {person.Postcode}," +
        //        $" {nameof(person.City)}: {person.City}, {nameof(person.CompanyName)}: {person.CompanyName}, {nameof(person.Position)}:" +
        //        $" {person.Position}, {nameof(person.AnnualIncome)}: {person.AnnualIncome}";
        //}
    }

    public class PersonAddressBuilder :PersonTwoBuilder
    {
        public PersonAddressBuilder(PersonTwo personTwo)
        {
            this.person = personTwo;
        }

        public PersonAddressBuilder At(string  streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder LivesIn(string city)
        {
            person.City = city;
            return this;
        }

        public PersonAddressBuilder PinCode(string pinCode)
        {
            person.Postcode = pinCode;
            return this;
        }

    }

    public class PersonTwoJobBuilder : PersonTwoBuilder
    {
        public PersonTwoJobBuilder(PersonTwo person)
        {
            this.person = person;
        }

        public PersonTwoJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonTwoJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonTwoJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class FacetedBuilder
    {

        public static void Main(string[] args)
        {
            var pb = new PersonTwoBuilder();


            PersonTwo person = pb.Lives.At("Vellalore").PinCode("641111").LivesIn("Coimbatore")
                        .Works.At("ABC").AsA("developer").Earning(12500);

            WriteLine(person);
        }
    }
}
