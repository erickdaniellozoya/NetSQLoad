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
            _sqlPath = sqlPath;
            _casesensitive = true;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            _queries = FileHelper.GetQueries(_sqlPath);
        }

        public SQLoad(string sqlPath, bool casesensitive)
        {
            _sqlPath = sqlPath;
            _casesensitive = casesensitive;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            _queries = FileHelper.GetQueries(_sqlPath);
        }

        public string Query(string queryName)
        {
            _queries.TryGetValue(queryName, out string query);
            return query;
        }

        public string Query(string queryName, params object[] queryParams)
        {
            _queries.TryGetValue(queryName, out string query);
            for (int i = 0; i < queryParams.Length; i++)
            {
                object queryParam = queryParams[i];
                Type paramType = queryParam.GetType();
                if (paramType.Name.ToLower() == "string")
                {
                    queryParams[i] = $"'{queryParam.ToString().Replace("'", string.Empty)}'";
                }
            }
            string formatedQuery = string.Format(query, queryParams);
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