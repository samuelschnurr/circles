# Circles

[![.NET CI](https://github.com/samuelschnurr/circles/actions/workflows/dotnet.yml/badge.svg)](https://github.com/samuelschnurr/circles/actions/workflows/dotnet.yml)

This repository provides a platform for managing classified ads. The prototype implementation is used for the evaluation of Blazor WebAssembly and as a showcase

## Before you start
  - Install the <a href="https://dotnet.microsoft.com/download/dotnet/7.0">.NET 7 SDK</a>
  - Install the <a href="https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/install">.NET Web Development Tools and WebAssembly Build Tools</a>
  - Notice that the frontend application is hosted at `https://localhost:7115/`
  - Notice that the backend application is hosted at `https://localhost:7292/`

## Build and run


### Using an IDE

If you're using an integrated development environment like Visual Studio, you can easily open the project in it.
After a `package restore` and `build` you can start the projects. To see and send data make sure the frontend can talk to the backend by starting both projects: `Io.Schnurr.Circles.App` for frontend and `Io.Schnurr.Circles.Api` for the backend.

### Using a CLI

Open the `dotnet` CLI and navigate to the folder where the `.csproj` of the project `Io.Schnurr.Circles.App` is located.

Run the following command to build and then run the project:

```
dotnet build
dotnet run --launch-profile https
```

Repeat this step for the `.csproj` in the project `Io.Schnurr.Circles.Api`

## Demonstration
Comming soon

## License

This repository is under GPL-2.0 license (see <a href="https://github.com/samuelschnurr/circles/blob/main/LICENSE">LICENSE</a>).

Third party libraries are distributed under their own terms in the <a href="https://github.com/samuelschnurr/circles/blob/main/LICENSE-3RD-PARTY">LICENSE-3RD-PARTY</a> file.
