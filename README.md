# Cryptocurrency alert app!

A simple-looking website that allows you to send information about the current prices of selected currencies and cryptocurrencies to the user's e-mail address. 

Project created with ASP.NET Core Razor.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Presentation of the application](#presentation-of-the-application)
* [Status](#status)

## General info

"Cryptocurrency alert app!" web application gives you the opportunity to obtain information about the current prices of popular currencies and cryptocurrencies.


An application allows the user to choose their own currency. Then, a user selects the currencies and cryptocurrencies that interest him and provides his email address.
To the address provided, a user receives an attachment in the form of a pdf file with the current prices of the currencies selected by him.


An example of using the application is included in the video below, in the "Presentation of the application" section.

## Technologies

The app is built with ASP.NET Core Razor. The simple website itself was created using HTML and CSS.



To get information about the current prices of currencies and cryptocurrencies, the API from the Alpha Vantage and Fixer.io websites was used.
The pdf file was created with the IronPdf library (HTML was changed to the file), and the e-mail sending system uses MimeKit and MailKit.


In conclusion, the following was used:
* AlphaVantage.Net.Forex, version: 2.0.2
* FixerSharp, version: 1.2.2
* IronPdf, version: 2021.3.1
* MimeKit, version: 2.14.0
* MailKit, version: 2.14.0

## Presentation of the application


https://user-images.githubusercontent.com/53795852/129485316-069f8e19-fd28-4b1d-9127-ac7b85623b33.mp4


## Status

The basic version of the project has been completed. An application has a chance of multiple development. It concerns, among other things, adding the option of subscribing to e-mail messages.
