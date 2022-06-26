I. If a connectionString is null or empty, then setup the environment variable by:
$env:WENDLER_TRAINING_PLANNER_CONNECTION_STRING='{database connection string here}'

1. To add migration
dotnet ef migrations add {Migration-Name} --project WendlerTrainingPlanner.Infrastructure.EF.Migrations --startup-project WendlerTrainingPlanner.Api

2. To update database
Update-database


a) Create a postgres user: WendlerTrainingPlanner
b) Create and name a database as: WendlerTrainingPlanner and grant privilages or set the user as owner
c) Update the connectionString to the database defined in launchSettings.json and/or in environment variables
d) Create extension in the database: uuid-ossp
e) Run "Update-database"

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli