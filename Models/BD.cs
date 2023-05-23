using SQLite;
using System.Xml;

namespace appMVVM.Models
{
    public class BD
    {
        private readonly SQLiteConnection _database;

        public BD()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBaseTranslater.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Traducao>();
        }

        public List<Traducao> List()
        {
            return _database.Table<Traducao>().ToList();
        }

        public int Create(Traducao entity)
        {
            return _database.Insert(entity);
        }

        public int Update(Traducao entity)
        {
            try
            {
                return _database.Update(entity);
            }
            catch(SQLite.SQLiteException ex)
            {
                return -1;
            }
        }

        public int Delete(Traducao entity)
        {
            //try
            //{
                
            //}
            //catch
            //{
            //    return -1;
            //}
            return _database.Delete(entity);
        }
    }
}
