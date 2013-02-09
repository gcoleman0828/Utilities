//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Threading;

//namespace StopWatch
//{
//    public class StopWatchTimer
//    {
//        private TimeSpan _timeStarted;
//        private TimeSpan _timeEnded;
//        private TimeSpan _elapsedTime;
//        private long _elapsedTicks;
//        private string _results;
//        private System.Diagnostics.Stopwatch _stopwatch;

//        public delegate object RunCode(object min, object max);

//        public TimeSpan TimeStarted
//        {
//            get { return _timeStarted; }
//        }

//        public TimeSpan TimeEnded
//        {
//            get { return _timeEnded; }
//        }
//        public TimeSpan ElapsedTime
//        {
//            get { return _elapsedTime; }
//        }
//        public long ElapsedTicks
//        {
//            get { return _elapsedTicks; }
//        }

//        public string Results
//        {
//            get { return _results; }
//        }

//        public StopWatchTimer()
//        {
//            _stopwatch = new Stopwatch();

//        }


//         public void StartStopWatch(int timeToCount)
//        {
//            _stopwatch.Start();
//            _timeStarted = DateTime.Now.TimeOfDay;

//            Thread.Sleep(timeToCount);
//            StopStopWatch();
//        }
//        /// <summary>
//        /// Starts the Stop watch and runs the code that has been passed in to be run
//        /// Callback will return with results
//        /// </summary>
//        /// <param name="codeToRun"> code to run. This is the code inside a method being passed to the tool to form an analysis of the performance</param>
//        /// <param name="param1"> paramater 1 that may be sent to the method</param>
//        /// <param name="param2">parameter 2 that may be sen to the method</param>
//        /// <returns></returns>
//        public object StartStopWatch( RunCode codeToRun, object param1, object param2)
//        {
//            _stopwatch.Start();
//            _timeStarted = DateTime.Now.TimeOfDay;

//            object codeReturned = codeToRun(param1, param2);

//            StopStopWatch();

//            return codeReturned;
//        }

//        /// <summary>
//        /// Stops the Stop watch upon code completion
//        /// </summary>
//        private void StopStopWatch()
//        {
//            _stopwatch.Stop();
//            _timeEnded = DateTime.Now.TimeOfDay;
//            _elapsedTicks = _stopwatch.ElapsedTicks;
//            _elapsedTime = _stopwatch.Elapsed;
//          _results = CompileResult(Convert.ToDateTime(_timeStarted.ToString()), Convert.ToDateTime(_timeEnded.ToString()), _elapsedTicks, _elapsedTime);
//        }

//        private string CompileResult(DateTime startTime, DateTime endTime, long elapsedTicks, TimeSpan elapsedTime)
//        {
//            StringBuilder builder = new StringBuilder();
//            builder.Append(
//                        @" Data From Method called:" + "Start Time: " + startTime + " ( Approx. " + Convert.ToDateTime(startTime.ToString()).ToLongTimeString() + ")" + "\n\nEnd Time: " + endTime +                                 " ( Approx. " + Convert.ToDateTime(endTime.ToString()).ToLongTimeString() + ")" +
//                       "\n\nElapsed Time: " + elapsedTime + " (Approx. " + elapsedTime.TotalSeconds + " seconds)" + "\n\nElapsed Ticks " + elapsedTicks);

//            return builder.ToString();
//        }

//    }
//}
