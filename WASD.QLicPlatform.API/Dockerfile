# Etapa 1: Compilación (.NET SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de solución/proyecto y restaurar dependencias
COPY *.sln .
COPY WASD.QlicPlatform.API/*.csproj ./WASD.QlicPlatform.API/
RUN dotnet restore

# Copiar el código fuente completo y compilar
COPY . .
WORKDIR /src/WASD.QlicPlatform.API
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime de producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "WASD.QlicPlatform.API.dll"]