#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TrueCodeTest.Api/TrueCodeTest.Api.csproj", "TrueCodeTest.Api/"]
COPY ["TrueCodeTest.Application/TrueCodeTest.Application.csproj", "TrueCodeTest.Application/"]
COPY ["TrueCodeTest.Domain/TrueCodeTest.Domain.csproj", "TrueCodeTest.Domain/"]
COPY ["TrueCodeTest.Infrastructure.Storage/TrueCodeTest.Infrastructure.Storage.csproj", "TrueCodeTest.Infrastructure.Storage/"]
COPY ["TrueCodeTest.Infrastructure.Web/TrueCodeTest.Infrastructure.Web.csproj", "TrueCodeTest.Infrastructure.Web/"]
RUN dotnet restore "./TrueCodeTest.Api/TrueCodeTest.Api.csproj"
COPY . .
WORKDIR "/src/TrueCodeTest.Api"
RUN dotnet build "./TrueCodeTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TrueCodeTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrueCodeTest.Api.dll"]