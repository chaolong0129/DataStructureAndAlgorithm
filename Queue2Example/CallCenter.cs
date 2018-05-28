namespace Queue2Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    public class CallCenter
    {
        private int _count = 0;
        public ConcurrentQueue<IncommingCall> Calls { get; private set; }

        public CallCenter()
        {
            this.Calls = new ConcurrentQueue<IncommingCall>();
        }

        public int Call(int clientId)
        {
            IncommingCall call = new IncommingCall() {
                Id = _count++,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
            return this.Calls.Count;
        }

        public IncommingCall Answer(string consultant)
        {
            if (this.Calls.Count <= 0 || !Calls.TryDequeue(out IncommingCall call))
                return null;
                
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