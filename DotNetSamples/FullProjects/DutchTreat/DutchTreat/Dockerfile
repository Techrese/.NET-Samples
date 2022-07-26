#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FullProjects/DutchTreat/DutchTreat/DutchTreat.csproj", "FullProjects/DutchTreat/DutchTreat/"]
RUN dotnet restore "FullProjects/DutchTreat/DutchTreat/DutchTreat.csproj"
COPY . .
WORKDIR "/src/FullProjects/DutchTreat/DutchTreat"
RUN dotnet build "DutchTreat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DutchTreat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DutchTreat.dll"]