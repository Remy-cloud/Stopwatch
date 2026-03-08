# Stopwatch Application (SWA)

> A cross-platform desktop stopwatch built with **C#**, **Avalonia UI**, and the **MVVM** architectural pattern. The application supports full stopwatch operations — Start, Pause, Resume, Reset, and Stop. It also displays elapsed time in a clean `hh:mm:ss` format. All core logic is covered by unit tests written using the xUnit framework.

---

## Application Screenshot

![Stopwatch Application in Action](https://private-us-east-1.manuscdn.com/sessionFile/cNTEU3cQU5YpWY61X5L1VJ/sandbox/VDRLQegPiNCLFid5HzCF0M-images_1773001568468_na1fn_L2hvbWUvdWJ1bnR1L291dHB1dC9zdG9wd2F0Y2gtc2NyZWVuc2hvdA.jpeg?Policy=eyJTdGF0ZW1lbnQiOlt7IlJlc291cmNlIjoiaHR0cHM6Ly9wcml2YXRlLXVzLWVhc3QtMS5tYW51c2Nkbi5jb20vc2Vzc2lvbkZpbGUvY05URVUzY1FVNVlwV1k2MVg1TDFWSi9zYW5kYm94L1ZEUkxRZWdQaU5DTEZpZDVIekNGME0taW1hZ2VzXzE3NzMwMDE1Njg0NjhfbmExZm5fTDJodmJXVXZkV0oxYm5SMUwyOTFkSEIxZEM5emRHOXdkMkYwWTJndGMyTnlaV1Z1YzJodmRBLmpwZWciLCJDb25kaXRpb24iOnsiRGF0ZUxlc3NUaGFuIjp7IkFXUzpFcG9jaFRpbWUiOjE3OTg3NjE2MDB9fX1dfQ__&Key-Pair-Id=K2HSFNDJXOU9YS&Signature=t-g3AocDuVFIE3QFx0Ymmx7ivAZRME-pYWDLlT3epGGiOsT7UK5pUQqF1ex83NJsXeoeOeVBba1IBzTubl4aWV2j8hbW-xP~pn5vSN~l48QY4juvSLn~SOqGC9VJGMcnf4sfd~av9ayXrjk6JM6iO27XGa2Ai5xjf1j81f9YUaWfIK00k6I8A5PCw6aQwGtRK9sn~Aph9ae4VXPbVf~nF~Bz2Qe6As-1HUa9Vf9pDiTuTKIsaWuKFbBMoDaZ0jxWbgFRjier0luA38U0oM6idfReEDzEH9STgIAhobEzXm9Kq2Ib0ZbpV1plfhmduH4hy1IXEZNisSZGjt5KdtfhPg__)

*The stopwatch running at 00:09:03, with all control buttons visible - Start, Pause, Resume, Reset, and Stop.*

---


## Project Overview

The **Stopwatch Application (SWA)** is a lightweight desktop utility that allows users to measure elapsed time with precision. It was developed following a **Test-Driven Development (TDD)** methodology, ensuring that every core operation is validated by automated tests before the UI is wired up. The application targets **.NET 7.0** and runs on Windows, macOS, and Linux through the cross-platform Avalonia UI framework.

---

## Project Structure

```
Stopwatch-main/
└── swa/
    ├── .github/
    │   └── copilot-instructions.md       # GitHub Copilot workspace instructions
    ├── StopwatchApp.Tests/
    │   ├── StopwatchApp.Tests.csproj     # Test project configuration
    │   └── StopwatchOperationsTests.cs   # xUnit unit tests
    ├── App.axaml                         # Avalonia application definition
    ├── App.axaml.cs                      # Application code-behind
    ├── MainWindow.axaml                  # Main UI layout (XAML)
    ├── MainWindow.axaml.cs               # Window code-behind
    ├── Program.cs                        # Application entry point
    ├── StopwatchOperations.cs            # Core stopwatch logic (Model)
    ├── StopwatchViewModel.cs             # ViewModel with commands and bindings
    ├── app.manifest                      # Windows application manifest
    └── swa.csproj                        # Main project configuration
```

---

## Prerequisites

Before running the application, ensure the following are installed on your machine:

| Requirement | Version | Download |
|---|---|---|
| **.NET SDK** | 7.0 or later | [dotnet.microsoft.com](https://dotnet.microsoft.com/download) |
| **Git** | Any recent version | [git-scm.com](https://git-scm.com) |

You can verify your .NET installation by running:

```sh
dotnet --version
```

---

## How to Run the Application

Follow these steps to clone, build, and launch the stopwatch on your local machine.

**Step 1 — Clone the repository:**

```sh
git clone https://github.com/Remy-cloud/Stopwatch.git
cd Stopwatch/swa
```

**Step 2 — Restore NuGet dependencies:**

```sh
dotnet restore
```

**Step 3 — Build and run the application:**

```sh
dotnet run
```

The stopwatch window will open automatically. Use the on-screen buttons to control the timer.

---

## How to Run the Tests

The test suite is located in the `StopwatchApp.Tests` subdirectory. To execute all unit tests, navigate to the test project folder and run:

```sh
cd StopwatchApp.Tests
dotnet test
```

A summary of passed and failed tests will be printed to the terminal. All four tests should pass on a clean build.

---

## Features

The application provides the following stopwatch controls:

| Button | Behaviour |
|---|---|
| **Start** | Resets the timer to `00:00:00` and begins counting |
| **Pause** | Freezes the timer at the current elapsed time |
| **Resume** | Continues counting from the paused time |
| **Reset** | Sets the display back to `00:00:00` without stopping the timer engine |
| **Stop** | Halts the timer and preserves the last recorded time on screen |

Elapsed time is always displayed in `hh:mm:ss` (hours:minutes:seconds) format.

---

## How the Application Works

### Core Logic — `StopwatchOperations.cs`

The `StopwatchOperations` class is the heart of the application. It uses a `System.Timers.Timer` that fires every **1000 milliseconds (1 second)**. On each tick, the internal `_elapsed` `TimeSpan` is incremented by one second, and an `ElapsedChanged` event is raised to notify any subscribers (the ViewModel) of the new time.

- **`Start()`** resets `_elapsed` to zero and starts the timer.
- **`Pause()`** stops the timer without clearing `_elapsed`.
- **`Resume()`** restarts the timer from the current `_elapsed` value.
- **`Reset()`** sets `_elapsed` back to zero and fires the event to update the display.
- **`Stop()`** stops the timer and fires the event one final time to lock the displayed value.
- **`GetElapsedTime()`** returns the elapsed time formatted as `hh:mm:ss`.

### ViewModel — `StopwatchViewModel.cs`

The `StopwatchViewModel` implements `INotifyPropertyChanged`, which allows the Avalonia UI to automatically update the displayed time whenever the `ElapsedTime` property changes. Each button on the UI is bound to a corresponding `ICommand` (implemented via the `RelayCommand` helper class), which delegates to the appropriate method on `StopwatchOperations`.

### View — `MainWindow.axaml`

The UI is declared in Avalonia XAML. A `TextBlock` displays the bound `ElapsedTime` property in a large 36pt font. Five `Button` controls are arranged horizontally, each bound to its respective command in the ViewModel. The window is designed at 400×250 pixels and is centered both horizontally and vertically.

---

## Unit Tests

The `StopwatchOperationsTests` class contains four xUnit `[Fact]` tests that validate the core stopwatch behaviour:

| Test Name | What It Verifies |
|---|---|
| `Start_ShouldResetElapsedTime` | Calling `Start()` always resets the time to `00:00:00` |
| `Pause_And_Resume_ShouldContinueFromPausedTime` | After pausing and resuming, the timer continues from where it left off |
| `Reset_ShouldSetElapsedTimeToZero` | Calling `Reset()` returns the displayed time to `00:00:00` |
| `Stop_ShouldKeepLastRecordedTime` | After `Stop()`, the displayed time does not change even if time passes |

---

## Technologies Used

| Technology | Purpose |
|---|---|
| **C# / .NET 7.0** | Primary programming language and runtime |
| **Avalonia UI 11.3** | Cross-platform desktop UI framework |
| **MVVM Pattern** | Architectural pattern for UI/logic separation |
| **xUnit 2.4** | Unit testing framework |
| **System.Timers.Timer** | Timer mechanism for tracking elapsed seconds |
| **INotifyPropertyChanged** | Data binding interface for live UI updates |
| **RelayCommand** | Custom `ICommand` implementation for button bindings |

---

*For more information on Avalonia UI, visit [avaloniaui.net](https://avaloniaui.net/).*
