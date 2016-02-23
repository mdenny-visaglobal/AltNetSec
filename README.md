# AltNetSec
This is the code from the IdentityCrisis talk I gave at Melbourne alt.net on Feb 23 2016.

The Visual Studio solution contains three projects:
- API - The API for retrieving random Chuck Norris Quotes
- ConsoleApp - A simple console application for consuming the API
- IdentityServer - the Identity Server and IdentityManager

To get the app up and going, you will need a SQL database matching the connection string in web.config
The DB can be empty it just needs to exist and you need to have write access.

Navigate to https://localhost:44304/admin to set up an initial user account for Aurelia to authenticate with.

A user account is not required for the ConsoleApp.

To get the Aurelia application up and running refer to the README.md in the Aurelia subdirectory.
I use Visual Studio Code to edit the Aurelia app but whatever your editor of choice will be fine.
The app is based on the skeleton Aurelia application - check out http://aurelia.io for more details

Any questions you can ping me on Twitter @habaneroofdoom 

Thanks!

Marcus