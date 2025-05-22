![Moralis.Net](https://github.com/emin-karadag/Moralis.Net/blob/main/Moralis.Net/Moralis-Logo.png)

## Moralis.Net
Web3 geliştirmeyi en az Web2 kadar kolay hale getiren platformlardan biri olan Moralis'in .NET geliştiricileri için hazırlanmış kütüphanesidir.


Moralis'in herkese açık [API dokümanı](https://docs.moralis.io/) referans alınarak C# programlama dili ile Moralis üzerinden Web3 uygulama geliştirmek isteyenler için geliştirilmiştir.

### Lisans: 
    MIT License

## Özellikleri
- NuGet aracılığıyla yükleyebilme. ([Moralis.Net](https://www.nuget.org/packages/Moralis.Net/1.0.7))
- .NET 8 desteği. (Linux/MacOS uyumluluğu)
- RestAPI, [Moralis resmi dokümanının](https://docs.moralis.io/) büyük çoğunluğunu destekler.
	- Aktif olarak yeni özellikler eklenmeye devam edilecek.

## Başlangıç
API uç noktalarını kullanabilmek için Moralis hesabı oluşturmanız gerekmektedir. 
> Eğer hesabınız yok ise [buraya tıklayarak](https://admin.moralis.io/register) Moralis'e kaydolabilirsiniz.

## Kurulum
Bu kütüphane NuGet'te mevcuttur, indirmek için çekinmeyin. ([https://www.nuget.org/packages/Moralis.Net/1.0.7](https://www.nuget.org/packages/Moralis.Net/1.0.7 "[https://www.nuget.org/packages/Moralis.Net/1.0.7](https://www.nuget.org/packages/Moralis.Net/1.0.0)"))

**NuGet PM**
```
Install-Package Moralis.Net -Version 1.0.7
```

**dotnet cli**
```
dotnet add package Moralis.Net --version 1.0.7
```
<!--
## Yol Haritası
Önümüzdeki süreçte `BinanceTR` kütüphanesine yeni özelliklerin eklenmesi ve genişletilmesi için çalışmalar yapılacaktır. Aşağıdaki tabloda üzerinde çalıştığımız yeni özellikleri görebilirsiniz.

| Özellik                 |    Durum     |  
|------------------------|:--------------:|
| OCO (Order-Cancel-Order) Desteği            |      ✔         |
| Hesap Ticaret Listesi (Account trade list)    |                |
| Para Çekme Talebi (Withdraw)                    |                |
| Para Çekme Geçmişi (Withdraw History)    |                |
| Para Yatırma Geçmişi (Deposit History)      |                |
| Para Yatırma Adresi (Deposit Address)       |                | |

!-->
## Örnek Kullanım

**Bağımlılık Enjeksiyonu (Dependency Injection):**
```csharp
using Moralis.Net.Business.Abstract;
using Moralis.Net.Business.Concrete;

services.AddSingleton<IMoralisService, MoralisManager>();
```

**Constructor'da tanımalama:**
```csharp
using Moralis.Net.Business.Abstract;

private readonly IMoralisService _moralisService;
public Test(IMoralisService moralisService)
{
   _moralisService = moralisService;
}
```

------------


**1. Web3 cüzdanındaki bakiye bilgisini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var address = "0xdc54a239B3be06E63b0DecA16c373d4480820498";
var result = await _moralisService.Web3Api.EvmChain.BalanceApi.GetNativeBalanceByWalletAsync(apiKey, address, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**2. Birden fazla Web3 cüzdanındaki bakiye bilgilerini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var addresses = new List<string> { "0xb033417E14d0EF63DBbE4f648286729637c23CA5", "0x8241c3f56F274F45758D6530952392e73951ce55" };
var result = await _moralisService.Web3Api.EvmChain.BalanceApi.GetNativeBalanceForMultipleWalletAsync(apiKey, addresses, EvmChainEnum.BSC, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**3. Dex borsasından bir tokenın fiyatını ve 24 saatlik yüzdelik değişimini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var tokenAddress = "0x7D1AfA7B718fb893dB30A3aBc0Cfc608AaCfeBB0";
var result = await _moralisService.Web3Api.EvmChain.TokenApi.GetTokenPriceAsync(apiKey, tokenAddress, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**4. Belirli bir cüzdan için o cüzdandaki token bilgilerini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var address = "0xdc54a239B3be06E63b0DecA16c373d4480820498";
var tokenAddress = new List<string> { "0xb033417E14d0EF63DBbE4f648286729637c23CA5", "0x8241c3f56F274F45758D6530952392e73951ce55" };
var result = await _moralisService.Web3Api.EvmChain.TokenApi.GetTokenBalanceByWalletAsync(apiKey, address, tokenAddress, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**5. Belirli bir cüzdan için ilk ve son transaction bilgisini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var address = "0xdc54a239B3be06E63b0DecA16c373d4480820498";
var result = await _moralisService.Web3Api.EvmChain.WalletApi.GetChainActivityByWalletAsync(apiKey, address, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**6. Bir ağda gerçekleşen transaction bilgisini okuma:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var transactionHash = "0xd059d5d0246b286e999933784f2ec2da39ee59ded12dc98467d94487968f7bbc";
var result = await _moralisService.Web3Api.EvmChain.TransactionApi.GetTransactionByHashAsync(apiKey, transactionHash, EvmChainEnum.BSC, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**7. Belirli bir cüzdana ait NFT'leri görüntüleme:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var address = "0xdc54a239B3be06E63b0DecA16c373d4480820498";
var tokenAddress = new List<string> { "0xb033417E14d0EF63DBbE4f648286729637c23CA5", "0x8241c3f56F274F45758D6530952392e73951ce55" };
var result = await _moralisService.Web3Api.EvmChain.NftApi.GetNftsByWalletAsync(apiKey, address, tokenAddresses: tokenAddress, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------

**8. Belirli bir cüzdana ait tüm NFT koleksiyonlarını görüntüleme:**
```csharp
var apiKey = "xx_moralis_api_key_xx";
var address = "0xdc54a239B3be06E63b0DecA16c373d4480820498";
var result = await _moralisService.Web3Api.EvmChain.NftApi.GetNftCollectionsByWalletAsync(apiKey, address, ct: stoppingToken);
if (result.Success)
{
    // ...
}
```

------------



## Bağış Yap
Kütüphaneyi kullanıp beğendiyseniz destek olmak amaçlı bağışta bulunabilirsiniz. Aşağıda Bitcoin ve Ethereum için cüzdan adreslerim yer almaktadır.

<img src="https://cdn.worldvectorlogo.com/logos/tether-1.svg" width="24px"> **Tether (USDT) - TRC20:** `TC3ruh9qWbwAnCHGEkschnmcYUNxGumHJS`

<img src="https://cdn.worldvectorlogo.com/logos/bitcoin.svg" width="24px"> **Bitcoin (BTC) - ERC20:** `0x4a656a72fada0ccdef737ad8cc2e39686af5efbe`

<img src="https://cdn.worldvectorlogo.com/logos/ethereum-1.svg" width="18px"> **Ethereum - ETH:** `0x4a656a72fada0ccdef737ad8cc2e39686af5efbe`
