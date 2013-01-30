# Testable Wait Handle
Wait on all wait handles in chunks, to work around the framework maximum of 64 wait handles. 

    var _handles = new List<ManualResetEvent>();
    ...
    _handles.WaitAll();

Wait handles _must_ be waited on in an MTA thread. This means you can't normally wait in a Winform or single threade test runner (like MSTest). That would require use of another extension method.

    var _handles = new List<ManualResetEvent>();
    ...
    _handles.OnMtaThread(x => x.WaitAll());
    
