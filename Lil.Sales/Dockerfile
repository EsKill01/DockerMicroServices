#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Lil.Sales/Lil.Sales.csproj", "Lil.Sales/"]
RUN dotnet restore "Lil.Sales/Lil.Sales.csproj"
COPY . .
WORKDIR "/src/Lil.Sales"
RUN dotnet build "Lil.Sales.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lil.Sales.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lil.Sales.dll"]
