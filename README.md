# BTC_OrderBook

## Prepare back end local enviroment

### Visual Studio way
To set up back end
Visual Studio way
1. Install [Visual Studio](https://visualstudio.microsoft.com/en/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) (has free Community version) with [ASP.NET package](https://docs.microsoft.com/en-us/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-workloads)
2. Open BTC_OrderBook/BTC_OrderBook.sln in Visual Studio
3. Change DB connection string(if it needs) in BTC_OrderBook/BTC_OrderBook/appsettings.json
4. Run BTC_OrderBook project
5. Base ApiUrl http://localhost:5172/ 


### Console way
1. Install .NET SDK
2. Move to BTC_OrderBook/BTC_OrderBook folder
3. hange DB connection string(if it needs) in BTC_OrderBook/BTC_OrderBook/appsettings.json
4. ```dotnet restore```
5. ```dotnet build -c Debug```
6. ```dotnet run -c Debug```

## Prepare front end local enviroment

# BTC_OrderBook.Front

This template should help get you started developing with Vue 3 in Vite.

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (and disable Vetur) + [TypeScript Vue Plugin (Volar)](https://marketplace.visualstudio.com/items?itemName=Vue.vscode-typescript-vue-plugin).

## Customize configuration

See [Vite Configuration Reference](https://vitejs.dev/config/).

## Project Setup

```sh
npm install
```

### Compile and Hot-Reload for Development

```sh
npm run dev
```

### Compile and Minify for Production

```sh
npm run build
```

### Lint with [ESLint](https://eslint.org/)

```sh
npm run lint
```

