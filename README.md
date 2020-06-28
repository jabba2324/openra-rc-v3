# Reademe

## Environment setup
* Install .NET Core SDK [form here](https://dotnet.microsoft.com/download)
* Install MariaDB [from here](https://mariadb.org/download/) or using docker (instructions below)
* Install Flyway [from here](https://flywaydb.org/download/)

## Database (Docker)
Download the mariadb docker image

`docker pull mariadb`

Start the db server, replace `#{your db password}#` with your desired password

`docker run --name open-ra-rc -e MYSQL_ROOT_PASSWORD=#{your db password}# -p 3306:3306 -d mariadb:latest`

Get the IP address of the server, replace `#{your docker process id}#` with the docker process id for your database server

`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' #{your docker process id}#`

## Data & Schema Migrations

Navigate to `/db` and run the schema migrations using flyway replacing values where appropriate:

`flyway -url=jdbc:mariadb://#{your docker db ip}#:3306 -user=root -password=#{your db password}# -schemas=openra-rc -locations=filesystem:./migration migrat`

Note: you may need to manually create the openra-rc database schema

To add sample data for local development run:

TO DO

## Object Storage
TO DO

## Web
Create the following launchSettings.json file in the `/OpenRA.ResourceCenter.Web/Properties` directory replacing values where appropriate 

```
{
  "profiles": {
    "openra_rc_v3": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "databaseUser": "root",
        "databasePassword" : "#{your db password}#",
        "databaseUrl" : "#{your docker db ip}#:3306"
      }
    }
  }
}

```

Navigate to `/OpenRA.ResourceCenter.Web` and run:

`dotnet run`

the website should start on https://localhost:5001




