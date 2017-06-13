TITLE Remarkting- Development Environment

setlocal
set ASPNETCORE_ENVIRONMENT=Development
git pull
git submodule foreach git pull origin master
dotnet restore
cd src
cd imperugo.corsi.flashmobile.services
dotnet build
dotnet run
