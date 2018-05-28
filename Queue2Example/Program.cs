﻿namespace Queue2Example {
    using System.Collections.Generic;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Threading;
    using System;

    class Program {
        static void Main (string[] args) {
            CallCenter center = new CallCenter ();
            Parallel.Invoke (
                () => CallersAction (center),
                () => ConsultantAction (center, "Marcin",
                    ConsoleColor.Red),
                () => ConsultantAction (center, "James",
                    ConsoleColor.Yellow),
                () => ConsultantAction (center, "Olivia",
                    ConsoleColor.Green));
        }

        private static void CallersAction (CallCenter center) {
            Random random = new Random ();
            while (true) {
                int clientId = random.Next (1, 10000);
                int waitingCount = center.Call (clientId);
                Log ($"Incoming call from {clientId}, waiting in the queue: {waitingCount}");
                Thread.Sleep (random.Next (1000, 5000));
            }
        }

        private static void ConsultantAction (CallCenter center,
            string name, ConsoleColor color) {
            Random random = new Random ();
            while (true) {
                IncommingCall call = center.Answer (name);

                if (call == null) {
                    Thread.Sleep (100);
                    continue;
                }

                Console.ForegroundColor = color;
                Log ($"Call #{call.Id} from {call.ClientId} is answered  by {call.Consultant}.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Thread.Sleep (random.Next (1000, 10000));
                center.End (call);

                Console.ForegroundColor = color;
                Log ($"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Thread.Sleep (random.Next (500, 1000));
            }
        }

        private static void Log (string text) {
            Console.WriteLine ($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
        }
    }
}