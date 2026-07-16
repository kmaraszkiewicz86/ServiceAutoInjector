# ServiceAutoInjector

`ServiceAutoInjector` is a `.NET 10` library for automatic Dependency Injection registration.

The library adds services to `IServiceCollection` by scanning assemblies for interfaces that inherit from a selected marker interface, and then finding concrete classes that implement those interfaces.

## Package information

- **PackageId:** `ServiceAutoInjector`
- **Version:** `1.0.1`
- **Target framework:** `net10.0`

## What it does

The package exposes `AddClassesToDependencyInjection(...)`, which:

1. Scans an assembly for interfaces that inherit from a selected global interface.
2. Finds non-abstract classes implementing those interfaces.
3. Registers each implementation in the DI container with the selected `ServiceLifetime`.

It also supports scanning an additional implementation assembly.

### ServiceAutoInjectorExtension documentation

Extension methods for IServiceCollection to automatically register services based on interfaces and their implementations.

#### AddClassesToDependencyInjection method
Scans for all interfaces in the specified assembly that implement the given global interface type, and registers their implementations in the dependency injection container.
### Parameters
- `globalInterfaceType` - marker interface used to discover service interfaces.
- `assembly` - assembly to scan for matching interfaces. If not provided, `globalInterfaceType.Assembly` is used.
- `implementationAssembly` - optional extra assembly containing implementation classes.
- `serviceLifetime` - DI lifetime used during registration. Default: `Scoped`.


## Installation

Install the package with the .NET CLI: 
```bash
dotnet add package ServiceAutoInjector --version 1.0.1
```

