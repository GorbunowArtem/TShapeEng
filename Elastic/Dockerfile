FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Elastic/Elastic.csproj", "Elastic/"]
RUN dotnet restore "Elastic/Elastic.csproj"
COPY . .
WORKDIR "/src/Elastic"
RUN dotnet build "Elastic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Elastic.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Elastic.dll"]
