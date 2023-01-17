using AC_Hamburguesa.ACModels;
//using Bumptech.Glide.Load.Model;

namespace AC_Hamburguesa.ACViews;

public partial class ACBurgerListPage : ContentPage
{
	public ACBurgerListPage()
	{
        InitializeComponent();
        LoadData();
    }

    protected override void OnAppearing()
    {
        LoadData();
    }

    private void LoadData()
    {
        List<ACBurger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
        burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ACBurgerItemPage));
        base.OnAppearing();
    }
}