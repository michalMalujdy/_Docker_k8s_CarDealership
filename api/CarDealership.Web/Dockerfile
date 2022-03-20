FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kubernetes.Web/Kubernetes.Web.csproj", "Kubernetes.Web/"]
RUN dotnet restore "Kubernetes.Web/Kubernetes.Web.csproj"
COPY . .
WORKDIR "/src/Kubernetes.Web"
RUN dotnet build "Kubernetes.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kubernetes.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kubernetes.Web.dll"]
