using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_DotNet_Test.Models;
using WPF_DotNet_Test.Services;

namespace WPF_DotNet_Test.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly CoinGeckoService _coinGeckoService;

        [ObservableProperty]
        private string statusMessage = "Press the button to load coins";

        [ObservableProperty]
        private bool hasStatusMessage = true;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private ObservableCollection<Coin> coins = new();

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
                HasStatusMessage = false;
                Coins.Clear();

                var result = await _coinGeckoService.GetTopCoinsAsync();

                foreach (var coin in result)
                    Coins.Add(coin);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                HasStatusMessage = true;
            }
            finally
            {
                IsLoading = false;
            }
        }

    }
}