FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RedisSubscriber/RedisSubscriber.csproj", "RedisSubscriber/"]
RUN dotnet restore "RedisSubscriber/RedisSubscriber.csproj"
COPY . .
WORKDIR "/src/RedisSubscriber"
RUN dotnet build "RedisSubscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisSubscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisSubscriber.dll"]
