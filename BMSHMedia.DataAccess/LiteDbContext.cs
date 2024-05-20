using BMSHMedia.Model.Form;
using LiteDB;
using System.IO;

namespace BMSHMedia.DataAccess
{
    public class LiteDbContext
    {
        private readonly string _rootPath;

        public LiteDbContext(string rootPath)
        {
            _rootPath = Path.Combine(rootPath, "liteDb");
        }


        public ILiteCollection<FormPost> GetDb_FormPost()
        {
            string conn = Path.Combine(_rootPath, "formPost.db");
            return new LiteDatabase(conn).GetCollection<FormPost>();
        }
    }
}
