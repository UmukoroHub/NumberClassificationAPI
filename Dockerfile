# Use the official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

# Set environment variable for Render
ENV ASPNETCORE_URLS=http://+:8080
# ENV ASPNETCORE_ENVIRONMENT=$environment

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NumberClassificationAPI\NumberClassificationAPI.csproj", "NumberClassificationAPI/"]
RUN dotnet restore "NumberClassificationAPI.csproj"


COPY . .
WORKDIR "NumberClassificationAPI"
RUN dotnet build "NumberClassificationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumberClassificationAPI.csproj" -c Release -o /app/publish


# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish.
ENTRYPOINT ["dotnet", "NumberClassificationAPI.dll"]