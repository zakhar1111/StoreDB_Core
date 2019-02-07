FROM microsoft/dotnet AS build
WORKDIR /app
COPY . .
 
RUN dotnet restore
 
RUN dotnet publish Store.csproj -o publish
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Store.dll"]

# test application -- see: dotnet-docker-unit-testing.md
#FROM build AS testrunner
#WORKDIR /app/StoreTest
#COPY . .
#ENTRYPOINT ["dotnet", "test", "--logger:trx"]

#FROM microsoft/dotnet AS runtime
#WORKDIR /app/publish
#COPY --from=build  . .
#ENTRYPOINT ["dotnet", "Store.dll"]
