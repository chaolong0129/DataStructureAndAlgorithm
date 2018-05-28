namespace QueueExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CallCenter
    {
        private int _count = 0;
        public Queue<IncommingCall> Calls { get; private set; }

        public CallCenter()
        {
            this.Calls = new Queue<IncommingCall>();
        }

        public void Call(int clientId)
        {
            IncommingCall call = new IncommingCall() {
                Id = _count++,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
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