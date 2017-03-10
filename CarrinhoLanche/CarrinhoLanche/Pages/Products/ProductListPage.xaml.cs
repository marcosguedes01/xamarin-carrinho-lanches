
using CarrinhoLanche.Pages.Base;
using CarrinhoLanche.ViewModels;
using Xamarin.Forms;

namespace CarrinhoLanche.Pages.Products
{
    public partial class ProductListPage : ProductListPageXaml
    {
        public ProductListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.IsInitialized)
                return;

            ViewModel.LoadProductsCommand.Execute(null);

            ViewModel.IsInitialized = true;
        }

        async void ProductItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Product catalogProduct = ((Product)e.Item);
            //await Navigation.PushAsync(new ProductDetailPage() { BindingContext = new ProductDetailViewModel(catalogProduct, ViewModel.IsPerformingProductSelection) { Navigation = ViewModel.Navigation } });
        }
    }
    public abstract class ProductListPageXaml : ModelBoundContentPage<ProductsViewModel> { }
}