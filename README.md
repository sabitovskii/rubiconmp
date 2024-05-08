# Small HowTo

#### To add new migration go to folder containing solution and run the following command in powershell - 
```bash
dotnet ef migrations add Initial --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj -o ../Geometry.Infrastructure/Data/Migrations
```

#### To update DB (run all migrations)
```bash
dotnet ef database update --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj -o ../Geometry.Infrastructure/Data/Migrations
```