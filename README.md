[![.NET Core](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/workflows/.NET%20Core/badge.svg)](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions)
[![publish ShadyNagy.ApiTemplate to nuget](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions/workflows/publish.yml/badge.svg)](https://github.com/ShadyNagy/ShadyNagy.ApiTemplate/actions/workflows/publish.yml)
[![ShadyNagy.ApiTemplate on NuGet](https://img.shields.io/nuget/v/ShadyNagy.ApiTemplate?label=ShadyNagy.ApiTemplate)](https://www.nuget.org/packages/ShadyNagy.ApiTemplate/)

# ShadyNagy.ApiTemplate


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
