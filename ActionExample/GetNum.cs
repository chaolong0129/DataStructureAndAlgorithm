namespace ActionExample
{
    using System;

    public class GetNum
    {
        public void Operation(Action<int, int> act, int x, int y)
        {
            act(x, y);
        }
    }
}