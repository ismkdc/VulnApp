FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app
COPY . .

RUN dotnet publish "VulnApp/VulnApp.csproj" -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0


WORKDIR /app
COPY --from=build-env /out .

ENTRYPOINT dotnet VulnApp.dll
