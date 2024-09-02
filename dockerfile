FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore ./src/TheWall.API/TheWall.API.csproj
# Build and publish a release
RUN dotnet publish ./src/TheWall.API/TheWall.API.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
EXPOSE 8080
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "TheWall.API.dll"]