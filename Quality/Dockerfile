FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Quality/Quality.csproj", "Quality/"]
RUN dotnet restore "Quality/Quality.csproj"
COPY . .
WORKDIR "/src/Quality"
RUN dotnet build "Quality.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quality.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quality.dll"]
