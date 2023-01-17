using AC_Hamburguesa.ACData;

namespace AC_Hamburguesa;

public partial class App : Application
{
	public static ACBurgerDatabase BurgerRepo { get; set; }

	public App(ACBurgerDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BurgerRepo = repo;
	}

}
