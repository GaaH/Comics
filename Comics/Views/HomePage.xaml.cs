using Comics.ViewModels;
using Windows.UI.Xaml.Controls;


namespace Comics.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomeViewModel Vm { get; private set; }

        public HomePage()
        {
            this.InitializeComponent();
            DataContextChanged += (s, args) => Vm = args.NewValue as HomeViewModel;
        }
    }
}
