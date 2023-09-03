#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Fun.Trading.StaticData.Api/Fun.Trading.StaticData.Api.csproj", "Fun.Trading.StaticData.Api/"]
RUN dotnet restore "Fun.Trading.StaticData.Api/Fun.Trading.StaticData.Api.csproj"
COPY . .
WORKDIR "/src/Fun.Trading.StaticData.Api"
RUN dotnet build "Fun.Trading.StaticData.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fun.Trading.StaticData.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fun.Trading.StaticData.Api.dll"]