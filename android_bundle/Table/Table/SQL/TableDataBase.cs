using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SQLite;
using Table;
using Xamarin.Forms;

namespace ProjectX.SQL
{
    public class TableDataBase
    {
        [Table("Subjects")]
        public class Subject
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }

            public string subject { get; set; }
            public string time { get; set; }
            public string cabinet { get; set; }
            public string prefix { get; set; }
            public string person { get; set; }
            public string id { get; set; }

            public int day { get; set; }
            public bool at_numerator { get; set; }
        }

        public class TableRepository
        {
            SQLiteConnection database;

            public TableRepository(string filename)
            {
                string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
                database = new SQLiteConnection(databasePath);
                database.CreateTable<Subject>();
            }

            public IEnumerable<Subject> GetItems()
            {
                return (from i in database.Table<Subject>() select i).ToList();
            }

            public Subject GetItem(int id)
            {
                return database.Get<Subject>(id);
            }

            public int DeleteItem(int id)
            {
                return database.Delete<Subject>(id);
            }

            public int SaveItem(Subject item)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }
    }
}
