using AC_Hamburguesa.ACModels;
using AC_Hamburguesa.ACViewModels;

namespace AC_Hamburguesa.ACViews;

public partial class ACBurgerListPage : ContentPage
{
    private ACBurgerListPageViewModel _viewModel;
    public ACBurgerListPage(ACBurgerListPageViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetACBurgersListCommand.Execute(null);
    }
}