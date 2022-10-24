#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Enforcer.API/EnforcerAPI.csproj", "Enforcer.API/"]
COPY ["EnforcerAPI.Data/EnforcerAPI.Data.csproj", "EnforcerAPI.Data/"]
COPY ["RepCrime.Common/RepCrime.Common.csproj", "RepCrime.Common/"]
RUN dotnet restore "Enforcer.API/EnforcerAPI.csproj"
COPY . .
WORKDIR "/src/Enforcer.API"
RUN dotnet build "EnforcerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnforcerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnforcerAPI.dll"]