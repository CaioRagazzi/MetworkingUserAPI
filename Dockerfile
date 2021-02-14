FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY *.sln .
COPY ["/src/MetWorkingUserPresentation/*.csproj", "./MetWorkingUserPresentation/"]
COPY ["/src/MetWorkingUserApplication/*.csproj", "./MetWorkingUserApplication/"]
COPY ["/src/MetWorkingUserDomain/*.csproj", "./MetWorkingUserDomain/"]
COPY ["/src/MetWorkingUserInfrastructure/*.csproj", "./MetWorkingUserInfrastructure/"]

RUN dotnet restore "MetWorkingUserPresentation/MetWorkingUserPresentation.csproj"
COPY "./" .

WORKDIR "src/MetWorkingUserPresentation"
RUN dotnet build "MetWorkingUserPresentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetWorkingUserPresentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetWorkingUserPresentation.dll"]