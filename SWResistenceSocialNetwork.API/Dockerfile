#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SWResistenceSocialNetwork.API/SWResistenceSocialNetwork.API.csproj", "SWResistenceSocialNetwork.API/"]
RUN dotnet restore "SWResistenceSocialNetwork.API/SWResistenceSocialNetwork.API.csproj"
COPY . .
WORKDIR "/src/SWResistenceSocialNetwork.API"
RUN dotnet build "SWResistenceSocialNetwork.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SWResistenceSocialNetwork.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SWResistenceSocialNetwork.API.dll"]