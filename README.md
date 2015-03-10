# Soccer League Table

Reference implementation of AngularJS + ASP.NET Web API.

This sample application calculates soccer league table standings based on match results. The standings are updated dynamically without the whole page having to be reloaded. Okay, so we could do that using jQuery or even POXHRs (plain old XMLHttpRequests). The beauty of AngularJS is that the code scaffolding for this is very clean: we only need to care about manipulating the view model, and the view is then updated automagically, via bindings.

Disclaimer: The soccer club names are intended to be fictional; any similarity to actual soccer clubs is purely coincidental.

To launch the solution from Visual Studio, set the following as startup projects:

- AngularClient
- WebApi

## Tools

- Visual Studio Community 2013
- SQL Server 2008 Express

## Technologies

- AngularJS 1.3.14
- ASP.NET Web API 2.2
  - with CORS - Nuget Id: Microsoft.AspNet.WebApi.Cors
- Entity Framework 6.1.1 using Code First Migrations
- ng-grid 2.0.12
- Bootstrap 3.3.2

## Solution Design

One way to design the solution would be to centralise the logic for calculations in Services, and to make Services have a dependency on Repository. To cater for initial page load, for example, LeagueTableService would retrieve the latest match results from FixturesRepository and compute the latest standings. However, to be able to unit test LeagueTableService, there would need to be interfaces and constructor injection and the mocking of an IFixturesRepository implementation that returns Model objects.

What I've done instead is to centralise the logic for calculations in Domain. Domain depends only on Model, and the methods in Domain are purely functional, whereby they take input and return output without any side effects. Unit testing the calculations in Domain then becomes very straightforward, as there's nothing to mock; there are only Model objects to create. Services acts merely as a broker that takes data from the Repository and feeds it to Domain. The end result is that interfaces, DI, and mocking no longer become necessary. But what if we want to be able to choose between different implementations of IFixtureRepository? Well, YAGNI - you ain't gonna need it. But if you really do need it, sometime down the road, then by all means do the necessary - but only then.
