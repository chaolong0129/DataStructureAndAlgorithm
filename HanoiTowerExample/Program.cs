using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace HanoiTowerExample {
    class Program {
        private const int DISCS_COUNT = 3;

        static void Main (string[] args) {
            HanioTower algorithm = new HanioTower (DISCS_COUNT);
            algorithm.Move (DISCS_COUNT, 'A', 'B', 'C');
            System.Console.WriteLine($"Total Moves Count {algorithm.MovesCount}");
        }
    }
}