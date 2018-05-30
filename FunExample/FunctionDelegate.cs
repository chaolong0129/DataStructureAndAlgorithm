namespace FunExample
{
    public class FunctionDelegate
    {
        public string Add(int x, int y) 
        {
            return string.Format("{0} + {1} = {2}", x, y, x+y);
        }
        public string Sub(int x, int y) 
        {
            return string.Format("{0} - {1} = {2}", x, y, x-y);
        }
        public string Div(int x, int y) 
        {
            return string.Format("{0} / {1} = {2}", x, y, x/y);
        }
        public string Mul(int x, int y)
        {
            return string.Format("{0} * {1} = {2}", x, y, x*y);
        }
    }
}