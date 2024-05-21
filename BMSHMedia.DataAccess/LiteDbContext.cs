using BMSHMedia.Model.Form;
using LiteDB;
using System;
using System.IO;

namespace BMSHMedia.DataAccess
{
    public class LiteDbContext
    {
        private static string _rootPath { get; set; }

        //public LiteDbContext(string rootPath)
        //{
        //    _rootPath = Path.Combine(rootPath, "LocalDb");
        //}

        public static void SetPath(string path)
        {
            _rootPath = Path.Combine(path, "LocalDb"); ;
        }


        public static LiteDatabase GetDb_FormPost()
        {
            string path = Path.Combine(_rootPath, "formPost.db");
            string conn = $"Filename={path};Connection=Shared;";
            return new LiteDatabase(conn);
        }
    }
}
