# Ledger wallet for Zenon .NET SDK

[![nuget](https://img.shields.io/nuget/v/Zenon.Wallet.Ledger)](https://nuget.org/packages/Zenon.Wallet.Ledger) [![build](https://img.shields.io/github/actions/workflow/status/hypercore-one/znn_ledger_csharp/publish.yml?branch=main)](https://github.com/hypercore-one/znn_ledger_csharp/actions/workflows/publish.yml) [![codecov](https://img.shields.io/codecov/c/github/hypercore-one/znn_ledger_csharp?token=FWKGWMWO7U)](https://codecov.io/gh/hypercore-one/znn_ledger_csharp)

The Ledger wallet package offers a cross platform client implementation for the [Zenon Ledger App](https://github.com/hypercore-one/ledger-app-zenon). Supported platforms are Linux, OSX and Windows.

To use the library please reference the [nuget package](https://www.nuget.org/packages/Zenon.Wallet.Ledger) in your project. Additionally it is required to either ensure that [HIDAPI](https://github.com/libusb/hidapi) is available on the host system or is distributed as part of your application.

## Linux

Note that on Linux you will need to install an udev rule file with your application for unprivileged users to be able to access HID devices with hidapi. 
Refer to the [README](../../udev/) file in the udev directory for an example.

## Installation

Install the Zenon.Wallet.Ledger package from [NuGet](https://www.nuget.org/packages/Zenon.Wallet.Ledger)

```
dotnet add package Zenon.Wallet.Ledger
```

## Code Example

You can use the `LedgerWallet` class to connect to a Ledger Nano S/X/SP and Stax device:

```csharp
using Zenon;
using Zenon.Wallet;
using Zenon.Wallet.Ledger;

// Use ledger manager
using var walletManager = new LedgerManager();

// Use first wallet available
var walletDefinition =
    (await walletManager.GetWalletDefinitionsAsync()).First();

// Retrieve the wallet
var wallet =
    await walletManager.GetWalletAsync(walletDefinition);

// Get primary wallet account
var walletAccount = await wallet.GetAccountAsync(accountIndex: 0);

// Get address
var address = await walletAccount.GetAddressAsync();
```

## Contributing

Please check [CONTRIBUTING](../../CONTRIBUTING.md) for more details.

## License

The MIT License (MIT). Please check [LICENSE](../../LICENSE) for more information.