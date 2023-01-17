using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC_Hamburguesa.ACModels;

namespace AC_Hamburguesa.ACSearchHandlers
{
    public class ACBurgerSearchHandler : SearchHandler
    {
        public IList<ACBurger> ACBurgers { get; set; }
        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = ACBurgers.Where(burger => burger.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var navParam = new Dictionary<string, object>();
            navParam.Add("ACBurgerDetail", item);
            if (!string.IsNullOrWhiteSpace(NavigationRoute))
            {
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
            }
        }
    }
}