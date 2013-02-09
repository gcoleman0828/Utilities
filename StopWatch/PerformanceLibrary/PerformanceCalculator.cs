using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Performance.PerformanceLibrary
{

    /// <summary>
    /// This class is used to do performance calculations against various
    /// methods. The code is generic, so any paramaters can be passed into it
    /// and any code that you want to ensure has good performance can be
    /// computated using this class
    /// </summary>
    public class PerformanceCalculator
    {
        #region PRIVATE FIELDS

        private TimeSpan _timeStarted;
        private TimeSpan _timeEnded;
        private TimeSpan _elapsedTime;
        private long _elapsedTicks;
        private string _results;
        private System.Diagnostics.Stopwatch _stopwatch;

        #endregion

        /// <summary>
        /// This is the delegate that will mimic the 
        /// signature if your application that will run within the 
        /// Performance Calculator.When the code is run, the 
        ///  method will be called back with the results upon
        ///  completion currently supports 2 parameters
        /// Could be expaned in the future
        /// </summary>
        /// <param name="param1">The first parameter</param>
        /// <param name="param2">The second parameter</param>
        /// <returns></returns>
        public delegate object RunCode(object param1, object param2);


        #region PUBLIC PROPERTIES

        /// <summary>
        /// Gets the time the application started in type TimeSpan
        /// for beter accruacy.
        /// </summary>
        /// <value>
        /// The time started.
        /// </value>
        public TimeSpan TimeStarted
        {
            get { return _timeStarted; }
        }

        /// <summary>
        /// Gets the time the application ended in type TimeSpan
        /// for beter accruacy.
        /// </summary>
        /// <value>
        /// The time ended.
        /// </value>
        public TimeSpan TimeEnded
        {
            get { return _timeEnded; }
        }
        /// <summary>
        /// Gets the elapsed time  from the application run time.
        /// </summary>
        /// <value>
        /// The elapsed time.
        /// </value>
        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
        }


        /// <summary>
        /// Gets the elapsed ticks from the applications run time.
        /// </summary>
        /// <value>
        /// The elapsed ticks.
        /// </value>
        public long ElapsedTicks
        {
            get { return _elapsedTicks; }
        }


        /// <summary>
        /// Provides a user friendly 
        /// version of the results. This is only provided if
        /// addUserFriendlyResult is sett to true upon stopping the 
        /// stop watch. Otherwise, the field is not set and returns null
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public string Results
        {
            get { return _results; }
        }

        #endregion

        #region CONSTRUCTOR(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceCalculator"/> class.
        /// </summary>
        public PerformanceCalculator()
        {
            _stopwatch = new Stopwatch();

        }


        #endregion

        /// <summary>
        /// Starts the stop watch. This overload is only for testing the tool. 
        /// </summary>
        /// <param name="timeToCount">The time to count.</param>
        /// <param name="addUserFriendlyResult">if set to <c>true</c> [add user friendly result].</param>
        public void StartStopWatch(int timeToCount, bool addUserFriendlyResult)
        {
            _stopwatch.Start();
            _timeStarted = DateTime.Now.TimeOfDay;

            Thread.Sleep(timeToCount);
            StopStopWatch(addUserFriendlyResult);
        }

        /// <summary>
        /// Starts the Stop watch and runs the code that has been passed in to be run
        /// Callback will return with results
        /// </summary>
        /// <param name="codeToRun"> code to run. This is the code inside a method being passed to the tool to form an analysis of the performance
        /// [It is required that you fill the to paramaters into you delegate, null is excepted]</param>
        /// <param name="param1"> paramater 1 that may be sent to the method [null if you are not going to need paramaters]</param>
        /// <param name="param2">parameter 2 that may be sen to the method [null if you are not going to need paramaters]</param>
        /// <returns></returns>
        public object StartStopWatch(RunCode codeToRun, object param1, object param2, bool addUserFriendlyResult)
        {
            _stopwatch.Start();
            _timeStarted = DateTime.Now.TimeOfDay;

            object codeReturned = codeToRun(param1, param2);

            StopStopWatch(addUserFriendlyResult);

            return codeReturned;
        }

        
        /// <summary>
        /// Stops the stop watch.
        /// </summary>
        /// <param name="addUserFriendlyResult">if set to <c>true</c> [Results property will be set to a user friendly result] if <c>false</c> [Result resturns null].</param>
        private void StopStopWatch(bool addUserFriendlyResult)
        {
            _stopwatch.Stop();
            _timeEnded = DateTime.Now.TimeOfDay;
            _elapsedTicks = _stopwatch.ElapsedTicks;
            _elapsedTime = _stopwatch.Elapsed;

            if (addUserFriendlyResult)
                _results = CompileResult(Convert.ToDateTime(_timeStarted.ToString()), Convert.ToDateTime(_timeEnded.ToString()), _elapsedTicks, _elapsedTime);

        }


        /// <summary>
        /// Compiles the results from the application run in a friendly format
        /// for quick results.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="elapsedTicks">The elapsed ticks.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <returns></returns>
        private string CompileResult(DateTime startTime, DateTime endTime, long elapsedTicks, TimeSpan elapsedTime)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(
                        @" Data From Method called: " + "Start Time: " + startTime + " ( Approx. " + Convert.ToDateTime(startTime.ToString()).ToLongTimeString() + ")" + "\n\nEnd Time: " + endTime + " ( Approx. " + Convert.ToDateTime(endTime.ToString()).ToLongTimeString() + ")" +
                       "\n\nElapsed Time: " + elapsedTime + " (Approx. " + elapsedTime.TotalSeconds + " seconds)" + "\n\nElapsed Ticks " + elapsedTicks);

            return builder.ToString();
        }
    }
}
