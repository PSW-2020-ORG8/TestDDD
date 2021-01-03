FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IntegrationAdapters/IntegrationAdapters.csproj", "IntegrationAdapters/"]
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "IntegrationAdapters/IntegrationAdapters.csproj"
COPY . .
WORKDIR "/src/IntegrationAdapters"
RUN dotnet build "IntegrationAdapters.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationAdapters.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IntegrationAdapters.dll