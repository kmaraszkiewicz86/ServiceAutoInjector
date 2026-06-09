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


#Tworzenie paczki nuget

Aby wygenerować paczkę nuget, wystarczy przejść do głównego folderu projektu gdzie znajduje się plik *.sln i wykonać komendę lub możemy posłużyć się Visula Studio jak poniżej:

<img width="455" height="886" alt="image" src="https://github.com/user-attachments/assets/23daa58a-9f09-4eea-9285-b5a3c4e327f7" />

i w terminalu wpisać poniższą komendę

```
dotnet build -c Release ; dotnet pack -c Release
```

Pierwsza komenda zbuduję projekt a druga utworzy paczkę nuget

<img width="931" height="139" alt="image" src="https://github.com/user-attachments/assets/b1f14ad2-84be-4f9b-9f9e-a27301450204" />

#Stworzenie lokalnego repositorium nuget

1. Pierwszą rzeczą jaką należy zrobić jest stworzenie folderu na dysku lokalnym i utworzenie folderu gdzie wrzucimy paczkę nuget. Ja utworzyłem sobie folder: R:\LocalNugets. Natomiast można stworzyć folder gdziekolwiek na dysku np C:\LocalNugets w zależności od preferencji
2. Następnie koppiujemy paczkę z folderu: \bin\Release
   <img width="657" height="135" alt="image" src="https://github.com/user-attachments/assets/eac02ff3-c564-4e44-a1b1-d05d61c68d9a" />
3. Przenosimy paczkę do stworzonego folderu:
   <img width="833" height="209" alt="image" src="https://github.com/user-attachments/assets/a8e5c4ac-b5f6-415a-81f3-8829f7a614f3" />
5. Następnie za pomocą Visual Studio można stworzyć konfigurację przechodząc Tools -> Options:
   <img width="649" height="625" alt="image" src="https://github.com/user-attachments/assets/a99f916d-7327-41a6-8ab0-c83e5c7e41f8" />
   oraz wybierając: All Settings -> NuGet Package Manager -> Sources
   <img width="1154" height="998" alt="image" src="https://github.com/user-attachments/assets/edc01bdc-5614-4fac-8448-440bce148369" />
6. Następnie klikamy w przycisk Add
   <img width="860" height="406" alt="image" src="https://github.com/user-attachments/assets/4c3a4872-15a8-4c10-aa6b-fe95a15b7d14" />
7. Dodajemy lokalizację folderu w oknie Source:
  <img width="1684" height="902" alt="image" src="https://github.com/user-attachments/assets/8abbb163-6cc9-4dd8-9823-dc7f93b2eec1" />
8. Oraz nazywamy żródło paczek i kilkamy na Save
9. Po tej operacji przechodząc do zarządzani paczkami w danym projekcie:
<img width="473" height="798" alt="image" src="https://github.com/user-attachments/assets/4c5e6ce0-259b-4818-a02c-16260dcbc538" />

9.Można wybrać źródło:
<img width="630" height="227" alt="image" src="https://github.com/user-attachments/assets/42de1296-bcb3-4079-a27d-20d272688a32" />

Zaznaczając widzimy że mamy tylko jedną paczkę, którą dodaliśmy:
<img width="1876" height="324" alt="image" src="https://github.com/user-attachments/assets/cbdeb6cc-a738-47fb-a5c4-736a733153a2" />

Tak o to dodaliśmy do swojego projektu własną lokalną paczkę nuget.





   







