namespace FunExample
{
    using System;
    public class GetNumber
    {
        public void Calculate(Func<int, int, string> func, int x, int y)
        {
            System.Console.WriteLine(func(x, y));
        }
    }
}