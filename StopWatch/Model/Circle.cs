using System;
using System.ComponentModel;

namespace StopWatch
{
    public class Circle
    {
        public int Number { get; }
        public TimeSpan Difference { get; }
        public TimeSpan Time { get; }

        public Circle(int number, TimeSpan difference, TimeSpan time)
        {
            Number = number;
            Difference = difference;
            Time = time;
        }
    }
}