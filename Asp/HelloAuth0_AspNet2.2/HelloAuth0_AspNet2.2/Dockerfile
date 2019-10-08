FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["HelloAuth0_AspNet2.2/HelloAuth0_AspNet2.2.csproj", "HelloAuth0_AspNet2.2/"]
RUN dotnet restore "HelloAuth0_AspNet2.2/HelloAuth0_AspNet2.2.csproj"
COPY . .
WORKDIR "/src/HelloAuth0_AspNet2.2"
RUN dotnet build "HelloAuth0_AspNet2.2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloAuth0_AspNet2.2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloAuth0_AspNet2.2.dll"]