using AC_Hamburguesa.ACViews;

namespace AC_Hamburguesa;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ACBurgerItemPage), typeof(ACBurgerItemPage));
    }
}
