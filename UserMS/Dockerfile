# Get Base Image (Full .NET Core SDK)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY UserMS.sln ./
COPY User.API/User.API.csproj ./User.API/
COPY User.Domain/User.Domain.csproj ./User.Domain/
COPY User.Application/User.Application.csproj ./User.Application/
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "User.API.dll"]