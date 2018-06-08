namespace HashSet2SwimmingPoolExample {
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System;

    class Program {
        private static Random random = new Random ();
        static void Main (string[] args) {
            Dictionary<PoolTypeEnum, HashSet<int>> tickets = new Dictionary<PoolTypeEnum, HashSet<int>> () { { PoolTypeEnum.RECREATION, new HashSet<int> () }, { PoolTypeEnum.COMPETITION, new HashSet<int> () }, { PoolTypeEnum.THERMAL, new HashSet<int> () }, { PoolTypeEnum.KIDS, new HashSet<int> () }
            };

            for (int i = 1; i < 100; i++) {
                foreach (var type in tickets) {
                    if (GetRandomBoolean ())
                        type.Value.Add (i);
                }
            }

            System.Console.WriteLine ("Number of visitors by a pool type:");
            foreach (var type in tickets) {
                System.Console.WriteLine ($" - {type.Key.ToString().ToLower()} : {type.Value.Count}");
            }

            var maxVisitors = tickets.OrderByDescending (t => t.Key).FirstOrDefault ();

            System.Console.WriteLine ($"Pool : {maxVisitors.ToString().ToLower()} was the most popular.");
            var any = new HashSet<int> (tickets[PoolTypeEnum.RECREATION]);
            any.UnionWith (tickets[PoolTypeEnum.COMPETITION]);
            any.UnionWith (tickets[PoolTypeEnum.THERMAL]);
            any.UnionWith (tickets[PoolTypeEnum.KIDS]);
            System.Console.WriteLine ($"<UNIONWith> {any.Count} people visited at least one pool.");

            var all = new HashSet<int> (tickets[PoolTypeEnum.RECREATION]);
            all.IntersectWith (tickets[PoolTypeEnum.COMPETITION]);
            all.IntersectWith (tickets[PoolTypeEnum.THERMAL]);
            all.IntersectWith (tickets[PoolTypeEnum.KIDS]);
            System.Console.WriteLine ($"<InsersectWith> {all.Count} people visited at least all pool.");

        }

        private static bool GetRandomBoolean () {
            return random.Next (2) == 1;
        }
    }
}