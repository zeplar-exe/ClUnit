FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClUnit/ClUnit.csproj", "ClUnit/"]
RUN dotnet restore "ClUnit/ClUnit.csproj"
COPY . .
WORKDIR "/src/ClUnit"
RUN dotnet build "ClUnit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClUnit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClUnit.dll"]
