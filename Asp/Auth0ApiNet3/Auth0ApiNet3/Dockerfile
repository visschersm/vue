FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Auth0ApiNet3/Auth0ApiNet3.csproj", "Auth0ApiNet3/"]
RUN dotnet restore "Auth0ApiNet3/Auth0ApiNet3.csproj"
COPY . .
WORKDIR "/src/Auth0ApiNet3"
RUN dotnet build "Auth0ApiNet3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auth0ApiNet3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth0ApiNet3.dll"]