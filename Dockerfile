# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy project file and restore dependencies
COPY ["SHL.Api/SHL.Api.csproj", "SHL.Api/"]
RUN dotnet restore "SHL.Api/SHL.Api.csproj"

# Copy the rest of the source files
COPY . .

# Publish the application
RUN dotnet publish "SHL.Api/SHL.Api.csproj" -c Release -o /app/publish

# Use a lightweight runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

# Expose ports
EXPOSE 80

# Copy the published output
COPY --from=build /app/publish .

# ✅ Ensure wwwroot files are copied correctly
COPY --from=build /src/SHL.Api/wwwroot /app/wwwroot

# ✅ Set correct permissions for static files
RUN chmod -R 755 /app/wwwroot

# Start the application
ENTRYPOINT ["dotnet", "SHL.Api.dll"]
