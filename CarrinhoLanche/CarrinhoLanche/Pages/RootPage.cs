using CarrinhoLanche.Common;
using CarrinhoLanche.Pages.Products;
using CarrinhoLanche.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarrinhoLanche.Pages
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);

            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "Carrinho Lanches",
                Icon = "slideout.png"
            };

            NavigateAsync(MenuType.Products);
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.Products:
                        var page = new RootNavigationPage(new ProductListPage
                        {
                            BindingContext = new ProductsViewModel() { Navigation = this.Navigation },
                            Title = "Produtos",
                            Icon = new FileImageSource { File = "products.png" }
                        });

                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }

        void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }
    }
}
