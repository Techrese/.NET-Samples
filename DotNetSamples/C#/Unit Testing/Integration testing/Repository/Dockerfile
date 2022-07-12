#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["C#/Unit Testing/Integration testing/Repository/Repository.csproj", "C#/Unit Testing/Integration testing/Repository/"]
RUN dotnet restore "C#/Unit Testing/Integration testing/Repository/Repository.csproj"
COPY . .
WORKDIR "/src/C#/Unit Testing/Integration testing/Repository"
RUN dotnet build "Repository.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Repository.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Repository.dll"]