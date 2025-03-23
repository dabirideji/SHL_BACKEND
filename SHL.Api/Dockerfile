# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy project file and restore dependencies
COPY ["SHL.Api.csproj", "./"]
RUN dotnet restore "SHL.Api.csproj"

# Copy the rest of the source files
COPY . .

# Publish the application
RUN dotnet publish "SHL.Api.csproj" -c Release -o /app/publish

# Use a lightweight runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

# Expose ports
EXPOSE 80

# Copy the published output
COPY --from=build /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "SHL.Api.dll"]
