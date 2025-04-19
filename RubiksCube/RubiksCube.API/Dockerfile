FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["RubiksCube.API/RubiksCube.API.csproj", "RubiksCube.API/"]
COPY ["RubiksCube.Application/RubiksCube.Application.csproj", "RubiksCube.Application/"]
COPY ["RubiksCube.Domain/RubiksCube.Domain.csproj", "RubiksCube.Domain/"]
RUN dotnet restore "RubiksCube.API/RubiksCube.API.csproj"

COPY . .
WORKDIR "/src/RubiksCube.API"
RUN dotnet build "./RubiksCube.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RubiksCube.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RubiksCube.API.dll"]
