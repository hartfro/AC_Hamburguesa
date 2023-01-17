using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC_Hamburguesa.ACModels;
using SQLite;


namespace AC_Hamburguesa.ACData
{
    public class ACBurgerDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public ACBurgerDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<ACBurger>();
        }
        public int AddNewBurger(ACBurger burger)
        {
            Init();
            /*
            int result = conn.Insert(burger);
            return result;*/

            if(burger.Id != 0)
            {
                return conn.Update(burger);
            }
            else
            {
                return conn.Insert(burger);
            }
        }
        public List<ACBurger> GetAllBurgers()
        {
            Init();
            List<ACBurger> burgers = conn.Table<ACBurger>().ToList();
            return burgers;
        }

        public int DeleteItem(ACBurger item)
        {
            Init();
            return conn.Delete(item);
        }
    }

}
