#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MsBcConverter.Api/nuget.config", "src/MsBcConverter.Api/"]
COPY ["src/MsBcConverter.Api/MsBcConverter.Api.csproj", "src/MsBcConverter.Api/"]
COPY ["src/MsBcConverter.Interface/MsBcConverter.Interface.csproj", "src/MsBcConverter.Interface/"]
COPY ["src/MsBcConverter/MsBcConverter.csproj", "src/MsBcConverter/"]
RUN dotnet restore --configfile "src/MsBcConverter.Api/nuget.config" "src/MsBcConverter.Api/MsBcConverter.Api.csproj"
COPY . .
WORKDIR "/src/src/MsBcConverter.Api"
RUN dotnet build "MsBcConverter.Api.csproj" -c Release -o /app/build

FROM build as test
WORKDIR /src
COPY ["src/MsBcConverter.Tests/MsBcConverter.Tests.csproj", "src/MsBcConverter.Tests/"]
RUN dotnet restore --configfile "src/MsBcConverter.Api/nuget.config" "src/MsBcConverter.Tests/MsBcConverter.Tests.csproj"
COPY . .

WORKDIR "/src/src/MsBcConverter.Tests"
RUN dotnet build "MsBcConverter.Tests.csproj" -c Release
RUN dotnet test "MsBcConverter.Tests.csproj" -l "console;verbosity=normal" -c Release --logger trx; exit 0

# Build an image from scratch and store test results there
FROM scratch as export-test-results
COPY --from=test /src/src/.MsBcConverter.Tests/TestResults/*.trx .

WORKDIR "/src/src/MsBcConverter.Api"
FROM build AS publish
RUN dotnet publish "MsBcConverter.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MsBcConverter.Api.dll"]

# docker build --target export-test-results --output type=local,dest=out -f ./src/.MsBcConverter.Api/Dockerfile .