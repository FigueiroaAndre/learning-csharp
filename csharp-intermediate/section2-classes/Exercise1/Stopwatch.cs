using System;

namespace Exercise1
{
    class Stopwatch
    {
        private DateTime _startTime = DateTime.MinValue;
        private DateTime _endTime;
        private bool _isRunning = false;

        public TimeSpan Duration
        {
            get
            {
                if (_startTime == DateTime.MinValue)
                {
                    return TimeSpan.Zero;
                }
                if (_isRunning)
                {
                    DateTime currentTime = DateTime.Now;
                    return currentTime - _startTime;
                }
                return _endTime - _startTime;
            }
        }
        public void Start(){
            if (_isRunning)
            {
                throw new InvalidOperationException("Start");
            }

            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void Stop(){
            if (!_isRunning)
            {
                throw new InvalidOperationException("Stop");
            }

            _endTime = DateTime.Now;
            _isRunning = false;
        }
    }
}