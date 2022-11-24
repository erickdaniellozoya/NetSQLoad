namespace NetSQLoad.Exceptions
{
    internal class QueryException : Exception
    {
        internal QueryException() { }

        internal QueryException(string message) : base(message) { }
    }
}
