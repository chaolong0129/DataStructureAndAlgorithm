namespace HashTableExample {
    using System.Collections;
    using System;

    class Program {
        static void Main (string[] args) {
            var phoneBook = new Hashtable () { { "Robert Chen", "111-111-111" }, { "Robert 2 Chen", "222-222-222" }, { "Robert 3 ", "333-333-333" }
            };

            phoneBook["Robert 4"] = "444-444-444";

            if (!phoneBook.Contains ("Robert 5")) {
                try {
                    phoneBook.Add ("Robert 5", "555-555-555");
                } catch (ArgumentException) {
                    System.Console.WriteLine ("The entry already exists.");
                }
            }

            Console.WriteLine ("Phone numbers:");
            if (phoneBook.Count == 0) {
                Console.WriteLine ("Empty");
            } else {
                foreach (DictionaryEntry entry in phoneBook) {
                    Console.WriteLine ($" - {entry.Key}: {entry.Value}");
                }
            }

            Console.WriteLine ();
            Console.Write ("Search by name: ");
            string name = Console.ReadLine ();
            if (phoneBook.Contains (name)) {
                string number = (string) phoneBook[name];
                Console.WriteLine ($"Found phone number: {number}");
            } else {
                Console.WriteLine ("The entry does not exist.");
            }
        }
    }
}