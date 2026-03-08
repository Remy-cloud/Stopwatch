using System;
using Timers = System.Timers;

namespace StopwatchApp
{
    /// <summary>
    /// Provides core stopwatch operations: start, pause, resume, reset, and stop.
    /// </summary>
    public class StopwatchOperations
    {
        private Timers.Timer _timer;
        private TimeSpan _elapsed;
        private bool _isRunning;

        /// <summary>
        /// Occurs every second when the stopwatch is running.
        /// </summary>
        public event Action<TimeSpan>? ElapsedChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="StopwatchOperations"/> class.
        /// </summary>
        public StopwatchOperations()
        {
            _timer = new Timers.Timer(1000);
            _timer.Elapsed += (s, e) => Tick();
            _elapsed = TimeSpan.Zero;
        }

        /// <summary>
        /// Starts the stopwatch from 00:00:00.
        /// </summary>
        public void Start()
        {
            _elapsed = TimeSpan.Zero;
            _isRunning = true;
            _timer.Start();
            ElapsedChanged?.Invoke(_elapsed);
        }

        /// <summary>
        /// Pauses the stopwatch.
        /// </summary>
        public void Pause()
        {
            _isRunning = false;
            _timer.Stop();
        }

        /// <summary>
        /// Resumes the stopwatch from the last paused time.
        /// </summary>
        public void Resume()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _timer.Start();
            }
        }

        /// <summary>
        /// Resets the stopwatch to 00:00:00.
        /// </summary>
        public void Reset()
        {
            _elapsed = TimeSpan.Zero;
            ElapsedChanged?.Invoke(_elapsed);
        }

        /// <summary>
        /// Stops the stopwatch and displays the last recorded time.
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            _timer.Stop();
            ElapsedChanged?.Invoke(_elapsed);
        }

        /// <summary>
        /// Gets the elapsed time in hh:mm:ss format.
        /// </summary>
        /// <returns>Elapsed time as a string.</returns>
        public string GetElapsedTime()
        {
            return _elapsed.ToString(@"hh\:mm\:ss");
        }

        private void Tick()
        {
            if (_isRunning)
            {
                _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
                ElapsedChanged?.Invoke(_elapsed);
            }
        }
    }
}
