using System;

namespace CognologyAPI
{
    public class Flight
    {
        public DateTime DateOfTravel { get; set; }
        public int InBoundAvailable { get; set; }
        public int OutBoundAvailable { get; set; }
    }
}
