TrackSeries TheTVDBClient
===================

.NET Client for TheTVDB API integrated with `IHttpClientFactory` and `IServiceCollection`.

![Build](https://github.com/TrackSeries/TrackSeries.TheTVDB.Client/workflows/Build/badge.svg) [![NuGet](https://img.shields.io/nuget/v/TrackSeries.TheTVDB.Client.svg?maxAge=2592000?style=flat)](https://www.nuget.org/packages/TrackSeries.TheTVDB.Client/)

# Installing via NuGet

```
dotnet add package TrackSeries.TheTVDB.Client --version 0.1.1-pre
``` 

```
Install-Package TrackSeries.TheTVDB.Client -Version 0.1.1-pre
```

# Getting Started

The best way of using the client is adding the dependencies to the `ServiceCollection` and resolving `ITVDBClient` where you'd like to use it:

```C#
services.AddTVDBClient(options => 
{
    options.ApiKey = "Set here your API-KEY for TheTVDB";
});
```
The client will automatically manage tokens for you so you don't need to worry about it. In case you would like to authenticate specifically  to run actions over an specific TheTVDB user you can use the following:

```C#
await client.Authentication.AuthenticateAsync("Username", "UserKey");
```

Now you will be able to use the endpoints under `Users`:

```C#
var userFavoriteSeries = await client.Users.GetFavoritesAsync();
```

# Acknowledgements

Big thanks to [HristoKolev](https://github.com/HristoKolev) for his awesome work on [TvDbSharper](https://github.com/HristoKolev/TvDbSharper).
