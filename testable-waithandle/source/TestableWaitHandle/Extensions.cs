using System.Collections.Generic;
using System.Linq;

namespace System.Threading
{
    public static class Extensions
    {
        private const int Maximum = 64;

        /// <summary>
        /// Wait on all wait handles in chunks, to work around the 64 
        /// handle maximum in the framework.
        /// </summary>
        public static void WaitAll<T>(this List<T> list, TimeSpan timeout)
            where T : WaitHandle
        {
            var position = 0;
            while(position <= list.Count)
            {
                var chunk = list.Skip(position).Take(Maximum);
                WaitHandle.WaitAll(chunk.ToArray(), timeout);
                position += Maximum;
            }
        }

        /// <summary>
        /// You cannot Wait on a WaitHandle in an STA thread. Use this
        /// before your call to WaitAll if you're in a Winform or single
        /// threaded test runner.
        /// </summary>
        public static void OnMtaThread<T>(this T target, Action<T> action)
        {
            var thread = new Thread(() => action(target));
            thread.SetApartmentState(ApartmentState.MTA);
            thread.Start();
            thread.Join();
        }
    }
}