using CarrinhoLanche.Statics;
using Xamarin.Forms;

namespace CarrinhoLanche.Common
{
    public class RootNavigationPage : NavigationPage
    {
        public RootNavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public RootNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Palette._001;
            BarTextColor = Color.White;
        }
    }
}
