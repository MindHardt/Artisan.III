FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Artisan.III.Server.csproj", "Server/"]
COPY ["Client/Artisan.III.Client.csproj", "Client/"]
COPY ["Shared/Artisan.III.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Artisan.III.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Artisan.III.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artisan.III.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artisan.III.Server.dll"]
