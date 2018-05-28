namespace PriorityQueueExample {
    using System;
    public class IncommingCall {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; }
        public bool IsPriority { get; set; }
    }
}