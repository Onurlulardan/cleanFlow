# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["cleanFlow/cleanFlow.csproj", "cleanFlow/"]
RUN dotnet restore "cleanFlow/cleanFlow.csproj"
COPY . .
WORKDIR "/src/cleanFlow"
RUN dotnet build "cleanFlow.csproj" -c Release -o /app/build

# Publish aşaması
FROM build AS publish
RUN dotnet publish "cleanFlow.csproj" -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cleanFlow.dll"]
