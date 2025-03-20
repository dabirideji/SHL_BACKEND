# Use the official .NET 8 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the project files
COPY ["OneWorld/OneWorld.csproj", "OneWorld/"]

# Restore dependencies
RUN dotnet restore "OneWorld/OneWorld.csproj"

# Copy the rest of the application files
COPY . .

# Build and publish the application
RUN dotnet publish "OneWorld/OneWorld.csproj" -c Release -o /app/publish

# Set up runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

# Expose port
EXPOSE 80

# Copy the published files
COPY --from=build /app/publish .

# Ensure database file and directory
RUN mkdir -p /app/wwwroot && touch /app/wwwroot/app.sqlite && chmod 777 /app/wwwroot/app.sqlite

# Set environment variable for SQLite connection
ENV CONNECTIONSTRINGS_SQLITECONNECTION="Data Source=/app/wwwroot/app.sqlite"

# Start the application
ENTRYPOINT ["dotnet", "OneWorld.dll"]
