using System.Collections.Specialized;
using System.ComponentModel;

namespace System
{
    public static class Extensions
    {
        /// <summary>
        /// Invoke an Action delegate or event in a thread-safe manner. By passing the delegate
        /// as a method parameter, modifications to the original (such as unsubscribing all handlers)
        /// will not affect the local copy.
        /// </summary>
        public static void SafeInvoke(this Action action)
        {
            if(action == null) 
                return;
            
            action();
        }

        public static void SafeInvoke<T>(this Action<T> action, T obj)
        {
            if(action == null) 
                return;
            
            action(obj);
        }

        public static void SafeInvoke(this EventHandler eventHandler, object sender, EventArgs args)
        {
            if(eventHandler == null) 
                return;
            
            eventHandler(sender, args);
        }

        public static void SafeInvoke<T>(this EventHandler<T> eventHandler, object sender, T args)
            where T : EventArgs
        {
            if(eventHandler == null) 
                return;
            
            eventHandler(sender, args);
        }

        public static void SafeInvoke(this NotifyCollectionChangedEventHandler eventHandler, object sender, NotifyCollectionChangedEventArgs args)
        {
            if (eventHandler == null)
                return;

            eventHandler(sender, args);
        }

        public static void SafeInvoke(this PropertyChangedEventHandler eventHandler, object sender, PropertyChangedEventArgs args)
        {
            if (eventHandler == null)
                return;

            eventHandler(sender, args);
        }
    }
}