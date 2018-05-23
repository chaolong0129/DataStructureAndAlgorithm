namespace PriorityQueueExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Priority_Queue;
    public class CallCenter
    {
        private int _count = 0;
        public SimplePriorityQueue<IncommingCall> Calls { get; private set; }

        public CallCenter()
        {
            this.Calls = new SimplePriorityQueue<IncommingCall>();
        }

        public void Call(int clientId, bool isPriority = false)
        {
            IncommingCall call = new IncommingCall() {
                Id = _count++,
                ClientId = clientId,
                CallTime = DateTime.Now,
                IsPriority = isPriority
            };
            Calls.Enqueue(call, isPriority ? 0 : 1);
        }

        public IncommingCall Answer(string consultant)
        {
            if (this.Calls.Count <= 0)
                return null;
            IncommingCall call = Calls.Dequeue();
            call.Consultant = consultant;
            call.StartTime = DateTime.Now;
            return call;
        }

        public void End(IncommingCall call)
        {
            call.EndTime = DateTime.Now;
        }

        public bool AreWaitingCalls()
        {
            return this.Calls.Count > 0;
        }
    }
}