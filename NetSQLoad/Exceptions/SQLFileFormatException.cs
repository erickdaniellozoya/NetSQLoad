namespace NetSQLoad.Exceptions
{
    internal class SQLFileFormatException : Exception
    {
        internal SQLFileFormatException() { }

        internal SQLFileFormatException(string message) : base(message) { }
    }
}
