FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["api/api.csproj", "api/"]
COPY ["service/service.csproj", "service/"]
COPY ["infrastructure/infrastructure.csproj", "infrastructure/"]
RUN dotnet restore "api/api.csproj"
RUN dotnet restore "service/service.csproj"
RUN dotnet restore "infrastructure/infrastructure.csproj"

COPY . .
WORKDIR api/
RUN dotnet build "api.csproj" -c RELEASE -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c RELEASE -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
