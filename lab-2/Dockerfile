FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /src

COPY src/MyApp.csproj .
RUN dotnet restore MyApp.csproj --disable-parallel

COPY src/ .
RUN dotnet publish MyApp.csproj -c Release -o /app/publish /p:UseAppHost=false

RUN dotnet nuget locals all --clear

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final

RUN addgroup -S webuser && adduser -S -G webuser webuser

WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/wwwroot && chown -R webuser:webuser /app

USER webuser

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "MyApp.dll"]