FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Equinox.UI.Web/Equinox.UI.Web.csproj", "Equinox.UI.Web/"]
RUN dotnet restore "Equinox.UI.Web/Equinox.UI.Web.csproj"
COPY . .
WORKDIR "/src/Equinox.UI.Web"
RUN dotnet build "Equinox.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Equinox.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Equinox.UI.Web.dll"]