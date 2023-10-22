# Planning App Backend

This is the backend project that contains and serves the ClientApp.

Running this project alone will serve the complete webapp.

## Development server

Launch the server:
1. Go to this directory
2. Run "dotnet watch run"
3. Open url "https://localhost:44448" in a browser (automatic).

Alternatively, launch the frontend codes in a separated command window (after launching the server from the previous steps):
1. Go to the ClientApp directory "cd ./ClientApp"
2. Run "ng serve"
3. Open url "http://localhost:4200" in a browser.

## Notes

The README.md file in the root folder mentions Google apis and Jira apis, but does not provide an api key or a valid jira credential.
In this solution, I have added but commented out codes for google and jira api calls (CalendarService.cs and JiraService.cs). I am not going to include a key or credential in this repo.

The requirements did not mention filtering and paging. If filtering and paging were required, I would deserialise and filter the json objects returned from the google/jira apis on the server side instead of on the client side in the current codes, which required extensive mapping.
