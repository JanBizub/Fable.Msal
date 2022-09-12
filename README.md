# Fable.Msal
Fable bindings for [@azure/msal-browser](https://www.npmjs.com/package/@azure/msal-browser#msal-basics)

Warning: bindings does not include all functionality.

Create Azure App Registration for client. Pick SPA and reply url = https://localhost:3030
(optional) Create Azure App Registration for Server.

To test client application, provide it with cliend id and tenant id in Main.fs
(optional) To test client application and server, also provide client id (there is one for api and different for client) and tenant id in appsettings.development.json

1. Go to: Fable.Msal\src\demo\Client
2. dotnet tool restore
3. npm install
4. npm start
