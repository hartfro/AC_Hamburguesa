using AC_Hamburguesa.ACData;
using AC_Hamburguesa.ACModels;

namespace AC_Hamburguesa.ACViews;

[QueryProperty("Item","Item")]
public partial class ACBurgerItemPage : ContentPage
{
    public ACBurger Item
    {
        get => BindingContext as ACBurger;
        set => BindingContext = value;
    }

    //ACBurger Item = new ACBurger();
    //bool _flag;

    public ACBurgerItemPage()
	{
		InitializeComponent();
	}

    private void OnSaveClicked(object sender, EventArgs e)
    {
        /*
        Item.Name = ACnameB.Text;
        Item.Description = ACdescB.Text;
        Item.WithExtraCheese = _flag;*/

        App.BurgerRepo.AddNewBurger(Item);
        Shell.Current.GoToAsync("..");
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    /*
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }*/
}