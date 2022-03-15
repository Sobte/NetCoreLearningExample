FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["NetCoreLearningExample/NetCoreLearningExample.csproj", "NetCoreLearningExample/"]
RUN dotnet restore "NetCoreLearningExample/NetCoreLearningExample.csproj"
COPY . .
WORKDIR "/src/NetCoreLearningExample"
RUN dotnet build "NetCoreLearningExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreLearningExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreLearningExample.dll"]
