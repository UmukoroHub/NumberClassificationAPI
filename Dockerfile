# Use the official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Set environment variable for Render
ENV ASPNETCORE_URLS=http://+:8080

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NumberClassificationAPI.csproj", "./"]
RUN dotnet restore "NumberClassificationAPI.csproj"
COPY . .
RUN dotnet publish "NumberClassificationAPI.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "NumberClassificationAPI.dll"]
