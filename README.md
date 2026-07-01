# Bildur
This is a project created for my vocational exam in IT-development

## Contents
- `/src` Main WebApp project for uploading, viewing, downloading and deleting files
- `/Migrator` Database migrator to create and update the database-schema
- `/manifests` Example manifests for a Kubernetes deployment
- `/tests` Test-directory (empty)

## Prerequisites
You will need the following to run this project:

1. Valid HelseID-credentials
2. An MSSQL Database
3. .NET 10 SDK & Runtime

Please see appsettings.json on how to structure configuration

## Running the project
After config is in place:

1. Run the migrator `dotnet run --project ./Migrator`
2. When complete, run the WebApp with `dotnet run --project ./src`