namespace AC_Hamburguesa;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ACViews.ACBurgerItemPage), typeof(ACViews.ACBurgerItemPage));
        Routing.RegisterRoute(nameof(ACViews.ACBurgerListPage), typeof(ACViews.ACBurgerListPage));
    }
}
