# Stopwatch Application

A cross-platform stopwatch app built with Avalonia UI and C#.

## Features
- Start, Pause, Resume, Reset, and Stop the timer
- Elapsed time displayed in 00:00:00 (hh:mm:ss) format
- User-friendly interface
- Test-driven development (TDD) approach
- XML documentation for all methods

## How to Run
1. Ensure you have .NET 7.0 SDK or later installed.
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build and run the app:
   ```sh
   dotnet run
   ```

## How to Test
1. Run the included unit tests:
   ```sh
   dotnet test
   ```

## Project Structure
- `StopwatchOperations.cs`: Core stopwatch logic
- `StopwatchViewModel.cs`: ViewModel for UI binding
- `MainWindow.axaml`: Avalonia UI layout
- `StopwatchApp.Tests.cs`: Unit tests for stopwatch logic


This project uses Avalonia UI for cross-platform desktop support. For more info, visit [Avalonia UI](https://avaloniaui.net/).
