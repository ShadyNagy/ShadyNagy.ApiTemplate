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
