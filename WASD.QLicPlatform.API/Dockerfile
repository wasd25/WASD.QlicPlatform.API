
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia solo los archivos de proyecto (.sln y .csproj)
# Esto asume que tienes un .sln en la raíz. Si no, ajusta las rutas.
COPY *.sln .
COPY WASD.QLicPlatform.API/*.csproj ./WASD.QLicPlatform.API/
# Si tienes más proyectos (ej: Domain, Application), cópialos también:
# COPY WASD.QLicPlatform.Domain/*.csproj ./WASD.QLicPlatform.Domain/
# COPY WASD.QLicPlatform.Application/*.csproj ./WASD.QLicPlatform.Application/

# 2. Restaura las dependencias *antes* de copiar el resto del código
# Esto solo se ejecuta de nuevo si los archivos .csproj cambian.
RUN dotnet restore "WASD.QLicPlatform.API/WASD.QLicPlatform.API.csproj"

# 3. Copia el resto del código fuente.
# Si cambias solo el código, el build empieza desde aquí (es mucho más rápido).
COPY . .

# 4. Publica la aplicación
WORKDIR "/src/WASD.QLicPlatform.API"
RUN dotnet publish "WASD.QLicPlatform.API.csproj" -c Release -o /app/publish

# --- Etapa 2: Runtime (Final) ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponemos 8080, ya que es el puerto que Render usa
# y el que tu variable $PORT probablemente contendrá.
EXPOSE 8080

# Tu ENTRYPOINT es perfecto para Render, ¡no lo cambies!
ENTRYPOINT ["sh", "-c", "dotnet WASD.QLicPlatform.API.dll --urls http://0.0.0.0:$PORT"]