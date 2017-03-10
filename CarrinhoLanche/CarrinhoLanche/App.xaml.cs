using CarrinhoLanche.Pages;

using Xamarin.Forms;

namespace CarrinhoLanche
{
    public partial class App : Application
	{
        static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }

        public App ()
		{
			InitializeComponent();

            app = this;

            CurrentApp.MainPage = new RootPage();
        }        
	}
}
