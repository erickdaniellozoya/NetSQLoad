namespace NetSQLoad.Exceptions
{
    internal class InvalidPathException : Exception
    {
        internal InvalidPathException() { }

        internal InvalidPathException(string message) : base(message) { }
    }
}
