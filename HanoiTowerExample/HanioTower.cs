namespace HanoiTowerExample {
    using System.Collections.Generic;
    using System;

    public class HanioTower {
        public int DiscsCount { get; set; } // All Discs
        public int MovesCount { get; set; } // All Moves Count
        public HanioTower (int discs) {
            this.DiscsCount = discs;
            System.Console.WriteLine ("How many discs are there : " + discs);
        }

        public void Move (int discs, char a, char b, char c) {
            if (discs == 1) {
                MovesCount++;            
                System.Console.WriteLine ($"Move a disc from {a} to {c}");
            } else {
                Move (discs - 1, a, c, b);
                Move (1, a, b, c);
                Move (discs - 1, b, a, c);
            }
        }
    }
}