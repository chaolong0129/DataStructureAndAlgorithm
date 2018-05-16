using System;
using System.Collections;

namespace ArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrays = new ArrayList();
            arrays.Add(5);
            arrays.AddRange(new object[] {"Mary", "Joe"});
            arrays.AddRange(new int[] {1, 2, 3});
            arrays.Insert(2, "30");
            foreach (var o in arrays)
            {
                System.Console.WriteLine(o);
            }
        }
    }
}
