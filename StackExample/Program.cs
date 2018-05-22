using System;
using System.Collections.Generic;

namespace StackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> cstack = new Stack<char>();
            foreach (var c in "Hello World!")
            {
                cstack.Push(c);
            }
            
            while (cstack.Count > 0) {
                System.Console.Write(cstack.Pop());
            }
            System.Console.WriteLine();
        }
    }
}
