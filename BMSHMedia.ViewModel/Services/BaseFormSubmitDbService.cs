using BMSHMedia.DataAccess;
using BMSHMedia.Model.Form;
using LiteDB;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSHMedia.ViewModel.Services
{
    public class BaseFormSubmitDbService
    {
        private string _dbPath { get; set; }

        public BaseFormSubmitDbService(string path)
        {
            _dbPath = path;
        }

        private LiteDatabase GetDb()
        {
            string conn = $"Filename={_dbPath};Connection=Shared;";
            return new LiteDatabase(conn);
        }

        public void Insert(BaseFormSubmit form)
        {
            using var db = GetDb();
            db.GetCollection<BaseFormSubmit>().Insert(form);
        }

        public List<BaseFormSubmit> GetByBaseFormID(string baseFormID)
        {
            using var db = GetDb();
            return db.GetCollection<BaseFormSubmit>().Find(x => x.BaseFormId.ToLower() == baseFormID.ToLower()).ToList();
        }

        public void DeleteAll(string baseFormID)
        {
            using var db = GetDb();
            db.GetCollection<BaseFormSubmit>().DeleteMany(x => x.BaseFormId == baseFormID);
        }
    }
}
