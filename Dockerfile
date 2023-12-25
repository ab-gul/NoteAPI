<<<<<<< Updated upstream
# Build Stage

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./NoteAPI/NoteAPI.csproj" --disable-parallel
RUN dotnet publish "./NoteAPI/NoteAPI.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

=======
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NoteAPI/NoteAPI.csproj", "NoteAPI/"]
RUN dotnet restore "./NoteAPI/./NoteAPI.csproj"
COPY . .
WORKDIR "/src/NoteAPI"
RUN dotnet build "./NoteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NoteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
>>>>>>> Stashed changes
ENTRYPOINT ["dotnet", "NoteAPI.dll"]