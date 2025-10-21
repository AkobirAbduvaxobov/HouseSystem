# ===========================
# 1. Build stage
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY HouseSystem.sln ./
COPY src/HouseSystem.Api/HouseSystem.Api.csproj src/HouseSystem.Api/

# Restore dependencies
RUN dotnet restore src/HouseSystem.Api/HouseSystem.Api.csproj

# Copy the rest of the code
COPY . .

# Build and publish the app
RUN dotnet publish src/HouseSystem.Api/HouseSystem.Api.csproj -c Release -o /app/publish /p:UseAppHost=false


# ===========================
# 2. Runtime stage
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Expose Render's expected port
EXPOSE 8080

# Set environment variables for Render
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the application
ENTRYPOINT ["dotnet", "HouseSystem.Api.dll"]
