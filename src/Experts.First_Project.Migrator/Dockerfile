#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Experts.First_Project.Migrator/Experts.First_Project.Migrator.csproj", "src/Experts.First_Project.Migrator/"]
COPY ["src/Experts.First_Project.EntityFrameworkCore/Experts.First_Project.EntityFrameworkCore.csproj", "src/Experts.First_Project.EntityFrameworkCore/"]
COPY ["src/Experts.First_Project.Core/Experts.First_Project.Core.csproj", "src/Experts.First_Project.Core/"]
COPY ["src/Experts.First_Project.Core.Shared/Experts.First_Project.Core.Shared.csproj", "src/Experts.First_Project.Core.Shared/"]
RUN dotnet restore "src/Experts.First_Project.Migrator/Experts.First_Project.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Experts.First_Project.Migrator"
RUN dotnet build "Experts.First_Project.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Experts.First_Project.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Experts.First_Project.Migrator.dll"]
