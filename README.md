﻿# BCL Extras

This is just a collection of some handy additions to the .NET base class libraries.

## Getting Started

At the moment, there aren't any packages for these enhancements. Just copy & paste!

## Usage

### FineTimeSpan

The .NET `TimeSpan` rounds fractional milliseconds to 1. This method takes you through ticks to get a "finer" timespan.

```csharp
TimeSpan.FromMicroseconds(50)
TimeSpan.FromMilliseconds(0.5)
```

I'd really like to add extension methods, like

```csharp
50.Microseconds()
```

### Safe Event Invocation

To safely invoke an event, you need to make a local copy so that asynchronous unsubscriptions don't leave you with a `null` handler. This extension method does that for you!

```csharp
OnSomeEvent.SafeInvoke()
```

### Testable Wait Handle

Wait on all wait handles in chunks, to work around the framework maximum of 64 wait handles. 

```csharp
var _handles = new List<ManualResetEvent>();
...
_handles.WaitAll();
```

Wait handles _must_ be waited on in an MTA thread. This means you can't normally wait in a Winform or single threade test runner (like MSTest). That would require use of another extension method.

```csharp
_handles.OnMtaThread(x => x.WaitAll());
```
