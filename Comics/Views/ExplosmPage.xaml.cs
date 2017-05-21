using Comics.ViewModels;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Comics.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ExplosmPage : Page
    {
        private ExplosmViewModel Vm { get; set; }

        public ExplosmPage()
        {
            this.InitializeComponent();
            DataContextChanged += (s, args) => Vm = args.NewValue as ExplosmViewModel;
        }
    }
}
