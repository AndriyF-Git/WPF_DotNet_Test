using System.Windows.Controls;
using WPF_DotNet_Test.ViewModels;

namespace WPF_DotNet_Test.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage(SearchViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewModel.CoinSelected += coinId => NavigationService?.Navigate(new DetailPage(coinId));
        }
    }
}
