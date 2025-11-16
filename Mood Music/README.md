# Mood Music 🎵

Mood Music is a .NET MVC web application that allows users to discover music based on mood or search keywords. The app retrieves track information and preview clips from the Deezer API and allows users to save their favorite tracks to a local SQLite database.

## Features

- Search for music by mood or keyword
- View track details such as artist, album, and cover art
- Play short audio previews
- Save tracks to a Favorites list
- Favorites are stored locally using Entity Framework Core

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core + SQLite
- IHttpClientFactory for API communication
- xUnit for unit testing

## Design Pattern

The application uses an abstraction between the controller and the music API through the `IMusicProvider` interface and a factory (`MusicProviderFactory`) to create the provider. This makes it possible to replace or add new music providers in the future without changing the UI or controllers.

## Running the Application

Before running the app, ensure that dependencies are restored and the database is created. 
This can be done using the following commands:

dotnet restore
dotnet ef database update
dotnet run

Open the browser at the local URL shown in the console.

## Unit Testing

The project includes unit tests to ensure that the core functionality works as intended. The Favorites controller is tested to verify that tracks can be saved and that duplicates are prevented. The Discover controller is tested using a fake music provider and factory, allowing its behavior to be tested without making real API calls. The MusicProviderFactory is tested to confirm that it returns the correct provider implementation, and the Track model is tested to ensure that its properties store data correctly. All tests are written using xUnit and follow clear and descriptive naming conventions.