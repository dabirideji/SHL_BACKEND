FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SHL.Api.csproj", "./"]
RUN dotnet restore "SHL.Api.csproj"
COPY . .
RUN dotnet publish "SHL.Api.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SHL.Api.dll"]
