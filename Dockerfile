FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
ENV ASPNETCORE_URLS=http://+:5016
EXPOSE 5016
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "NotificationServer.dll"]