using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CGALDotNetConsole
{
    public class Timer
    {

        public double ElapsedMilliseconds { get; private set; }

        public double ElapsedSeconds { get; private set; }

        public long ElapsedTicks => m_watch.ElapsedTicks;

        public bool IsHighPerformance => Stopwatch.IsHighResolution;

        public bool IsRunning => m_watch.IsRunning;

        public long NanoSecondsPerTick => (1000L * 1000L * 1000L) / Stopwatch.Frequency;

        private Stopwatch m_watch;

        private static Timer s_timer;

        public Timer()
        {
            m_watch = new Stopwatch();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Timer: IsHighPerformance={0}, NanoSecondsPerTick={1}, ElapsedTicks={2}, ElapsedSeconds={3}]",
                IsHighPerformance, NanoSecondsPerTick, ElapsedTicks, ElapsedSeconds);
        }

        public void Start()
        {
            m_watch.Start();
        }

        public double Stop()
        {
            m_watch.Stop();

            ElapsedMilliseconds = (ElapsedTicks * NanoSecondsPerTick) / 1000000.0;
            ElapsedSeconds = ElapsedMilliseconds / 1000.0;

            return ElapsedMilliseconds;
        }

        public void StopAndPrintInMilliSeconds()
        {
            Stop();
            Console.WriteLine(ElapsedMilliseconds + " ms");
        }

        public double Tick()
        {
            ElapsedMilliseconds = (ElapsedTicks * NanoSecondsPerTick) / 1000000.0;
            ElapsedSeconds = ElapsedMilliseconds / 1000.0;

            return ElapsedMilliseconds;
        }

        public void Reset()
        {
            ElapsedMilliseconds = 0.0;
            ElapsedSeconds = 0.0;
            m_watch.Reset();
        }

        public static void StartTimer()
        {
            s_timer = new Timer();
            s_timer.Start();
        }

        public static double StopTimer()
        {
            return s_timer.Stop();
        }

    }
}