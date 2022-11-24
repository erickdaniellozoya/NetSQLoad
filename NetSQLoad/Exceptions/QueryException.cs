namespace NetSQLoad.Exceptions
{
    [Serializable]
    internal class QueryException : Exception
    {
        internal QueryException() { }

        internal QueryException(string message) : base(message) { }
    }
}
