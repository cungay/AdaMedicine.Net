using Ege.Net;
using System;
using System.Linq;

namespace AdaMedicine.Services
{
    public abstract class BaseRestService : RestService {
        public virtual string GetSqlQueryFromFile(string fileName) {
            if (fileName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(fileName));
            fileName = string.Concat(fileName, ".sql");
            string query = null;
            string root = "~/wwwroot/sql".MapProjectPath();
            var fs = VirtualFileSources.GetFileSystemVirtualFiles();
            var file = fs.GetAllMatchingFiles("*.sql")
                .FirstOrDefault(p => p.Name == fileName);
            if (file != null) {
                query = file.ReadAllText();
            }
            return query;
        }
    }
}
