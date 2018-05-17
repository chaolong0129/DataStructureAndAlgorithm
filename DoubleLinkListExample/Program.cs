using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkListExample {
    public class Page {
        public int page { get; set; }
        public string Content { get; set; }
    }

    class Program {
        static void Main (string[] args) {
            Page p1 = new Page () { page = 1, Content = "A" };
            Page p2 = new Page () { page = 2, Content = "B" };
            Page p3 = new Page () { page = 3, Content = "C" };
            Page p4 = new Page () { page = 4, Content = "D" };
            Page p5 = new Page () { page = 5, Content = "E" };
            Page p6 = new Page () { page = 6, Content = "F" };
            Page p7 = new Page () { page = 7, Content = "G" };

            LinkedList<Page> pages = new LinkedList<Page> ();
            pages.AddLast (p1);
            pages.AddLast (p2);
            pages.AddLast (p3);
            pages.AddLast (p4);
            LinkedListNode<Page> nodep6 = pages.AddLast (p6);
            pages.AddAfter (nodep6, p7);
            pages.AddBefore (nodep6, p5);

            LinkedListNode<Page> current = pages.First;
            int number = 1;
            while (current != null) {
                Console.Clear ();
                string numberString = $"- {current.Value.page} -";
                int leadingSpaces = (90 - numberString.Length) / 2;
                Console.WriteLine (numberString.PadLeft (leadingSpaces +
                    numberString.Length));
                Console.WriteLine ();

                string content = current.Value.Content;
                for (int i = 0; i < content.Length; i += 90) {
                    string line = content.Substring (i);
                    line = line.Length > 90 ? line.Substring (0, 90) : line;
                    Console.WriteLine (line);
                }

                Console.WriteLine ();
                Console.WriteLine ("Quote from Windows Application Development Cookbook " +
                    $"by Marcin Jamro,{Environment.NewLine}published by Packt Publishing in 2016.");

                Console.WriteLine ();
                Console.Write (current.Previous != null ?
                    "< PREVIOUS [P]" : GetSpaces (14));
                Console.Write (current.Next != null ?
                    "[N] NEXT >".PadLeft (76) : string.Empty);
                Console.WriteLine ();

                switch (Console.ReadKey (true).Key) {
                    case ConsoleKey.N:
                        if (current.Next != null) { // Next
                            current = current.Next;
                            number++;
                        }
                        break;
                    case ConsoleKey.P:
                        if (current.Previous != null) { // Previous
                            current = current.Previous;
                            number--;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private static string GetSpaces (int number) {
            string result = string.Empty;
            for (int i = 0; i < number; i++) {
                result += " ";
            }
            return result;
        }
    }
}