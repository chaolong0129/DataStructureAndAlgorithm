using System;

namespace FunExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var func = new FunctionDelegate();
            var getNumber = new GetNumber();
            getNumber.Calculate(func.Add, 1, 1);
            getNumber.Calculate(func.Sub, 1, 1);
            getNumber.Calculate(func.Mul, 1, 1);
            getNumber.Calculate(func.Div, 1, 1);
        }
    }
}
