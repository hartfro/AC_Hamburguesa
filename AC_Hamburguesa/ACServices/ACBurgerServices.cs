using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AC_Hamburguesa.ACModels;

namespace AC_Hamburguesa.ACServices
{
    public class ACBurgerServices : ACIBurgerServices
    {
        private SQLiteAsyncConnection conn;

        private async Task SetUpDb()
        {
            if (conn == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "burger.db3");
                conn = new SQLiteAsyncConnection(dbPath);
                await conn.CreateTableAsync<ACBurger>();
            }
        }

        public async Task<int> AddBurger(ACBurger burgerModel)
        {
            await SetUpDb();
            return await conn.InsertAsync(burgerModel);
        }

        public async Task<int> DeleteBurger(ACBurger burgerModel)
        {
            await SetUpDb();
            return await conn.DeleteAsync(burgerModel);
        }

        public async Task<List<ACBurger>> GetACBurgersList()
        {
            await SetUpDb();
            var burgerList = await conn.Table<ACBurger>().ToListAsync();
            return burgerList;
        }

        public async Task<int> UpdateBurger(ACBurger burgerModel)
        {
            await SetUpDb();
            return await conn.UpdateAsync(burgerModel);
        }
    }
}
