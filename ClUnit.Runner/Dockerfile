FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClUnit.Runner/ClUnit.Runner.csproj", "ClUnit.Runner/"]
RUN dotnet restore "ClUnit.Runner/ClUnit.Runner.csproj"
COPY . .
WORKDIR "/src/ClUnit.Runner"
RUN dotnet build "ClUnit.Runner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClUnit.Runner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClUnit.Runner.dll"]
