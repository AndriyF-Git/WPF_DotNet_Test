using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using WPF_DotNet_Test.Services;
using WPF_DotNet_Test.ViewModels;

namespace WPF_DotNet_Test.Views
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage(string coinId)
        {
            InitializeComponent();

            var coinGeckoService = App.Services.GetRequiredService<CoinGeckoService>();
            DataContext = new DetailViewModel(coinId, coinGeckoService);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
                NavigationService.GoBack();
        }
    }
}
