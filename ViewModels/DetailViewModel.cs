using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_DotNet_Test.Models;
using WPF_DotNet_Test.Services;

namespace WPF_DotNet_Test.ViewModels
{
    public partial class DetailViewModel : ObservableObject
    {
        private readonly CoinGeckoService _coinGeckoService;
        private readonly string _coinId;

        [ObservableProperty]
        private Coin? coin;

        [ObservableProperty]
        private ObservableCollection<Ticker> tickers = new();

        [ObservableProperty]
        private string statusMessage = string.Empty;

        [ObservableProperty]
        private bool hasStatusMessage;

        [ObservableProperty]
        private bool isLoading;

        public DetailViewModel(string coinId, CoinGeckoService coinGeckoService)
        {
            _coinId = coinId;
            _coinGeckoService = coinGeckoService;

            _ = LoadCoinCommand.ExecuteAsync(null);
        }

        [RelayCommand]
        private async Task LoadCoin()
        {
            try
            {
                IsLoading = true;
                HasStatusMessage = false;

                var coins = await _coinGeckoService.GetTopCoinsAsync(perPage: 1, ids: _coinId);
                Coin = coins.Count > 0 ? coins[0] : null;

                var tickers = await _coinGeckoService.GetCoinTickersAsync(_coinId);
                Tickers.Clear();
                foreach (var ticker in tickers)
                    Tickers.Add(ticker);
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
