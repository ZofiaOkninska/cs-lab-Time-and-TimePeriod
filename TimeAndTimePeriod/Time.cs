﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndTimePeriod
{
    /// <param name="Hours">Is an hour of a given timepoint</param>
    /// <param name="Minutes">Is a minute of a given timepoint</param>
    /// <param name="Seconds">Is a second of a given timepoint</param>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        #region External properties
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }
        #endregion

        #region Constructors
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours >= 24 || minutes >= 60 || seconds >= 60)
                throw new ArgumentException("Invalid time values passed");

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(byte hours, byte minutes) : this(hours, minutes, 0) { }

        public Time(byte hours) : this(hours, 0, 0) { }

        public Time(string timeString)
        {
            string[] parts = timeString.Split(':');
            byte hours, minutes, seconds;

            if (parts.Length != 3)
                throw new ArgumentException("Invalid time format passed");

            if (!byte.TryParse(parts[0], out hours) || !byte.TryParse(parts[1], out minutes) || !byte.TryParse(parts[2], out seconds))
                throw new ArgumentException("Invalid time format passed");

            if (hours >= 24 || minutes >= 60 || seconds >= 60)
                throw new ArgumentException("Invalid time values passed");

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        #endregion

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        #region Implementation of IEquatable<Time>
        public override bool Equals(object obj)
        {
            if (obj is Time)
                return Equals((Time)obj);
            return false;
        }

        public bool Equals(Time other)
        {
            return (Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds);
        }

        public static bool Equals(Time time1, Time time2) => time1.Equals(time2);

        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public static bool operator ==(Time leftSide, Time rightSide) => Equals(leftSide, rightSide);

        public static bool operator !=(Time leftSide, Time rightSide) => !(Equals(leftSide, rightSide));
        #endregion

        #region Implementation of IComparable<Time>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is Time))
                throw new ArgumentException("Compare to object must be a Time", "obj");

            return CompareTo((Time)obj);
        }

        public int CompareTo(Time other)
        {
            if (Hours != other.Hours)
                return Hours.CompareTo(other.Hours);
            if (Minutes != other.Minutes)
                return Minutes.CompareTo(other.Minutes);
            return Seconds.CompareTo(other.Seconds);
        }

        public static bool operator <(Time time1, Time time2) => time1.CompareTo(time2) < 0;

        public static bool operator <=(Time time1, Time time2) => time1.CompareTo(time2) <= 0;

        public static bool operator >(Time time1, Time time2) => time1.CompareTo(time2) > 0;

        public static bool operator >=(Time time1, Time time2) => time1.CompareTo(time2) >= 0;
        #endregion
    }
}
