FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Architecture/Architecture.csproj", "Architecture/"]
RUN dotnet restore "Architecture/Architecture.csproj"
COPY . .
WORKDIR "/src/Architecture"
RUN dotnet build "Architecture.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Architecture.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Architecture.dll"]
