#Based on the current directories run the following command to build an image :)  
#   docker build . -f .\docker\Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /sln

COPY *.sln ./

COPY ["src/Fun.Trading.Api/Fun.Trading.Api.csproj", "Fun.Trading.Api/" ] 
COPY ["src/Fun.Trading.Infrastructure/Fun.Trading.Infrastructure.csproj", "Fun.Trading.Infrastructure/"] 
COPY ["src/Shared/Shared.csproj", "Shared/"] 

RUN dotnet restore "Fun.Trading.Api/Fun.Trading.Api.csproj"

COPY . .

RUN dotnet build "src/Fun.Trading.Api/Fun.Trading.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Fun.Trading.Api/Fun.Trading.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER $APP_UID
ENTRYPOINT ["dotnet", "Fun.Trading.Api.dll"]

