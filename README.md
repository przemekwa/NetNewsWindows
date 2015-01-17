# NetNewsWindows

NetNewsWindows to aplikacja w C# wykorzystująca technologie WPF do wyświetlania wiadomości z głownych stron portali internetowych.
Nie jest to agregator RSS-sów i nie korzysta z tej technologi. Dla każdego z portali powstało osobne API czyli biblioteka w C# do obsługi strony głównej portalu.

Projekt składa się z:

- Aplikacji Gazeta.pl napisanej w technologi WPF z wykorzystaniem wzorca MVC. Aplikacja pozwala na pobieranie wiadomości ze stron głownych portali. 
- Biblioteka gazetaNews, która jest implementacją API do portalu gazeta.pl.

##Szybki start:

Aplikacja działa z .NE 4.5 i pozwala na odświeżenie wiadomości co 20 minut. Aplikacja wyświetla wiadomości w głównym oknie oraz zapisuje je do pliku XML.


W planach na 2015 jest:

1. Stworzenie z aplikacji gazeta.pl aplikacji pluginowej do której będzie można dołanczać kolejne biblioteki z różnych portali.




