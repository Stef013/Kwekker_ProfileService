#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kwek_Service/Kwek_Service.csproj", "Kwek_Service/"]
RUN dotnet restore "Kwek_Service/Kwek_Service.csproj"
COPY . .
WORKDIR "/src/Kwek_Service"
RUN dotnet build "Kwek_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kwek_Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kwek_Service.dll"]