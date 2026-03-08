using System;
using Xunit;
using StopwatchApp;

namespace StopwatchApp.Tests
{
    public class StopwatchOperationsTests
    {
        [Fact]
        public void Start_ShouldResetElapsedTime()
        {
            var sw = new StopwatchOperations();
            sw.Start();
            Assert.Equal("00:00:00", sw.GetElapsedTime());
        }

        [Fact]
        public void Pause_And_Resume_ShouldContinueFromPausedTime()
        {
            var sw = new StopwatchOperations();
            sw.Start();
            System.Threading.Thread.Sleep(2100); // Simulate 2 seconds
            sw.Pause();
            var pausedTime = sw.GetElapsedTime();
            System.Threading.Thread.Sleep(1100); // Should not increment
            sw.Resume();
            System.Threading.Thread.Sleep(1100); // Should increment by 1
            sw.Pause();
            Assert.NotEqual(pausedTime, sw.GetElapsedTime());
        }

        [Fact]
        public void Reset_ShouldSetElapsedTimeToZero()
        {
            var sw = new StopwatchOperations();
            sw.Start();
            System.Threading.Thread.Sleep(1100);
            sw.Reset();
            Assert.Equal("00:00:00", sw.GetElapsedTime());
        }

        [Fact]
        public void Stop_ShouldKeepLastRecordedTime()
        {
            var sw = new StopwatchOperations();
            sw.Start();
            System.Threading.Thread.Sleep(1100);
            sw.Stop();
            var stoppedTime = sw.GetElapsedTime();
            System.Threading.Thread.Sleep(1100);
            Assert.Equal(stoppedTime, sw.GetElapsedTime());
        }
    }
}
