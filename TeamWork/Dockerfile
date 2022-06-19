FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamWork/TeamWork.csproj", "TeamWork/"]
RUN dotnet restore "TeamWork/TeamWork.csproj"
COPY . .
WORKDIR "/src/TeamWork"
RUN dotnet build "TeamWork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamWork.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamWork.dll"]
