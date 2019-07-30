using System;
using System.ComponentModel;

namespace StopWatch
{
    public class ViewModel: NotifyPropertyChanged
    {
        private readonly Stopwatch StopWatch = new Stopwatch();
        public TimeSpan Time => StopWatch.Time;
        public BindingList<Circle> Circles { get; } = new BindingList<Circle>();
        public Command StartStop { get; }
        public Command CircleReset { get; }

        public ViewModel()
        {
            StopWatch.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(StopWatch.Time))
                    Notify(nameof(Time));
            };

            StartStop = new Command((o) =>
            {
                if (StopWatch.IsRunning)
                    AddCircle(StopWatch.Stop());
                else
                    StopWatch.Start();
            });

            CircleReset = new Command((o) =>
            {
                if (StopWatch.IsRunning)
                    AddCircle(StopWatch.StartNew());
                else
                {
                    StopWatch.Reset();
                    Circles.Clear();
                }
            });
        }

        private void AddCircle(Circle circle)
        {
            if (Circles.Count == circle.Number)
                Circles.RemoveAt(Circles.Count - 1);
            Circles.Add(circle);
        }
    }
}
