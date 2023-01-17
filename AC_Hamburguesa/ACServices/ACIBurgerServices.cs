using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC_Hamburguesa.ACModels;

namespace AC_Hamburguesa.ACServices
{
    public interface ACIBurgerServices
    {
        Task<List<ACBurger>> GetACBurgersList();
        Task<int> AddBurger(ACBurger burgerModel);
        Task<int> DeleteBurger(ACBurger burgerModel);
        Task<int> UpdateBurger(ACBurger burgerModel);
    }
}
