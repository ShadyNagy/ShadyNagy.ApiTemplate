[![.NET Core](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/workflows/.NET%20Core/badge.svg)](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions)
[![publish to nuget](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions/workflows/publish.yml/badge.svg)](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions/workflows/publish.yml)
[![ShadyNagy.ApiTemplate on NuGet](https://img.shields.io/nuget/v/ShadyNagy.ApiTemplate?label=ShadyNagy.ApiTemplate)](https://www.nuget.org/packages/ShadyNagy.ApiTemplate/)
[![NuGet](https://img.shields.io/nuget/dt/ShadyNagy.ApiTemplate)](https://www.nuget.org/packages/ShadyNagy.ApiTemplate)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/ShadyNagy/Utilities/blob/master/LICENSE)

# ShadyNagy.ApiTemplate

A starting point for Clean Architecture Endpoints with ASP.NET Core. [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) is just the latest in a series of names for the same loosely-coupled, dependency-inverted architecture. You will also find it named [hexagonal](http://alistair.cockburn.us/Hexagonal+architecture), [ports-and-adapters](http://www.dossier-andreas.net/software_architecture/ports_and_adapters.html), or [onion architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/).

## Give a Star! :star:
If you like or are using this project to learn or start your solution, please give it a star. Thanks!

Or if you're feeling really generous, we now support GitHub sponsorships - see the button above.

## EF Migrations Commands

Ensure the tool EF was already installed. You can find some help here
```powershell
setx PATH "%PATH%;C:\Users\USER_NAME\.dotnet\tools" 
dotnet tool install --global dotnet-ef
```

Add a new migration (from the ShadyNagy.ApiTemplate.Api folder):

```powershell
dotnet ef migrations add MIGRATIONNAME -c appdbcontext -p ../ShadyNagy.ApiTemplate.Infrastructure/ShadyNagy.ApiTemplate.Infrastructure.csproj -s ShadyNagy.ApiTemplate.Api.csproj -o Data/Migrations
```

Update AppDbContext model (from the ShadyNagy.ApiTemplate.Api folder):

```powershell
dotnet ef database update -c appdbcontext -p ../ShadyNagy.ApiTemplate.Infrastructure/ShadyNagy.ApiTemplate.Infrastructure.csproj -s ShadyNagy.ApiTemplate.Api.csproj
```

Generate Idempotent Update Script (for production)(from the ShadyNagy.ApiTemplate.Api folder):

```powershell
dotnet ef migrations script -c AppDbContext -i -o migrate.sql -p ../ShadyNagy.ApiTemplate.Infrastructure/ShadyNagy.ApiTemplate.Infrastructure.csproj -s ShadyNagy.ApiTemplate.Api.csproj
```

### Some CLI
```powershell
dotnet format whitespace
dotnet format style
```
