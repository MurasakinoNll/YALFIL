FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mainspline/mainspline.csproj", "mainspline/"]
RUN dotnet restore "mainspline/mainspline.csproj"
COPY . .
WORKDIR "/src/mainspline"
RUN dotnet build "mainspline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mainspline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mainspline.dll"]
