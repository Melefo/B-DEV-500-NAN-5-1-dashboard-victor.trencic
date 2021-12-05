# Doshboard

## Services & Widgets

| Services | Widgets |
|----------|---------|
| Crypto | <table><tbody><tr><th>Name</th><th>Description</th><th>Params</th></tr><tr><td>Realtime Crypto</td><td>Display realtime cryptocurrency informations</td><td>Currency code<br>Another currency code to convert into</td></tr></tbody></table> |
| RSS | <table><tbody><tr><th>Name</th><th>Description</th><th>Params</th></tr><tr><td>Rss Feed</td><td>Display N last items from a RSS feed</td><td>RSS Feed URL<br>Number of items to display</td></tr></tbody></table>|
| Steam | <table><tbody><tr><th>Name</th><th>Description</th><th>Params</th></tr><tr><td>Game</td><td>Display informations about a game</td><td>Game name</td></tr></tbody></table>|
| Weather | <table><tbody><tr><th>Name</th><th>Description</th><th>Params</th></tr><tr><td>City Temperature</td><td>Display current temperature for a city</td><td>City name<br>Unit of temperature</td></tr></tbody></table>|
| YouTube ⚠ | <table><tbody><tr><th>Name</th><th>Description</th><th>Params</th></tr><tr><td>Video</td><td>Display realtime video informations</td><td>Video id</td></tr></tbody></table>|

⚠ You must associate your Google account via OAuth to use the YouTube service 

## How to connect

You must use the form to create a local account and sign up

You can then sign in with your email or username registered

You can also sign in with your Google account if it has the same email address you used to sign up

## Admins

If you are an administrator user you have the possibility to see all registered users, to be able to delete their profile and finally to be able to change their user role in admin or to return them to an user

## Dashboard

On your dashboard page you have the ability to move widgets as you see fit to create your own personal space

Widgets are reconfigurable even after adding them.

The widgets are also updated in real time with a WebSocket, you can change the timer of its refresh rate (in minutes) in the same place as you reconfigure the widget

## How to launch your own instance

You have a provide a lot of environment variables:

First of all the variables for the Mongo database
 - MONGO_USERNAME = Root username
 - MONGO_PASSWORD = Root password
 - MONGO_DATABASE = Name of Database used by the backend

Then variables to use Google services
[Create here a Google App](https://console.cloud.google.com/apis/credentials)
 - GOOGLE_CLIENTID = ClientId of yout Google App
 - GOOGLE_CLIENTSECRET = ClientSecret of yout Google App
 - GOOGLE_APIKEY = API key of your Google App with YouTube Data API v3 activated

Then the API keys of all used APIs
 - WEATHER_APIKEY = Your API Key from [OpenWeather](https://api.openweathermap.org)
 - CRYPTO_APIKEY = Your API Key from [Nomics](https://api.nomics.com)
 - STEAM_APIKEY = Your API Key from [Steam](https://steamcommunity.com/dev/apikey)
 - FOOT_APIKEY = Yout API Key from [football-data.org](https://www.football-data.org/)

 Finally the key used by the backend to create the JWT
 - JWTKEY = A random string with at least 16 chars

Once you have all your environment variables set you can perform the `docker-compose up --build` command

Frontend will be available at: http://localhost:80/

Backend will be available at: http://localhost:8080/

Mongo will be available at: mongodb://MONGO_USERNAME:MONGO_PASSWORD@localhost:27017/