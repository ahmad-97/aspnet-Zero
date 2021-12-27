#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Experts.First_Project.Web.Public/Experts.First_Project.Web.Public.csproj", "src/Experts.First_Project.Web.Public/"]
COPY ["src/Experts.First_Project.Web.Core/Experts.First_Project.Web.Core.csproj", "src/Experts.First_Project.Web.Core/"]
COPY ["src/Experts.First_Project.Application/Experts.First_Project.Application.csproj", "src/Experts.First_Project.Application/"]
COPY ["src/Experts.First_Project.Application.Shared/Experts.First_Project.Application.Shared.csproj", "src/Experts.First_Project.Application.Shared/"]
COPY ["src/Experts.First_Project.Core.Shared/Experts.First_Project.Core.Shared.csproj", "src/Experts.First_Project.Core.Shared/"]
COPY ["src/Experts.First_Project.Core/Experts.First_Project.Core.csproj", "src/Experts.First_Project.Core/"]
COPY ["src/Experts.First_Project.EntityFrameworkCore/Experts.First_Project.EntityFrameworkCore.csproj", "src/Experts.First_Project.EntityFrameworkCore/"]
COPY ["src/Experts.First_Project.GraphQL/Experts.First_Project.GraphQL.csproj", "src/Experts.First_Project.GraphQL/"]
RUN dotnet restore "src/Experts.First_Project.Web.Public/Experts.First_Project.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/Experts.First_Project.Web.Public"
RUN dotnet build "Experts.First_Project.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Experts.First_Project.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Experts.First_Project.Web.Public.dll"]
