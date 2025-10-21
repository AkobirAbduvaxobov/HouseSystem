# ===========================
# 1. Build stage
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY HouseSystem.sln ./
COPY src/HouseSystem.Api/HouseSystem.Api.csproj ./HouseSystem.Api/

# Restore dependencies
RUN dotnet restore ./HouseSystem.Api/HouseSystem.Api.csproj

# Copy the rest of the source code
COPY . .

# Publish the app
RUN dotnet publish ./src/HouseSystem.Api/HouseSystem.Api.csproj -c Release -o /app/publish /p:UseAppHost=false


# ===========================
# 2. Runtime stage
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files
COPY --from=build /app/publish .

# Render expects port 8080
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "HouseSystem.Api.dll"]
