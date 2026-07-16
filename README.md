# ServiceAutoInjector

ServiceAutoInjector is a .NET 10 library that automates Dependency Injection. By scanning assemblies for marker interfaces, it can register classes as transient, scoped, or singleton services. This helps reduce boilerplate, simplify startup configuration, and keep architecture clean in .NET projects.

# Tworzenie i publikacja własnej paczki NuGet w .NET 10 – krok po kroku

## Opis problemu (wersja PL)

## Wstęp

W tym artykule pokazuję, jak stworzyć własną bibliotekę .NET, przygotować ją do dystrybucji jako paczkę NuGet, przetestować ją lokalnie oraz opublikować na nuget.org z wykorzystaniem narzędzi .NET CLI. Celem jest uproszczenie rejestracji usług, tak aby zamiast ręcznego definiowania wielu linii z interfejsem i klasą implementującą:

<img width="632" height="180" alt="image" src="https://github.com/user-attachments/assets/92cc0154-c8c3-4404-84a8-16f4b65c4ecb" />

*Rys. 1. Ręczna rejestracja usług Dependency Injection.*

otrzymać prostsze rozwiązanie:

<img width="928" height="140" alt="image" src="https://github.com/user-attachments/assets/7e367607-e806-4eef-9796-8173655b4018" />

*Rys. 2. Uproszczona rejestracja usług z użyciem ServiceAutoInjector.*

W dalszej części artykułu wykorzystamy prostą bibliotekę ServiceAutoInjector jako przykład do pokazania całego procesu tworzenia i publikacji własnej paczki NuGet. Celem artykułu nie jest szczegółowe omówienie mechanizmu refleksji ani Dependency Injection, lecz przedstawienie kompletnego procesu przygotowania i publikacji własnej paczki NuGet.

Wyszukiwanie interfejsów i klas odbywa się za pomocą refleksji w .NET. Sama implementacja biblioteki jest bardzo prosta:

<img width="1170" height="1058" alt="image" src="https://github.com/user-attachments/assets/aa5299d7-d5af-4d19-97ce-de8a19063f25" />

*Rys. 3. Implementacja biblioteki ServiceAutoInjector.*

W tym artykule nie zagłębiam się w szczegóły działania refleksji w .NET. Najważniejsze jest pokazanie, jak:

1. wygenerować paczkę NuGet,
2. dodać ją do projektu,
3. skonfigurować lokalne źródło paczek,
4. opublikować paczkę na nuget.org,
5. zadbać o wersjonowanie i opis paczki.

## Konfiguracja projektu NuGet

Aby dodać konfigurację paczki, w pliku .csproj należy uzupełnić m.in.:

