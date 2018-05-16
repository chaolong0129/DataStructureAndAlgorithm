using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListExample {
    public class Person {
        public int Age { get; set; }
        public string Name { get; set; }
        public CountryEnum Country { get; set; }
        public override string ToString() {
            return $"{Age}, {Name}, {Country}";
        }
    }

    public enum CountryEnum {
        TW,
        CN,
        US,
        UK
    }

    class Program {
        static void Main (string[] args) {
            List<Person> myList = new List<Person> () {
                new Person () { Age = 20, Name = "Joe", Country = CountryEnum.TW },
                new Person () { Age = 37, Name = "Robert", Country = CountryEnum.TW },
                new Person () { Age = 18, Name = "Liz", Country = CountryEnum.US }
            };

            foreach (var p in myList)
                System.Console.WriteLine(p);

            var over30 = myList.OrderBy(p => p.Age).Where(p => p.Age >= 30).ToList();
            
            foreach (var p in over30)
                System.Console.WriteLine(p);


            var under30 = (from p in myList where p.Age < 30 orderby p.Name select new {p.Name, p.Age, p.Country}).ToList();
            foreach (var p in under30)
                System.Console.WriteLine(p);

            var guys = (from p in myList where p.Name == "Robert" select p.Name).ToList();
            foreach (var p in guys) System.Console.WriteLine(p);
        }
    }
}