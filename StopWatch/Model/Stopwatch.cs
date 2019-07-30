using System;
using System.Timers;

namespace StopWatch
{
    // Класс System.Diagnostics.Stopwatch выполняет как положено все задачи,
    // но нет возможности подписаться на обновление свойства Elapsed (для биндинга),
    // поэтому настоящий класс служит его оберткой с необходимыми функциями
    public class Stopwatch : NotifyPropertyChanged
    {
        private readonly System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        private readonly Timer timer = new Timer(10);
        public bool IsRunning => stopWatch.IsRunning;
        private Circle prevCircle;
        private TimeSpan time;

        public TimeSpan Time
        {
            get => time;
            private set
            {
                time = value;
                Notify();
            }
        }

        public Stopwatch()
        {
            timer.Elapsed += (s, e) => Time = stopWatch.Elapsed;
        }

        public void Start()
        {
            if (IsRunning)
                throw new InvalidOperationException("Секундомер уже запущен");
            stopWatch.Start();
            timer.Start();
        }

        public Circle Stop()
        {
            if (!IsRunning)
                throw new InvalidOperationException("Секундомер не запущен");
            stopWatch.Stop();
            timer.Stop();
            return GetNextCircle();
        }

        public Circle StartNew()
        {
            if (!IsRunning)
                throw new InvalidOperationException("Секундомер не запущен");
            prevCircle = GetNextCircle();
            return prevCircle;
        }

        public void Reset()
        {
            if (IsRunning)
                throw new InvalidOperationException("Секундомер запущен");
            Time = new TimeSpan(0);
            prevCircle = null;
            stopWatch.Reset();
        }

        private Circle GetNextCircle()
        {
            return new Circle((prevCircle?.Number ?? 0) + 1,
                Time - (prevCircle == null ? new TimeSpan(0) : prevCircle.Time),
                Time);
        }
    }
}