```xml
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

- `PackageId` - nazwa paczki NuGet,
- `Version` - wersja paczki,
- `Authors` - autor paczki,
- `Description` - opis paczki,
- `PackageTags` - tagi paczki,
- `RepositoryUrl`, `RepositoryType` - link i typ repozytorium,
- `PackageLicenseExpression` - licencja paczki,
- `PackageReadmeFile` - plik dokumentacji README, który musi być dodany do projektu:

<img width="207" height="143" alt="image" src="https://github.com/user-attachments/assets/4e7583d2-75e0-4f13-8c95-cec2a613e99e" />

*Rys. 4. Wpis `PackageReadmeFile` w pliku projektu.*

## Tworzenie paczki NuGet

Aby wygenerować paczkę NuGet, przechodzimy do głównego folderu projektu (tam, gdzie znajduje się plik .sln) i wykonujemy komendę. Można też użyć Visual Studio:

<img width="455" height="886" alt="image" src="https://github.com/user-attachments/assets/23daa58a-9f09-4eea-9285-b5a3c4e327f7" />

*Rys. 5. Pakowanie projektu w Visual Studio.*

W terminalu wpisujemy:

```bash
dotnet build -c Release ; dotnet pack -c Release
```

Pierwsza komenda buduje projekt, a druga tworzy paczkę NuGet.

<img width="931" height="139" alt="image" src="https://github.com/user-attachments/assets/b1f14ad2-84be-4f9b-9f9e-a27301450204" />

*Rys. 6. Wynik działania poleceń `dotnet build` i `dotnet pack`.*

## Stworzenie lokalnego repozytorium NuGet

1. Tworzymy folder na dysku lokalnym, do którego wrzucimy paczkę NuGet. U mnie jest to `R:\LocalNugets`, ale może to być np. `C:\LocalNugets`.
2. Kopiujemy paczkę z folderu `\bin\Release`.

	<img width="657" height="135" alt="image" src="https://github.com/user-attachments/assets/eac02ff3-c564-4e44-a1b1-d05d61c68d9a" />

	*Rys. 7. Paczka NuGet w folderze wyjściowym `bin\Release`.*

3. Przenosimy paczkę do utworzonego folderu.

	<img width="833" height="209" alt="image" src="https://github.com/user-attachments/assets/a8e5c4ac-b5f6-415a-81f3-8829f7a614f3" />

	*Rys. 8. Paczka po przeniesieniu do lokalnego repozytorium NuGet.*

4. W Visual Studio przechodzimy do `Tools -> Options`:

	<img width="649" height="625" alt="image" src="https://github.com/user-attachments/assets/a99f916d-7327-41a6-8ab0-c83e5c7e41f8" />

	*Rys. 9. Okno `Tools -> Options` w Visual Studio.*

	Następnie wybieramy `All Settings -> NuGet Package Manager -> Sources`:

	<img width="1154" height="998" alt="image" src="https://github.com/user-attachments/assets/edc01bdc-5614-4fac-8448-440bce148369" />

	*Rys. 10. Sekcja `NuGet Package Manager -> Sources`.*

5. Klikamy `Add`.

	<img width="860" height="406" alt="image" src="https://github.com/user-attachments/assets/4c3a4872-15a8-4c10-aa6b-fe95a15b7d14" />

	*Rys. 11. Przycisk `Add` do dodania nowego źródła pakietów.*

6. Dodajemy lokalizację folderu w polu `Source`.

	<img width="1684" height="902" alt="image" src="https://github.com/user-attachments/assets/8abbb163-6cc9-4dd8-9823-dc7f93b2eec1" />

	*Rys. 12. Uzupełnione pole `Source` z lokalizacją lokalnego repozytorium.*

7. Nadajemy nazwę źródłu i klikamy `Save`.
8. Po tej operacji, w zarządzaniu paczkami w projekcie:

	<img width="473" height="798" alt="image" src="https://github.com/user-attachments/assets/4c5e6ce0-259b-4818-a02c-16260dcbc538" />

	*Rys. 13. Widok zarządzania pakietami NuGet w projekcie.*

9. Możemy wybrać źródło:

	<img width="630" height="227" alt="image" src="https://github.com/user-attachments/assets/42de1296-bcb3-4079-a27d-20d272688a32" />

	*Rys. 14. Wybór źródła pakietów NuGet.*

Po zaznaczeniu widzimy jedną paczkę, którą dodaliśmy:

<img width="1876" height="324" alt="image" src="https://github.com/user-attachments/assets/cbdeb6cc-a738-47fb-a5c4-736a733153a2" />

*Rys. 15. Paczka widoczna w lokalnym źródle NuGet.*

W ten sposób dodaliśmy do projektu własną lokalną paczkę NuGet.

## Publikacja paczki do repozytorium nuget.org

1. Na początek trzeba zalogować się na konto microsoft, z którego będziemy publikować paczkę: https://www.nuget.org/.
2. Przechodzimy do API Keys: https://www.nuget.org/account/apikeys?forceApiKeys=true
3. Dla przypadku publikacji z terminala (`cmd` / .NET CLI) klikamy link `Api keys`:
4. Klikamy `Create`.
5. Uzupełniamy dane:

	<img width="1268" height="1037" alt="image" src="https://github.com/user-attachments/assets/27f035c5-302e-4615-adbc-0c06b69cdda7" />

	*Rys. 20. Formularz tworzenia klucza API.*

	W celach testowych można utworzyć token wygasający np. po 1 dniu:

	<img width="1185" height="1004" alt="image" src="https://github.com/user-attachments/assets/10f2ba90-b266-4f40-a1de-c152317ae5d3" />

	*Rys. 21. Ustawienie daty wygaśnięcia tokenu.*

7. Kopiujemy token:

	<img width="1318" height="352" alt="image" src="https://github.com/user-attachments/assets/c2e2b924-34d9-4e54-a820-b7085293c56f" />

	*Rys. 22. Wygenerowany token API.*

8. W terminalu przechodzimy do lokalizacji paczki NuGet (u mnie: `R:\RepoGit\ServiceAutoInjector\src\Implementation\ServiceAutoInjector\bin\Release`) i wykonujemy:

```bash
dotnet nuget push moja-paczka.nupkg --api-key TWOJ_KLUCZ --source https://api.nuget.org/v3/index.json
```

W moim przypadku:

```bash
dotnet nuget push ServiceAutoInjector.1.0.0.nupkg --api-key TWOJ_KLUCZ --source https://api.nuget.org/v3/index.json
```

Po wykonaniu komendy otrzymamy:

<img width="1153" height="379" alt="image" src="https://github.com/user-attachments/assets/70cf2883-cee0-4cad-b7b4-f65b47bbfe96" />

*Rys. 23. Wynik publikacji paczki do nuget.org.*

Następnie trzeba poczekać, aż paczka zostanie uwzględniona w wyszukiwaniach. Na stronie paczki w nuget.org może to wyglądać tak:

<img width="1250" height="923" alt="image" src="https://github.com/user-attachments/assets/5fcbfc75-ebd9-4d57-baf7-abb3f808a00c" />

*Rys. 24. Strona opublikowanej paczki w nuget.org.*

Link do paczki:
https://www.nuget.org/packages/ServiceAutoInjector/

Teraz po wybraniu `Prawy klik na nazwę solucji -> Manage NuGet Package`:

<img width="495" height="329" alt="image" src="https://github.com/user-attachments/assets/22b4bd67-e657-4752-9621-c79a8fdbffef" />

*Rys. 25. Opcja `Manage NuGet Package` w Visual Studio.*

możemy wyszukać paczkę z nuget.org i dodać ją do projektu.

<img width="1843" height="564" alt="image" src="https://github.com/user-attachments/assets/f7d90cfc-3783-4ff0-bf07-a097665a72a8" />

*Rys. 26. Paczka dostępna w wyszukiwarce nuget.org.*

Jak widać, paczka może nie posiadać odpowiedniej metody, jeśli wersja z tą metodą nie została jeszcze opublikowana:

<img width="1224" height="154" alt="image" src="https://github.com/user-attachments/assets/53d104d7-6c93-486a-830c-590c2b301b26" />

*Rys. 27. Przykład braku metody w starszej wersji paczki.*

## Aktualizacja wersji paczki

Aby zaktualizować paczkę, wystarczy zmienić numer wersji w pliku .csproj, np.:

<img width="540" height="153" alt="image" src="https://github.com/user-attachments/assets/fb628711-8a4f-493e-b9d2-edc8d60783e6" />

*Rys. 28. Zmiana numeru wersji w pliku projektu.*

Następnie ponownie wygenerować paczkę:

<img width="875" height="200" alt="image" src="https://github.com/user-attachments/assets/56e0e760-65b3-4af2-b3fd-2e580036f8bc" />

*Rys. 29. Ponowne wygenerowanie paczki NuGet.*

Zostanie wygenerowana nowa paczka:

<img width="652" height="81" alt="image" src="https://github.com/user-attachments/assets/d40c6820-a985-4f88-85c6-cade213b2c0c" />

*Rys. 30. Nowo wygenerowana paczka w katalogu wyjściowym.*

którą możemy wypchnąć do NuGet komendą:

```bash
dotnet nuget push ServiceAutoInjector.1.0.1.nupkg --api-key TWOJ_KLUCZ --source https://api.nuget.org/v3/index.json
```

<img width="1148" height="240" alt="image" src="https://github.com/user-attachments/assets/77d408b0-bf97-4993-a2e1-433db1409de3" />

*Rys. 31. Wynik publikacji nowej wersji paczki.*

Następnie w zarządzaniu paczkami projektu można wykonać aktualizację:

<img width="1840" height="763" alt="image" src="https://github.com/user-attachments/assets/7547587f-b25c-4de3-9418-4c0a89c9ee16" />

*Rys. 32. Dostępna aktualizacja paczki w projekcie.*

To rozwiązuje problem z brakującymi parametrami:

<img width="1188" height="149" alt="image" src="https://github.com/user-attachments/assets/44cc6655-7e7d-4482-8420-9779c6c9b983" />

*Rys. 33. Efekt po aktualizacji paczki.*

### Na koniec
W tym artykule stworzyliśmy własną bibliotekę, wygenerowaliśmy paczkę NuGet, przetestowaliśmy ją lokalnie, opublikowaliśmy ją na nuget.org oraz pokazaliśmy, jak publikować kolejne wersje. Dzięki temu ten sam proces można wykorzystać do publikowania kolejnych bibliotek NuGet.
