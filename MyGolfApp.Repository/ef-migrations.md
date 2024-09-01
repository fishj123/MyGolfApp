# Entity Framework Migrations

## Create a new migration
After updating the db models, run the following command from 
the root of the solution:

`dotnet ef migrations add **[NAME_OF_MIGRATION]** --project MyGolfApp.Repository --startup-project MyGolfApp --output-dir Migrations`

To undo this action, run:

`ef migrations remove`

Then, to update the database, run:

`dotnet ef database update --project MyGolfApp.Repository --startup-project MyGolfApp`
