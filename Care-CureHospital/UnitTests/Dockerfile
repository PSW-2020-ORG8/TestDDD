#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UnitTests/UnitTests.csproj", "UnitTests/"]
COPY ["WebAppPatient/WebAppPatient.csproj", "WebAppPatient/"]
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "UnitTests/UnitTests.csproj"
COPY . .
WORKDIR "/src/UnitTests"
RUN dotnet build "UnitTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTests.csproj" -c Release -o /app/publish

FROM build AS test
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet test UnitTests.dll