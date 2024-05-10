# Small HowTo

#### To add new migration go to folder containing solution and run the following command in powershell
```bash
dotnet ef migrations add Initial --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj -o ../Geometry.Infrastructure/Data/Migrations
```

#### To update DB (run all migrations)
```bash
dotnet ef database update --project ../Geometry.Infrastructure/ --startup-project Geometry.API.csproj
```

#### Example request for creating new rectangle:
POST api/rectangles
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

#### Example request for getting intersecting rectangles for the segment:
POST api/rectangles/intersect
```json
{
  "start": {
    "x": 10,
    "y": 3
  },
  "end": {
    "x": -13,
    "y": 7
  }
}
```

#### To prepare Postgres DB for the project I use docker desktop (I'm using Windows)
```bash
docker run --name rubiconmp-postgres -e POSTGRES_PASSWORD=password -e POSTGRES_USER=root -e POSTGRES_DB=geometry_db -p 5430:5432 -d postgres
```