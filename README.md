# FGB Insite Team Task

One of our clients requested us to build a small UI that displays a list of members (season pass
holders) and one-time game tickets that accessed the stadium given a season and a game, or a
product code.

## Exercise 1
We have already made a .NET Core project to get and return the data; however, it has not been built
correctly.

The task will require you to refactor or rewrite the app. The implementation requirements are:

- Apply an appropriate design pattern to get, manipulate and return the data.
- Re-implement the GetAttendanceListFor method as it does not return correct data.
- Provide a way to get the attendance list both by season and a game, and by a product code.
- The API is not secure: anyone can use it. This vulnerability needs to be addressed.
- Write automatic tests.

## Exercise 2
Create a simple front-end application using Angular 2+ that consumes the API and displays a list of
members/ticket barcodes per season and a game, or product. The season and game combination
should be selected using dropdowns. The product must be selected using a dropdown as well.

## Setup
In the repository there is now the InsiteTeamTask WebAPI, and a ClientApp folder containing the Angular application.
To run the app, fire up the WebAPI, navigate to `ClientApp/insite-client-app` using any console/bash/whatever, and run `npm start`. The browser will open to the client application, and you should be ready to go.

The login credentials I've coded in are:
- Username: **fortress**
- Password: **insite**

## Possible issues
The only thing that I can think of would be that the WebAPI may be running on a different port in your environment. The webapi location is hard coded in to a couple of places (this would be set in a config file in production) which would need changing. These are:
- The `apiUrl` variable in [ClientApp/insite-client-app/src/app/webapi-service/webapi.service.ts](ClientApp/insite-client-app/src/app/webapi-service/webapi.service.ts)
- The JWT setup in [InsiteTeamTask/Startup.cs](InsiteTeamTask/Startup.cs)
- The JWT setup in [InsiteTeamTask/Controllers/AuthenticationController.cs](InsiteTeamTask/Controllers/AuthenticationController.cs)
