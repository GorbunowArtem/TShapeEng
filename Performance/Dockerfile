FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Performance/Performance.csproj", "Performance/"]
RUN dotnet restore "Performance/Performance.csproj"
COPY . .
WORKDIR "/src/Performance"
RUN dotnet build "Performance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Performance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Performance.dll"]
