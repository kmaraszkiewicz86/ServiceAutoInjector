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

#Tworzenie paczki nuget lokalnie i używanie jej w środowisku Visual Studio:

Aby wygenerować paczkę nuget, wystarczy przejść do głównego folderu projektu gdzie znajduje się plik *.sln i wykonać komendę

```

```





