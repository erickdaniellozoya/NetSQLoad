using NetSQLoad.Exceptions;
using NetSQLoad.Helpers;

namespace NetSQLoad
{
    public class SQLoad
    {
        private readonly string _sqlPath;
        private readonly bool _casesensitive;
        private readonly Dictionary<string, string> _queries;

        public SQLoad(string sqlPath) 
        {
            if (string.IsNullOrEmpty(sqlPath)) throw new InvalidPathException("Argument sqlPath cannot be null or empty.");
            if (sqlPath.ToLower().EndsWith(".sql"))
            {
                if (!File.Exists(sqlPath)) throw new InvalidPathException("The specified file doesn't exist.");
            }
            else
            {
                if (!Directory.Exists(sqlPath)) throw new InvalidPathException("The specified directory doesn't exist.");
            }
            _sqlPath = sqlPath;
            _casesensitive = true;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            _queries = FileHelper.GetQueries(_sqlPath);
        }

        public SQLoad(string sqlPath, bool casesensitive = true)
        {
            if (string.IsNullOrEmpty(sqlPath)) throw new InvalidPathException("Argument sqlPath cannot be null or empty.");
            if (sqlPath.ToLower().EndsWith(".sql"))
            {
                if (!File.Exists(sqlPath)) throw new InvalidPathException("The specified file doesn't exist.");
            }
            else
            {
                if (!Directory.Exists(sqlPath)) throw new InvalidPathException("The specified directory doesn't exist.");
            }
            _sqlPath = sqlPath;
            _casesensitive = casesensitive;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            _queries = FileHelper.GetQueries(_sqlPath);
        }

        public string Query(string queryName)
        {
            bool success = _queries.TryGetValue(queryName, out string query);
            if (success) throw new QueryException($"Query '{queryName}' was not found.");
            return query ?? "";
        }

        public string Query(string queryName, params object[] queryParams)
        {
            bool success = _queries.TryGetValue(queryName, out string query);
            if (success) throw new QueryException($"Query '{queryName}' was not found.");
            for (int i = 0; i < queryParams.Length; i++)
            {
                object queryParam = queryParams[i];
                Type paramType = queryParam.GetType();
                if (paramType.Name.ToLower() == "string")
                {
                    queryParams[i] = $"'{queryParam?.ToString()?.Replace("'", string.Empty)}'";
                }
            }
            string formatedQuery = string.Format(query ?? "", queryParams);
            return formatedQuery;
        }

        public string Path
        {
            get
            {
                return _sqlPath;
            }
        }

        public bool CaseSensitive
        {
            get
            {
                return _casesensitive;
            }
        }
    }
}