FROM microsoft/dotnet AS build
WORKDIR /app
COPY . .
 
RUN dotnet restore
 
RUN dotnet publish Store.csproj -o publish
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Store.dll"]

