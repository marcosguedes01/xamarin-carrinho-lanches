using CarrinhoLanche.Models;
using CarrinhoLanche.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CarrinhoLanche.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        readonly IDataService _DataService;
        
        public new string Title
        {
            get { return base.Title ?? "Produtos"; }
            set { base.Title = value; }
        }

        ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
                OnPropertyChanged("Products");
            }
        }

        public bool NeedsRefresh { get; set; }

        public ProductsViewModel()
        {
            _Products = new ObservableCollection<Product>();

            _DataService = DependencyService.Get<IDataService>();
        }

        Command _LoadProductsCommand;

        /// <summary>
        /// Command to load accounts
        /// </summary>
        public Command LoadProductsCommand
        {
            get { return _LoadProductsCommand ?? (_LoadProductsCommand = new Command(ExecuteLoadProductsCommand)); }
        }

        async void ExecuteLoadProductsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadProductsCommand.ChangeCanExecute();

            Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync()));

            IsBusy = false;
            LoadProductsCommand.ChangeCanExecute();
        }

        Command _LoadProductsRemoteCommand;

        public Command LoadProductsRemoteCommand
        {
            get { return _LoadProductsRemoteCommand ?? (_LoadProductsRemoteCommand = new Command(ExecuteLoadProductsRemoteCommand)); }
        }

        async void ExecuteLoadProductsRemoteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadProductsRemoteCommand.ChangeCanExecute();

            Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync()));

            IsBusy = false;
            LoadProductsRemoteCommand.ChangeCanExecute();
        }
    }
}
