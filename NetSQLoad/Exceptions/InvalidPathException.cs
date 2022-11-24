namespace NetSQLoad.Exceptions
{
    [Serializable]
    internal class InvalidPathException : Exception
    {
        internal InvalidPathException() { }

        internal InvalidPathException(string message) : base(message) { }

        internal InvalidPathException(string message, Exception innerException) : base(message, innerException) { }

        internal InvalidPathException(string message, string path) : this(message)
        {
            Path = path;
        }

        internal string Path { get; } = string.Empty;
    }
}
