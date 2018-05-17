using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedListExample
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CountryEnum Country { get; set; }
    }

    public enum CountryEnum
    {
        TW,
        JP,
        CN,
        US
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mySortedList = new SortedList<string, Person>();
            mySortedList.Add ("Robert", new Person() {Name = "Robert", Age = 37, Country = CountryEnum.TW});
            mySortedList.Add ("Liz", new Person() {Name = "Liz", Age = 29, Country = CountryEnum.TW});
            mySortedList.Add ("Ann", new Person() {Name = "Ann", Age = 5, Country = CountryEnum.TW});
            foreach (KeyValuePair<string, Person> person in mySortedList)
            {
                System.Console.WriteLine($"{person.Value.Name} {person.Value.Age} Years {person.Value.Country}");
            }
        }
    }
}
