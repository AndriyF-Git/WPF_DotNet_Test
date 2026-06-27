using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_DotNet_Test.Services;

namespace WPF_DotNet_Test.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly CoinGeckoService _coinGeckoService;

        [ObservableProperty]
        private string result = "Press the button to load coins data";

        [ObservableProperty]
        private bool isLoading;

        public MainViewModel(CoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
        }

        [RelayCommand]
        private async Task LoadCoins()
        {
            try
            {
                IsLoading = true;
                Result = "Loading...";

                var json = await _coinGeckoService.GetTopCoinsAsync();
                Result = json;
            }
            catch (Exception ex)
            {
                Result = $"Error: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
