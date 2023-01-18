using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using AC_Hamburguesa.ACModels;
using AC_Hamburguesa.ACServices;
using AC_Hamburguesa.ACViews;

namespace AC_Hamburguesa.ACViewModels
{
    public partial class ACBurgerListPageViewModel : ObservableObject
    {
        public static List<ACBurger> ACBurgerListForSearch { get; private set; } = new List<ACBurger>();
        public ObservableCollection<ACBurger> ACBurgers { get; set; } = new ObservableCollection<ACBurger>();

        private readonly ACIBurgerServices _burgerServices;
        public ACBurgerListPageViewModel(ACIBurgerServices burgerServices)
        {
            _burgerServices = burgerServices;
        }



        [ICommand]
        public async void GetACBurgersList()
        {
            ACBurgers.Clear();
            var burgerList = await _burgerServices.GetACBurgersList();
            if (burgerList?.Count > 0)
            {
                burgerList = burgerList.OrderBy(f => f.Name).ToList();
                foreach (var burger in burgerList)
                {
                    ACBurgers.Add(burger);
                }
                ACBurgerListForSearch.Clear();
                ACBurgerListForSearch.AddRange(burgerList);
            }
        }


        [ICommand]
        public async void AddUpdateACBurger()
        {
            await AppShell.Current.GoToAsync(nameof(ACBurgerItemPage));
        }


        [ICommand]
        public async void DisplayAction(ACBurger burgerModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "BurgerDetail", burgerModel }
                };
                await AppShell.Current.GoToAsync(nameof(ACBurgerItemPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _burgerServices.DeleteBurger(burgerModel);
                if (delResponse > 0)
                {
                    GetACBurgersList();
                }
            }
        }
    }
}