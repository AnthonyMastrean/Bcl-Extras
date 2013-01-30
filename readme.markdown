# Safe Event Invocation
To safely invoke an event, you need to make a local copy so that asynchronous unsubscriptions don't leave you with a `null` handler. This extension method does that for you!

    Something.SafeInvoke()