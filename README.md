# ServiceAPI
ASP.NET Web API

## Minimal API with ASP.NET Core

Minimal APIs are architected to create HTTP APIs with minimal dependencies.

https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api


## Web API with ASP.NET Core

Building a controller-based web API that uses a database.

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api


## ASP.NET Core SignalR

Create real-time web app
https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-9.0&tabs=visual-studio

## Default endpoint

New ASP.NET Core projects are configured to bind to a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300. The selected ports are stored in the generated Properties/launchSettings.json file and can be modified by the developer. The launchSetting.json file is only used in local development.

If there's no endpoint configuration, then Kestrel binds to http://localhost:5000.

## Configure endpoints

Kestrel endpoints listen for incoming connections. When an endpoint is created, it must be configured with the address it will listen to. Usually, this is a TCP address and port number.

There are several options for configuring endpoints:
- Configure endpoints with URLs
- Specify ports only
- Configure endpoints in appsettings.json
- Configure endpoints in code

### Configure endpoints with URLs

The following sections explain how to configure endpoints using the:

- `ASPNETCORE_URLS` environment variable.
- `--urls` command-line argument.
- `urls` host configuration key.
- `UseUrls` extension method.
- `WebApplication.Urls` property.

### Specify ports only

Apps and containers are often given only a port to listen on, like port 80, without additional constraints like host or path. HTTP_PORTS and HTTPS_PORTS are config keys that specify the listening ports for the Kestrel and HTTP.sys servers. These keys may be specified as environment variables defined with the `DOTNET_` or `ASPNETCORE_` prefixes, or specified directly through any other config input, such as `appsettings.json`. Each is a semicolon-delimited list of port values, as shown in the following example:

```
ASPNETCORE_HTTP_PORTS=80;8080
ASPNETCORE_HTTPS_PORTS=443;8081
```

The preceding example is shorthand for the following configuration, which specifies the scheme (HTTP or HTTPS) and any host or IP.

```
ASPNETCORE_URLS=http://*:80/;http://*:8080/;https://*:443/;https://*:8081/
```

The HTTP_PORTS and HTTPS_PORTS configuration keys are lower priority and are overridden by URLS or values provided directly in code. Certificates still need to be configured separately via server-specific mechanics for HTTPS.

### Configure endpoints in appsettings.json

Kestrel can load endpoints from an IConfiguration instance. By default, Kestrel configuration is loaded from the Kestrel section and endpoints are configured in Kestrel:Endpoints:

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpEndpoint": {
        "Url": "http://localhost:8080"
      }
    }
  }
}
```

### Configure endpoints in code

KestrelServerOptions provides methods for configuring endpoints in code:

- Listen
- ListenLocalhost
- ListenAnyIP
- ListenUnixSocket
- ListenNamedPipe

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints