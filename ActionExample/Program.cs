using System;

namespace ActionExample {
    class Program {
        static void Main (string[] args) {
            var act = new ActionDelegate();
            var getNum = new GetNum();
            getNum.Operation(act.Add, 1, 1);
            getNum.Operation(act.Sub, 1, 1);
            getNum.Operation(act.Div, 1, 1);
            getNum.Operation(act.Mul, 1, 1);
        }
    }
}