FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["HelloApi_AspNet3/HelloApi_AspNet3.csproj", "HelloApi_AspNet3/"]
RUN dotnet restore "HelloApi_AspNet3/HelloApi_AspNet3.csproj"
COPY . .
WORKDIR "/src/HelloApi_AspNet3"
RUN dotnet build "HelloApi_AspNet3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloApi_AspNet3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloApi_AspNet3.dll"]