# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

WORKDIR /app
COPY . .

RUN dotnet publish "VulnApp2/VulnApp2.csproj" -c Release --property:PublishDir=/out

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Install Turkish locale
RUN apt-get update \
    && apt-get install -y locales

# Set the locale environment variable
ENV LANG tr_TR.UTF-8
ENV LC_ALL tr_TR.UTF-8

# Set user and work directory
USER app
WORKDIR /app

# Copy the built app from the previous stage
COPY --from=build-env /out .

# Entry point for the application
ENTRYPOINT ["dotnet", "VulnApp2.dll"]
