# CSVLoaderAndParser

*Requires dotnet core 2.1 or greater.

*Create the table for this sample using the DB.sql on the DBSamples folder

*Inside DBSamples you can also find a CSV sample for this implementation

This is a very simple project just to show an implementation of a CSV parser and the use of SqlBulkCopy on .net core 2.1+

## On the project folder run:

```sh
dotnet clean
```

Then

```sh
dotnet build
```

Then

```sh
dotnet run "C:\YourFilePathHere\FileName"
```

## Query you database and check the results