namespace ActionExample
{
    using System;
    
    public class ActionDelegate
    {
        public void Add(int x, int y)
        {
            System.Console.WriteLine($"{x} + {y} = {x+y}");
        }

        public void Sub(int x, int y)
        {
            System.Console.WriteLine($"{x} - {y} = {x-y}");
        }

        public void Mul(int x, int y)
        {
            System.Console.WriteLine($"{x} * {y} = {x*y}");
        }

        public void Div(int x, int y)
        {
            System.Console.WriteLine($"{x} / {y} = {x/y}");
        }
    }
}