using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace StopwatchApp
{
    /// <summary>
    /// ViewModel for the Stopwatch UI, binds to StopwatchOperations and exposes commands for the UI.
    /// </summary>
    public class StopwatchViewModel : INotifyPropertyChanged
    {
        private readonly StopwatchOperations _stopwatch;
        private string _elapsedTime;

        public event PropertyChangedEventHandler? PropertyChanged;

        public StopwatchViewModel()
        {
            _stopwatch = new StopwatchOperations();
            _stopwatch.ElapsedChanged += OnElapsedChanged;
            _elapsedTime = _stopwatch.GetElapsedTime();
            StartCommand = new RelayCommand(_ => Start());
            PauseCommand = new RelayCommand(_ => Pause());
            ResumeCommand = new RelayCommand(_ => Resume());
            ResetCommand = new RelayCommand(_ => Reset());
            StopCommand = new RelayCommand(_ => Stop());
        }

        /// <summary>
        /// Gets the formatted elapsed time.
        /// </summary>
        public string ElapsedTime
        {
            get => _elapsedTime;
            set { _elapsedTime = value; OnPropertyChanged(); }
        }

        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand ResumeCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand StopCommand { get; }

        private void OnElapsedChanged(TimeSpan obj)
        {
            ElapsedTime = obj.ToString(@"hh\:mm\:ss");
        }

        private void Start() => _stopwatch.Start();
        private void Pause() => _stopwatch.Pause();
        private void Resume() => _stopwatch.Resume();
        private void Reset() => _stopwatch.Reset();
        private void Stop() => _stopwatch.Stop();

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    /// <summary>
    /// Simple ICommand implementation for button binding.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        public event EventHandler? CanExecuteChanged;
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => _execute(parameter);
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
