FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src

COPY ["/src/MetWorkingUserPresentation/*.csproj", "./MetWorkingUserPresentation/"]
COPY ["/src/MetWorkingUserApplication/*.csproj", "./MetWorkingUserApplication/"]
COPY ["/src/MetWorkingUserDomain/*.csproj", "./MetWorkingUserDomain/"]
COPY ["/src/MetWorkingUserInfrastructure/*.csproj", "./MetWorkingUserInfrastructure/"]

RUN dotnet restore "MetWorkingUserPresentation/MetWorkingUserPresentation.csproj"
COPY . .

WORKDIR "src/MetWorkingUserPresentation"
RUN dotnet build "MetWorkingUserPresentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetWorkingUserPresentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8081
ENV ASPNETCORE_URLS=http://*:8081

ENTRYPOINT ["dotnet", "MetWorkingUserPresentation.dll","--environment=Production"]