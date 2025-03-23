# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Add runtime environment variables
ENV API_READ_ACCESS_TOKEN eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkMGI3OTY3NzU4NjA2MTY0NjliNTUzMGM5Y2JkNjA2ZSIsIm5iZiI6MTc0MjIwMDQzOS44OTEsInN1YiI6IjY3ZDdkZTc3MTkxODY4YzU0ZmYxYzNmYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.U8OVI8DaabKFuyviHkx4uxYF22o1v6HfsX7gQezn59g
ENV API_KEY d0b796775860616469b5530c9cbd606e


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FilmOpgave-WEXO.Webaplication/FilmOpgave-WEXO.Webaplication.csproj", "FilmOpgave-WEXO.Webaplication/"]
RUN dotnet restore "./FilmOpgave-WEXO.Webaplication/FilmOpgave-WEXO.Webaplication.csproj"
COPY . .
WORKDIR "/src/FilmOpgave-WEXO.Webaplication"
RUN dotnet build "./FilmOpgave-WEXO.Webaplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FilmOpgave-WEXO.Webaplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilmOpgave-WEXO.Webaplication.dll"]