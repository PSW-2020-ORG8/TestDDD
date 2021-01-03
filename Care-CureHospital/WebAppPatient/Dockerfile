
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebAppPatient/WebAppPatient.csproj", "WebAppPatient/"]
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "WebAppPatient/WebAppPatient.csproj"
COPY . .
WORKDIR "/src/WebAppPatient"
RUN dotnet build "WebAppPatient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppPatient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAppPatient.dll