FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /app
COPY . .
 
RUN dotnet restore
 
RUN dotnet publish Store.csproj -o publish
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Store.dll"]

