#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Via.CMS.API/Via.CMS.API.csproj", "Via.CMS.API/"]
RUN dotnet restore "Via.CMS.API/Via.CMS.API.csproj"
COPY . .
WORKDIR "/src/Via.CMS.API"
RUN dotnet build "Via.CMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Via.CMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Via.CMS.API.dll"]