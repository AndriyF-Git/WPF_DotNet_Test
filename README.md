# CoinGecko API Client

A WPF (.NET, MVVM) desktop app for browsing live cryptocurrency market data via the free [CoinGecko API](https://www.coingecko.com/en/api).

## Features

- **Market Overview (Home)** — top 50 coins by market cap: rank, icon, name, symbol, price, 24h change (colored green/red), market cap. Loads automatically on start.
- **Coin Detail** — click any coin row to open its detail page: price, 24h change, market cap, 24h volume, and a list of markets/exchanges it trades on.
- **Search** — find a coin by name or symbol; click a result to open its detail page.
- **Dark / Light theme** — toggle button in the sidebar switches the whole UI live, no restart needed.
- **Loading spinner** and a **friendly error banner** on every page if a request fails (e.g. network issue or API rate limit).

## Architecture

MVVM with [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet) (`[ObservableProperty]`, `[RelayCommand]`) and DI via `Microsoft.Extensions.DependencyInjection`.

```
Models/       Coin, SearchCoin, Ticker, ... — CoinGecko API response shapes (System.Text.Json)
Services/     CoinGeckoService — HttpClient-based calls to the CoinGecko API
ViewModels/   One per page (MainViewModel, DetailViewModel, SearchViewModel)
Views/        MainWindow (shell + sidebar) and Pages hosted in a Frame
Converters/   BooleanToVisibilityConverter, PriceChangeToBrushConverter
Themes/       DarkTheme.xaml / LightTheme.xaml — swappable resource dictionaries
```

- **Navigation**: a plain WPF `Frame` in `MainWindow`. Pages are constructed via DI (each Page's constructor takes its own ViewModel and sets `DataContext`); the sidebar's Home/Search buttons call `Frame.Navigate(...)` from `MainWindow`'s code-behind. `DetailPage` is parameterized by coin id at navigation time, so it's resolved manually (via `App.Services`, a static `IServiceProvider`) rather than through the DI container.
- **Theming**: all `Brush`/`Style` lookups in the views use `DynamicResource` so that swapping `Application.Resources.MergedDictionaries[0]` between `DarkTheme.xaml` and `LightTheme.xaml` updates already-open pages immediately.
- **Error handling**: each ViewModel wraps its API calls in a try/catch and exposes `IsLoading` / `StatusMessage` / `HasStatusMessage`, bound to a loading spinner and an error banner on every page.

## Running

1. Requires the .NET SDK matching the project's target framework (`net10.0-windows`) and Windows (WPF).
2. `appsettings.local.json` holds a `CoinGeckoApiKey` used as the `x-cg-demo-api-key` header — the public CoinGecko endpoints used here don't strictly require a key, but the demo key avoids stricter anonymous rate limits.
3. Build and run:
   ```
   dotnet build
   dotnet run
   ```

## Known limitations

- The CoinGecko free tier is rate-limited; hitting it repeatedly in a short time will surface the error banner instead of data.
