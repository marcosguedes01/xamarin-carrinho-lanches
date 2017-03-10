using CarrinhoLanche.Common;
using CarrinhoLanche.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrinhoLanche.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<HomeMenuItem> menuItems;
        RootPage rootPage;

        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();

            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "Carrinho Lanches",
                Subtitle = "Carrinho Lanches",
                Icon = "slideout.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Produtos", MenuType = MenuType.Products, Icon = "products.png" },
                    //new HomeMenuItem { Title = "Vendas", MenuType = MenuType.Sales, Icon ="sales.png" },
                    //new HomeMenuItem { Title = "Clientes", MenuType = MenuType.Customers, Icon = "customers.png" },
                    new HomeMenuItem { Title = "Sobre", MenuType = MenuType.About, Icon = "about.png" },

                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
            };
        }
    }
}
