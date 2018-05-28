
namespace SortedSetExample {

using System;
using System.Collections;
using System.Collections.Generic;

    class Program {
        static void Main (string[] args) {
            var names = new List<string> () {
                "Marcin",
                "Mary",
                "James",
                "Albert",
                "Lily",
                "Emily",
                "marcin",
                "James",
                "Jane"
            };

            var sorted = new SortedSet<string>(
                names,
                Comparer<string>.Create((a, b) => 
                    a.ToLower().CompareTo(b.ToLower()))
            );

            foreach (var name in sorted)
            {
                System.Console.WriteLine(name);
            }
        }
    }
}