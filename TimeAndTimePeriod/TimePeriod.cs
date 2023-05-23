using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndTimePeriod
{
    public struct TimePeriod
    {
        public long TotalSeconds { get; }
        //public string StringValue { get; } TODO

        public TimePeriod(long totalSeconds)
        {
            if (totalSeconds < 0)
                throw new ArgumentException("Invalid TimePeriod value passed");

            TotalSeconds = totalSeconds;
        }

        public TimePeriod(byte hours, byte minutes, byte seconds)
        {
            if (minutes >= 60 || seconds >= 60)
                throw new ArgumentException("Invalid TimePeriod values passed");

            TotalSeconds = hours * 3600L + minutes * 60L + seconds;
        }

        public TimePeriod(byte hours, byte minutes) : this(hours, minutes, 0) { }

        public TimePeriod(byte seconds) : this(0, 0, seconds) { }

        public TimePeriod(Time startTime, Time endTime)
        {
            long startSeconds = startTime.Hours * 3600L + startTime.Minutes * 60L + startTime.Seconds;
            long endSeconds = endTime.Hours * 3600L + endTime.Minutes * 60L + endTime.Seconds;

            if (endSeconds < startSeconds)
                endSeconds += 86400; // add 24 hours = 86400 seconds

            TotalSeconds = endSeconds - startSeconds;
        }

        public TimePeriod(string timePeriodString)
        {
            string[] parts = timePeriodString.Split(':');
            byte hours, minutes, seconds;

            if (parts.Length != 3)
                throw new ArgumentException("Invalid TimePeriod format passed");

            if (!byte.TryParse(parts[0], out hours) || !byte.TryParse(parts[1], out minutes) || !byte.TryParse(parts[2], out seconds))
                throw new ArgumentException("Invalid TimePeriod format passed");

            if (minutes >= 60 || seconds >= 60)
                throw new ArgumentException("Invalid TimePeriod values passed");

            TotalSeconds = hours * 3600L + minutes * 60L + seconds;
        }
    }
}
