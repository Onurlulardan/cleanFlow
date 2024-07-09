# Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["cleanFlow.csproj", "."]
RUN dotnet restore "cleanFlow.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "cleanFlow.csproj" -c Release -o /app/build

# Publish aþamasý
FROM build AS publish
RUN dotnet publish "cleanFlow.csproj" -c Release -o /app/publish

# Runtime aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cleanFlow.dll"]
