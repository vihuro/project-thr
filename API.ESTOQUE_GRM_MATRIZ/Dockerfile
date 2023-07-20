#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.ESTOQUE_GRM_MATRIZ/API.ESTOQUE_GRM_MATRIZ.csproj", "API.ESTOQUE_GRM_MATRIZ/"]
RUN dotnet restore "API.ESTOQUE_GRM_MATRIZ/API.ESTOQUE_GRM_MATRIZ.csproj"
COPY . .
WORKDIR "/src/API.ESTOQUE_GRM_MATRIZ"
RUN dotnet build "API.ESTOQUE_GRM_MATRIZ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.ESTOQUE_GRM_MATRIZ.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.ESTOQUE_GRM_MATRIZ.dll"]