FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarDealership.Web/CarDealership.Web.csproj", "CarDealership.Web/"]
RUN dotnet restore "CarDealership.Web/CarDealership.Web.csproj"
COPY . .
WORKDIR "/src/CarDealership.Web"
RUN dotnet build "CarDealership.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarDealership.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarDealership.Web.dll"]
