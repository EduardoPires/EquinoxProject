FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Equinox.UI.Web/Equinox.UI.Web.csproj", "src/Equinox.UI.Web/"]
RUN dotnet restore "src/Equinox.UI.Web/Equinox.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/Equinox.UI.Web"
RUN dotnet build "Equinox.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Equinox.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equinox.UI.Web.dll"]