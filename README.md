# NetNewsWindows

NetNewsWindows to aplikacja w C# wykorzystująca technologie WPF do wyświetlania wiadomości z głownych stron portali internetowych.
Nie jest to agregator RSS-sów i nie korzysta z tej technologi. Dla każdego z portali powstało osobne API czyli biblioteka w C# do obsługi strony głównej portalu.

Projekt składa się z:

- Aplikacji Gazeta.pl napisanej w technologi WPF z wykorzystaniem wzorca MVC. Aplikacja pozwala na pobieranie wiadomości ze stron głownych portali. 
- NetNewsWindowsPluginManager biblioteka C# obsługująca pluginy do aplikacji NetNewsWindows. Biblioteka oparta na technologi MEF.
- Biblioteka gazetaNews, która jest implementacją API do portalu gazeta.pl. Jest to plugin do aplikacji NetNewsWindows.

##Szybki start:

Aplikacja działa z .NE 4.5 i pozwala na odświeżenie wiadomości co 20 minut. Aplikacja wyświetla wiadomości w głównym oknie oraz zapisuje je do pliku XML. Aplikacja obsługuje pluginy. Każdy portal to osobny plugin. Każdy plugin implementuje interfejs INewsPlugin.

W tecj chwili dostępne są:

- Plugin do gazeta.pl
- Plugin do BBC.com


W planach na 2015 jest:

1. Stworzenie z aplikacji gazeta.pl aplikacji pluginowej do której będzie można dołanczać kolejne biblioteki z różnych portali. Zrobione!!!.
2. Poprawić kod.
3. Napisać nowe pluginy. Zrobione!!! 




