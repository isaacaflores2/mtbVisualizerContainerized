#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["mtbVisualizer/mtbVisualizer.csproj", "mtbVisualizer/"]
COPY ["stravaApi/IO.Swagger/IO.Swagger.csproj", "stravaApi/IO.Swagger/"]
RUN dotnet restore "mtbVisualizer/mtbVisualizer.csproj"
COPY . .
WORKDIR "/src/mtbVisualizer"
RUN dotnet build "mtbVisualizer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mtbVisualizer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mtbVisualizer.dll"]
