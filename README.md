# Reademe

## Environment setup
* Install .NET Core SDK
* Install MariaDB
* Install Docker (Optional)

## Database
Download the mariadb docker image

`docker pull mariadb`

Start the db server, replace #{your password}# with your desired password

`docker run --name open-ra-rc -e MYSQL_ROOT_PASSWORD=#{your db password}# -p 3306:3306 -d mariadb:latest`

Get the IP address of the server, replace #{docker process id}# with the docker process id for our database server

`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' #{docker process id}#`

Navigate to /db and run the schema migrations using flyway:

`flyway -url=jdbc:mariadb://#{docker db ip}#:3306 -user=root -password=#{your db password}# -schemas=openra-rc -locations=filesystem:./migration migrat`

Note: you may need to manually create the openra-rc database schema

To add sample data for local development run:

TO DO

## Object Storage
TO DO

## Web
Create the following launchSettings.json file in the /OpenRA.ResourceCenter.Web/Properties directory

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
        "databaseUrl" : "#{docker db ip}#:3306"
      }
    }
  }
}

```

Navigate to /OpenRA.ResourceCenter.Web and run:

`dotnet run`

the website should start on https://localhost:5001




