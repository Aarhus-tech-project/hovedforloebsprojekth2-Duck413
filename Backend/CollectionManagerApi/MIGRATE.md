Steps to prepare DB migrations and host on the fileserver:

1. Create an initial EF Core migration (run from project folder):

```bash
dotnet tool restore
dotnet ef migrations add InitialCreate
```

2. Apply migrations to a target SQL Server (fileserver):

```bash
dotnet ef database update --connection "Server=192.168.102.4,1433;Database=CollectionManager;Trusted_Connection=True;"
```

3. Alternatively, let the app apply migrations at startup (production): ensure `appsettings.Production.json` contains a valid `DefaultConnection` and run the app using `ASPNETCORE_ENVIRONMENT=Production`.

4. To host on the fileserver, copy the published output and run with `dotnet CollectionManagerApi.dll` or configure IIS/Windows Service.
