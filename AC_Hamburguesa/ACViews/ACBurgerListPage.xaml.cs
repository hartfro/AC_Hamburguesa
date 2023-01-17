using AC_Hamburguesa.ACModels;
//using Bumptech.Glide.Load.Model;

namespace AC_Hamburguesa.ACViews;

public partial class ACBurgerListPage : ContentPage
{
	public ACBurgerListPage()
	{
        InitializeComponent();
        BindingContext = this;
    }
    public void OnItemAdded(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ACBurgerItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new ACBurger()
        });
        //base.OnAppearing();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        List<ACBurger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }

    private void LoadData()
    {
        List<ACBurger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
        burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    protected override void OnAppearing()
    {
        LoadData();
    }

    private void burgerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}