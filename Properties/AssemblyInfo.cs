using System.Reflection;

[assembly: AssemblyTitle("SafeEvents")]
[assembly: AssemblyProduct("SafeEvents")]
[assembly: AssemblyCopyright("Copyright © Anthony Mastrean 2013")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#elif RELEASE
[assembly: AssemblyConfiguration("RELEASE")]
#endif