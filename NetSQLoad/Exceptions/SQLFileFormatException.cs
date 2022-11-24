namespace NetSQLoad.Exceptions
{
    internal class SQLFileFormatException : Exception
    {
        public SQLFileFormatException() { }

        public SQLFileFormatException(string message) : base(message) { }
    }
}
