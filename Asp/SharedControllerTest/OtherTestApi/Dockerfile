FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["OtherTestApi/OtherTestApi.csproj", "OtherTestApi/"]
RUN dotnet restore "OtherTestApi/OtherTestApi.csproj"
COPY . .
WORKDIR "/src/OtherTestApi"
RUN dotnet build "OtherTestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OtherTestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OtherTestApi.dll"]