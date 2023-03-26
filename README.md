# BTC_OrderBook

## Prepare back end local enviroment

### Visual Studio way
To set up back end
Visual Studio way
1. Install [Visual Studio](https://visualstudio.microsoft.com/en/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) (has free Community version) with [ASP.NET package](https://docs.microsoft.com/en-us/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-workloads)
2. Open BTC_OrderBook/BTC_OrderBook.sln in Visual Studio
3. Change DB connection string(if it needs) in BTC_OrderBook/BTC_OrderBook/appsettings.json
4. Run BTC_OrderBook project


### Console way
1. Install .NET SDK
2. Move to BTC_OrderBook/BTC_OrderBook folder
3. hange DB connection string(if it needs) in BTC_OrderBook/BTC_OrderBook/appsettings.json
4. ```dotnet restore```
5. ```dotnet build -c Debug```
6. ```dotnet run -c Debug```

## Prepare front end local enviroment

1. Open BTC_OrderBook/BTC_OrderBook.Front/index.html
