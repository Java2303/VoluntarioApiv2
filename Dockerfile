# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./VolunteerApi/*.csproj ./VolunteerApi/
RUN dotnet restore ./VolunteerApi/VolunteerApi.csproj

COPY . .
WORKDIR /src/VolunteerApi
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VolunteerApi.dll"]
