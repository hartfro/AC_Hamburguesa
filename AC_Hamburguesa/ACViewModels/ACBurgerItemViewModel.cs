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
using System.ComponentModel;


namespace AC_Hamburguesa.ACViewModels
{
    [QueryProperty(nameof(BurgerDetail), "BurgerDetail")]
    public partial class ACBurgerItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private ACBurger _burgerDetail = new ACBurger();

        private readonly ACIBurgerServices _burgerService;
        public ACBurgerItemViewModel(ACIBurgerServices burgerService)
        {
            _burgerService = burgerService;
        }

        [ICommand]
        public async void AddUpdateACBurger()
        {
            int response = -1;
            if (BurgerDetail.Id > 0)
            {
                response = await _burgerService.UpdateBurger(BurgerDetail);
            }
            else
            {
                response = await _burgerService.AddBurger(new ACModels.ACBurger
                {
                    Name = BurgerDetail.Name,
                    Description = BurgerDetail.Description,
                    WithExtraCheese = BurgerDetail.WithExtraCheese,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Burger Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Warning!", "Something went wrong while adding record", "OK");
            }
        }

    }
}
