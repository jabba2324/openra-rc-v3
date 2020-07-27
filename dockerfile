FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY . .
RUN dotnet restore
RUN dotnet build -c Release --no-restore
RUN dotnet test -c Release --no-restore

FROM build AS publish
RUN dotnet publish "/OpenRA.ResourceCenter.Web/OpenRA.ResourceCenter.Web.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as deploy
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenRA.ResourceCenter.Web.dll"]
EXPOSE 80