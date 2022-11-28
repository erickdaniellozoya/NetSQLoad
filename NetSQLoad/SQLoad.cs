using NetSQLoad.Exceptions;
using NetSQLoad.Helpers;

namespace NetSQLoad
{
    //<summary>
    //Class to load queries of one or many SQL files.
    //</summary>
    public class SQLoad
    {
        private readonly string _sqlPath;
        private readonly bool _casesensitive;
        private readonly Dictionary<string, string> _queries;
        private readonly IEnumerable<string> _files;

        //<summary>
        //Reads SQL files to provide and easy way to store and get the queries.
        //<param name="sqlPath">The path of the SQL file or files to be loaded.</param>
        //<exception cref="InvalidPathException">Thrown if the <paramref name="sqlPath"/> argument is not a valid path or if the path doesn't contains any SQL file.</exception>
        //<exception cref="SQLFileFormatException">Thrown if a SQL file doesn't contains the required format.</exception>
        //</summary>
        public SQLoad(string sqlPath) 
        {
            ExceptionValidations(sqlPath);
            _sqlPath = sqlPath;
            _casesensitive = true;
            _queries = FileHelper.GetQueries(_sqlPath, _casesensitive);
            _files = FileHelper.GetSQLFiles(_sqlPath).Select(file => new DirectoryInfo(file).Name);

        }

        //<summary>
        //Reads SQL files to provide and easy way to store and get the queries.
        //<param name="sqlPath">The path of the SQL file or files to be loaded.</param>
        //<param name="casesensitive">Indicates if the instace will be case sensitive or not. True by default.</param>
        //<exception cref="InvalidPathException">Thrown if the <paramref name="sqlPath"/> argument is not a valid path or if the path doesn't contains any SQL file.</exception>
        //<exception cref="SQLFileFormatException">Thrown if a SQL file doesn't contains the required format.</exception>
        //</summary>
        public SQLoad(string sqlPath, bool casesensitive = true)
        {
            ExceptionValidations(sqlPath);
            _sqlPath = sqlPath;
            _casesensitive = casesensitive;
            _queries = FileHelper.GetQueries(_sqlPath, _casesensitive);
            _files = FileHelper.GetSQLFiles(_sqlPath).Select(file => new DirectoryInfo(file).Name);
        }

        //<summary>
        //Provide the specified query founded in the SQL files.
        //<param name="queryName">A string representing the name of the query.</param>
        //<returns>A string representing the specified query.</returns>
        //<exception cref="QueryException">Thrown when a specified query doesn't exist.</exception>
        //</summary>
        public string Query(string queryName)
        {
            bool success = _queries.TryGetValue(_casesensitive ? queryName : queryName.ToLower(), out string? query);
            if (!success) throw new QueryException($"Query '{queryName}' was not found.");
            return query ?? "";
        }

        //<summary>
        //Provide the specified query founded in the SQL files.
        //<param name="queryName">A string representing the name of the query.</param>
        //<param name="queryParams">A object array representing the values that will be replaced in the query.</param>
        //<exception cref="QueryException">Thrown when a specified query doesn't exist.</exception>
        //<returns>A string representing the specified query.</returns>
        //</summary>
        public string Query(string queryName, params object[] queryParams)
        {
            bool success = _queries.TryGetValue(_casesensitive ? queryName : queryName.ToLower(), out string? query);
            if (!success) throw new QueryException($"Query '{queryName}' was not found.");
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

        private void ExceptionValidations(string sqlPath)
        {
            if (string.IsNullOrEmpty(sqlPath)) throw new InvalidPathException("Argument sqlPath cannot be null or empty.", sqlPath);
            if (sqlPath.ToLower().EndsWith(".sql"))
            {
                if (!File.Exists(sqlPath)) throw new InvalidPathException("The specified file doesn't exist.", sqlPath);
            }
            else
            {
                if (!Directory.Exists(sqlPath)) throw new InvalidPathException("The specified directory doesn't exist.", sqlPath);
            }
        }

        //<summary>
        //Path where SQL file or files are located.
        //</summary>
        public string Path
        {
            get
            {
                return _sqlPath;
            }
        }

        //<summary>
        //Collection with the name of the SQL files.
        //</summary>
        public IEnumerable<string> Files
        {
            get
            {
                return _files;
            }
        }

        //<summary>
        //Indicates if the instance is seted case sensitive or not.
        //</summary>
        public bool CaseSensitive
        {
            get
            {
                return _casesensitive;
            }
        }

        //<summary>
        //Collection with the queries loaded.
        //</summary>
        public IEnumerable<string> Queries
        {
            get
            {
                return _queries.Values.ToList();
            }
        }
    }
}