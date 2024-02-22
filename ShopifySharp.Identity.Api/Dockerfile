FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./ShopifySharp.Identity.Api.csproj", "ShopifySharp.Identity.Api/"]
RUN dotnet restore "ShopifySharp.Identity.Api/ShopifySharp.Identity.Api.csproj"
COPY . .
WORKDIR "/src/ShopifySharp.Identity.Api"
RUN dotnet build "ShopifySharp.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopifySharp.Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopifySharp.Identity.Api.dll"]
