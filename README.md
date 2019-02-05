# Word Search Solver

An app that takes a file path and returns a solved word search puzzle written using .Net Core

## Usage

.Net Core SDK must be installed to build. Get it [here](https://dotnet.microsoft.com/download).

### Run the example app

```bash
dotnet run -p ./WordSearchSolverApp/WordSearchSolverApp.csproj ./WordSearchSolverApp/example.txt
```

### Test

```bash
dotnet test ./WordSearchSolverTests/WordSearchSolverTests.csproj
```
### Build

#### Debug

```bash
dotnet build
```

#### Release

Windows targets:

```bash
dotnet publish -c Release -r win-x64
```

macOS targets:

```bash
dotnet publish -c Release -r osx-x64
```

Linux targets:

```bash
dotnet publish -c Release -r linux-x64
```
### VS Code

If using VSCode you can utilize the task runner for many of the above commands.