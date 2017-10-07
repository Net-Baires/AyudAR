using System;

namespace server.Model
{
    public class TimeRange
    {
        public string Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

}
