FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["XcXdmApi/XcXdmApi.csproj", "XcXdmApi/"]
RUN dotnet restore "XcXdmApi/XcXdmApi.csproj"
COPY . .
WORKDIR "/src/XcXdmApi"
RUN dotnet build "XcXdmApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "XcXdmApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "XcXdmApi.dll"]