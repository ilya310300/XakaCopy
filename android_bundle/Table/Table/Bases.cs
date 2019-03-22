using Plugin.Settings;
using ProjectX.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Table
{
    class Bases
    {
        public TableDataBase.TableRepository database;
        public TableDataBase.TableRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new TableDataBase.TableRepository("Data.db");
                }
                return database;
            }
        }
    }
}
