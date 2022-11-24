using NetSQLoad.Exceptions;
using System.Text;

namespace NetSQLoad.Helpers
{
    internal static class FileHelper
    {
        internal static Dictionary<string, string> GetQueries(string queriesPath)
        {
            Dictionary<string, string> queries = new Dictionary<string, string>();
            List<string> paths = new List<string>();
            if (!queriesPath.ToLower().EndsWith(".sql"))
            {
                if (Directory.Exists(queriesPath))
                {
                    paths = Directory.GetFiles(queriesPath, "*.sql", SearchOption.AllDirectories).ToList();
                }
            }
            else
            {
                paths.Add(queriesPath);
            }

            if(paths.Count == 0) throw new InvalidPathException($"No SQL files found in {queriesPath}.");

            foreach (var path in paths)
            {
                string queryName = string.Empty;
                StringBuilder queryValue = new();
                foreach (var line in File.ReadAllLines(path))
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    string formatedLine = line.Trim();
                    if (formatedLine.StartsWith("--"))
                    {
                        if (queryValue.Length > 0)
                        {
                            queries.Add(queryName, queryValue.ToString().Trim());
                            queryValue = new();
                        }
                        queryName = formatedLine.Split("--")[1].Trim();
                    }
                    else if (queryName != string.Empty)
                    {
                        queryValue.AppendLine(formatedLine);
                    }
                }

                if (!string.IsNullOrEmpty(queryName) && queryValue.Length > 0)
                {
                    queries.Add(queryName, queryValue.ToString().Trim());
                }
            }

            if (queries.Count == 0) throw new SQLFileFormatException("SQL files don't have the required format.");

            return queries;
        }
    }
}
