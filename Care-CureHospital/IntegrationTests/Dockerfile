FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["IntegrationTests/IntegrationTests.csproj", "IntegrationTests/"]
COPY ["WebAppPatient/WebAppPatient.csproj", "WebAppPatient/"]
COPY ["Backend/Backend.csproj", "Backend/"]
COPY ["IntegrationAdapters/IntegrationAdapters.csproj", "IntegrationAdapters/"]
RUN dotnet restore "IntegrationTests/IntegrationTests.csproj"
COPY . .
WORKDIR "/src/IntegrationTests"
RUN dotnet build "IntegrationTests.csproj" -c Release -o /app/build 

FROM build AS test
WORKDIR /app
COPY --from=build /app/build .
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.7.3/wait /wait
RUN chmod +x /wait
CMD  /wait && dotnet test IntegrationTests.dll