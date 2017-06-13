TITLE Remarkting- Development Environment

setlocal
set ASPNETCORE_ENVIRONMENT=Development
dotnet restore
cd src
cd imperugo.corsi.flashmobile.services
dotnet build
dotnet run
