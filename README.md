# AppZJOHOTEL
1 Pobrać lub sklonować repozytorium z gitHub.

2 Po włączeniu aplikacji wchodzimy w build -> rebuild Solution.

3 W przypadku nie zaciągniętych odpowiednich narzędzi, trzeba sprawdzić w plikach csproj czego nie mamy zainstalowanego, możemy doinstalować narzędzia przez NugetPacketManager.

4 Włączyć migracje poprzez wpisaniew w konsoli PM „enable-migrations”.

5 Sprawdzić wartości w appsetings.json. W appsettings.json znajduje się connection string z którego korzystamy. Na potrzeby można to zmienić, baza nazywa się HotelZJO.

6 W przypadku zajętych portów należy też zmienić porty w launchSettings.json.

7 W konsoli PM „Update-Database”.
(W przyszłości migracje zostaną przerobione na automatyczne przy włączeniu aplikacji)

8 Program włączany przez AppZJOHotel.WEBAPI IIS Express.

9 Po uruchomieniu programu powinna nam się włączyć strona swaggera z dostępnymi funkcjonalnościami.

