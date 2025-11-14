# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["WASD.QLicPlatform.API/WASD.QLicPlatform.API.csproj", "WASD.QLicPlatform.API/"]
RUN dotnet restore "WASD.QLicPlatform.API/WASD.QLicPlatform.API.csproj"

COPY . .
WORKDIR /src/WASD.QLicPlatform.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .
EXPOSE 80

# Usar la variable PORT en tiempo de ejecución para compatibilidad con Render
ENTRYPOINT ["sh", "-c", "dotnet WASD.QLicPlatform.API.dll --urls http://0.0.0.0:$PORT"]
