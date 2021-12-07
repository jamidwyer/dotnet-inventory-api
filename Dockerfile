FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# src is in the docker image
WORKDIR /src
# copy file to src
COPY api.csproj .
RUN dotnet restore
# copy everything in the local working dir to the image
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
# copy app stuff made in build step into the image
COPY --from=build /app .
# entrypoint is dotnet, api.dll is arg
ENTRYPOINT ["dotnet", "api.dll"]