CubeTask

To run:
Open in Visual Studio. Set Multiple Startup Projects "ConvertClient", "ConverterApi" and "HistoryApi"

Each project opens in a browser.

Find the "ConvertClient" window (purple Blazor web assembly app) and try a few conversions

Usage history is stored as a text file in the HistoryApi root folder - format "TemperatureConversionUsageHistoryYYYYMMDD.log"


Project Details

Solution consists of 6 projects, 4 source and 2 test

Each project was created from a standard .net template, using command-line "dotnet new" 

The ConverterApi project is a REST API that takes a ShareData ConversionRequest, logs it using the HistoryApi, and generates a ConversionResult response.


The HistoryApi project is a REST API that takes a SharedData ConversionRequest and writes it out to Serilog as a [Warning].  This is not ideal, but serves as a simple way to fulfil the brief, and can be easily replaced with a bulk-logging service or message service without altering the ConverterApi.

The ConvertClient is a Blazor web assembly with a single page, to allow temperature and units to be entered. Results are shown below the "Convert" button

There is some unit test coverage for the ConverterApi - both the TemperatureConversionController and the ConversionCalculator

The unit test project for HistoryApi is the default template. No tests have been written, but they would be similar to those for the ConveterApi.TemperatureConversionController


Last update 08/05/2022
