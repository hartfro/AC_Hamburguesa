using AC_Hamburguesa.ACModels;
using AC_Hamburguesa.ACViewModels;

namespace AC_Hamburguesa.ACViews;

[QueryProperty("Item","Item")]
public partial class ACBurgerItemPage : ContentPage
{
    public ACBurgerItemPage(ACBurgerItemViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

}