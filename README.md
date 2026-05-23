# ServiceAutoInjector
AutoServiceRegister is a .NET 10 library that automates Dependency Injection. By scanning assemblies for marker interfaces, it instantly registers classes as transient, scoped, or singleton services. Eliminate boilerplate code, streamline startup, and easily maintain clean architecture in your .NET projects.


#The problem polish version

#Wstęp

Chciałbym zademonstrować jak można skorzystać z narzędzi nuget.org i jak za pomocą narzędzi .net cli móc wygenerować paczkę nuget, która zawiera prostą implementację biblioteki, która zamiast definiowania zbioru linijek zawierających definiowanie interfejsu + klasy implementującej:
<img width="632" height="180" alt="image" src="https://github.com/user-attachments/assets/92cc0154-c8c3-4404-84a8-16f4b65c4ecb" />
Na coś prostszego:
<img width="928" height="140" alt="image" src="https://github.com/user-attachments/assets/7e367607-e806-4eef-9796-8173655b4018" />

Gdzie szukanie poszczególnych intefejsów oraz klas będzię odbywać się za pomocą Refleksji w .net. Implementacja biblioteki jest bardzo prosta:
<img width="1170" height="1058" alt="image" src="https://github.com/user-attachments/assets/aa5299d7-d5af-4d19-97ce-de8a19063f25" />

W tym artykule nie będziemy się wgłębiać jak działa Refleksja w .net, najważniejsze tutaj będzie przedstawienie jak można w prosty sposób wygenerować paczkę nuget i dodać ją do projektu
Na początek przetsawie jak można to zrobić za pomocą stworzenia lokalnego miejsca, gdzie utworzymy magazyn paczek nuget i jak skonfigurować Visual Studio aby móc pobierać i instalować paczki nuget do projektu.
Następnie pokaże jak w prosty sposób za pomocą .net cli wypchnąć paczkę do repozytorium nuget.org

Dodatkowo pokaże jak skonfigurować paczkę aby zawierała informację o wersji i dodanie opisu, ktróry będzie widoczny w opisie w witrynie nuget.org.

#Konfiguracja projektu nuget:

Aby dodać wszystkie potrzebne konfigurację dla danej paczki, którą chcemy wrzucić jako paczkę nuget. Do pliku csproj dorzucamy:

```
		<PackageId>kmaraszkiewicz86.ServiceAutoInjector</PackageId>
		<Version>1.0.0</Version>
		<Authors>Krzysztof Maraszkiewicz</Authors>
		<Description>ServiceAutoInjector is a .NET 10 library that automates Dependency Injection. By scanning assemblies for marker interfaces, it instantly registers classes as transient, scoped, or singleton services. Eliminate boilerplate code, streamline startup, and easily maintain clean architecture in your .NET projects.</Description>
		<PackageTags>dependency-injection;di;net10;extensions;autoregister</PackageTags>
		<RepositoryUrl>https://github.com/kmaraszkiewicz86/ServiceAutoInjector</RepositoryUrl>
		<RepositoryType>git</RepositoryType>
		<PackageLicenseExpression>MIT</PackageLicenseExpression>

		<!-- UI and Documentation on NuGet.org -->
		<PackageReadmeFile>README.md</PackageReadmeFile>
```

Gdzie:
* PackageId - jest nazwą paczki nuget
* Version - wersja paczki
* Authors - autor paczki nuget
* Description - opis paczki nuget
* PackageTags - tag dla danej paczki nuget
* RepositoryUrl, RepositoryType - link do repozytorium git
* PackageLicenseExpression - licencja paczki nuget
* PackageReadmeFile - link do dokumentacji pliku *.md który musi zostać dodany do projektu tak ja poniżej:
  <img width="207" height="143" alt="image" src="https://github.com/user-attachments/assets/4e7583d2-75e0-4f13-8c95-cec2a613e99e" />


#Tworzenie paczki nuget lokalnie i używanie jej w środowisku Visual Studio:

Aby wygenerować paczkę nuget, wystarczy przejść do głównego folderu projektu gdzie znajduje się plik *.sln i wykonać komendę lub możemy posłużyć się Visula Studio jak poniżej:

<img width="455" height="886" alt="image" src="https://github.com/user-attachments/assets/23daa58a-9f09-4eea-9285-b5a3c4e327f7" />

i w terminalu wpisać poniższą komendę

```
dotnet build -c Release ; dotnet pack -c Release
```

Pierwsza komenda zbuduję projekt a druga utworzy paczkę nuget

<img width="931" height="139" alt="image" src="https://github.com/user-attachments/assets/b1f14ad2-84be-4f9b-9f9e-a27301450204" />






