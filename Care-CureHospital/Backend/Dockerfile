FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /src
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "Backend/Backend.csproj"
COPY . .
RUN dotnet build "Backend/Backend.csproj" -c Release -o /app/build

FROM build-env AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0 && \
	dotnet publish "Backend/Backend.csproj" -c Release -o /app/publish && \
    dotnet-ef dbcontext script -p "Backend/Backend.csproj" -o /app/sql/init.sql

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
VOLUME /app/sql
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Backend.dll