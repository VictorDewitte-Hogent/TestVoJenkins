FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# COPY ["src/Server/Server.csproj", "src/Server/"]
# COPY ["src/Client/Client.csproj", "src/Client/"]
# COPY ["src/Domain/Domain.csproj", "src/Domain/"]
# COPY ["src/Shared/Shared.csproj", "src/Shared/"]
COPY ./src/ /src
RUN dotnet restore "./Server/Server.csproj"
RUN dotnet build "./Server/Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Server/Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]