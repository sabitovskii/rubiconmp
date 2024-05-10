# Small HowTo

#### To add new migration go to folder containing solution and run the following command in powershell - 
```bash
dotnet ef migrations add Initial --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj -o ../Geometry.Infrastructure/Data/Migrations
```

#### To update DB (run all migrations)
```bash
dotnet ef database update --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj
```


#### Example request for creating new rectangle:
```json
{
  "a": {
    "x": 10,
    "y": 3
  },
  "b": {
    "x": 10,
    "y": 7
  },
  "c": {
    "x": 5,
    "y": 7
  },
  "d": {
    "x": 5,
    "y": 3
  }
}
```