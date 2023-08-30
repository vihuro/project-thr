#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.ASSISTENCIA_TECNICA_OS/API.ASSISTENCIA_TECNICA_OS.csproj", "API.ASSISTENCIA_TECNICA_OS/"]
RUN dotnet restore "API.ASSISTENCIA_TECNICA_OS/API.ASSISTENCIA_TECNICA_OS.csproj"
COPY . .
WORKDIR "/src/API.ASSISTENCIA_TECNICA_OS"
RUN dotnet build "API.ASSISTENCIA_TECNICA_OS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.ASSISTENCIA_TECNICA_OS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.ASSISTENCIA_TECNICA_OS.dll"]