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
            return _database.Update(entity);
        }

        public int Delete(Traducao entity)
        {
            return _database.Delete(entity);
        }
    }
}
