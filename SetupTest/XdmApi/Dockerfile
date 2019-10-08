FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["XdmApi/XdmApi.csproj", "XdmApi/"]
RUN dotnet restore "XdmApi/XdmApi.csproj"
COPY . .
WORKDIR "/src/XdmApi"
RUN dotnet build "XdmApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "XdmApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "XdmApi.dll"]