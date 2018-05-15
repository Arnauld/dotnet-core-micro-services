```
Mentem: ~/Projects/dotnet
→ dotnet new webapi -o shipping
Le modèle 'ASP.NET Core Web API' a été créé.
Ce modèle contient des technologies d'éditeurs autres que Microsoft. Pour plus de détails, consultez https://aka.ms/template-3pn.

Traitement des actions postcréation...
Exécution de 'dotnet restore' sur shipping/shipping.csproj...
  Restoring packages for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj...
  Restoring packages for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj...
  Restore completed in 1,34 sec for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj.
  Generating MSBuild file /Users/Arnauld/Projects/dotnet/shipping/obj/shipping.csproj.nuget.g.props.
  Generating MSBuild file /Users/Arnauld/Projects/dotnet/shipping/obj/shipping.csproj.nuget.g.targets.
  Restore completed in 2,92 sec for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj.


Restauration réussie.
```

## Add JSON

```
Mentem: ~/Projects/dotnet
→ dotnet add shipping package  Newtonsoft.Json
  Writing /var/folders/46/ld5hyvbd2yz3tj9gy9rcl3ym0000gn/T/tmpk1JMC9.tmp
info : Adding PackageReference for package 'Newtonsoft.Json' into project '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
log  : Restoring packages for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 496ms
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/11.0.2/newtonsoft.json.11.0.2.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/11.0.2/newtonsoft.json.11.0.2.nupkg 505ms
log  : Installing Newtonsoft.Json 11.0.2.
info : Package 'Newtonsoft.Json' is compatible with all the specified frameworks in project '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
info : PackageReference for package 'Newtonsoft.Json' version '11.0.2' added to file '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
```

## Add Consul Client

```
Mentem: ~/Projects/dotnet
→ dotnet add shipping package  Consul
  Writing /var/folders/46/ld5hyvbd2yz3tj9gy9rcl3ym0000gn/T/tmpWVDvad.tmp
info : Adding PackageReference for package 'Consul' into project '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
log  : Restoring packages for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/consul/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/consul/index.json 619ms
info :   GET https://api.nuget.org/v3-flatcontainer/consul/0.7.2.4/consul.0.7.2.4.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/consul/0.7.2.4/consul.0.7.2.4.nupkg 521ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.net.http.winhttphandler/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/system.net.http.winhttphandler/index.json 501ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.net.http.winhttphandler/4.0.0/system.net.http.winhttphandler.4.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.net.http.winhttphandler/4.0.0/system.net.http.winhttphandler.4.0.0.nupkg 512ms
log  : Installing System.Net.Http.WinHttpHandler 4.0.0.
log  : Installing Consul 0.7.2.4.
info : Package 'Consul' is compatible with all the specified frameworks in project '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
info : PackageReference for package 'Consul' version '0.7.2.4' added to file '/Users/Arnauld/Projects/dotnet/shipping/shipping.csproj'.
```

## Update dependencies

```
Mentem: ~/Projects/dotnet/shipping
→ dotnet restore
  Restoring packages for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj...
  Restore completed in 83,03 ms for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj.
  Restore completed in 2,05 sec for /Users/Arnauld/Projects/dotnet/shipping/shipping.csproj.
```

## Connect to consul and start app

```
Mentem: ~/Projects/dotnet/shipping
→ dotnet run
Service 'postgres': <172.19.0.7:5432>
Service 'rabbitmq': <172.19.0.3:5672>
Service 'vault': <172.19.0.2:8200>
Service 'telegraf-statsd': <172.19.0.8:8125>
Hosting environment: Production
Content root path: /Users/Arnauld/Projects/dotnet/shipping
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
^CApplication is shutting down...
```

## Add logger

```
Mentem: ~/Projects/dotnet
→ dotnet add shipping package Microsoft.Extensions.Logging.Console
→ dotnet add shipping package Microsoft.Extensions.Logging
```

## Add 


## HTTP query

In the first terminal

```
→ dotnet run
info: shipping.Startup[0]
      Service 'postgres': <172.19.0.7:5432>
info: shipping.Startup[0]
      Service 'rabbitmq': <172.19.0.3:5672>
info: shipping.Startup[0]
      Service 'vault': <172.19.0.2:8200>
info: shipping.Startup[0]
      Service 'telegraf-statsd': <172.19.0.8:8125>
Hosting environment: Production
Content root path: /Users/Arnauld/Projects/dotnet/shipping
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

In the second terminal

```
→ curl -X GET http://localhost:5000/api/shipping/12345
{"Id":"12345","Recipient":"carmen@mccall.um"}%
```

# Resources

* [Building a Secure Containerized Microservice With .NET Core](https://dzone.com/articles/building-a-secure-containerized-microservice-with)
* [Getting started with .NET Core on macOS](https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-macos)
* [Using Consul for Service Discovery with ASP.NET Core](https://cecilphillip.com/using-consul-for-service-discovery-with-asp-net-core/)
