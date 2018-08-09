# MarketNFC
Api for NFC Market

update bazy
dotnet ef database update

//dodawanie migracji
dotnet ef migrations add [nazwa]

//uruchomienie
dotnet run

git commit -am "Migrate to Core 2.1 and dummy records"

git push origin master --force

## eager loading
https://stackoverflow.com/questions/38044451/entity-framework-core-eager-loading-then-include-on-a-collection

TODO:
dodac uzytkownika cos strojak ilosc 

# NFC_MVC
Magisterka na .net Framework 4.7.1

### Wejscie w NuGetPackage Console
        Tools > NuGetPackageManager > Console

### Enable-Migrations
        Enable-Migrations
        add-migration AddZamowinie
        update-database
        
#### Link do tutorialu z ukrywaniem navigation propertiesow
    https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-4-a-more-general-abstraction/
