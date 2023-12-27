# Weather Forecast Application

This ASP.NET MVC application provides weather forecasts using an external API and stores user data via Entity Framework. The frontend is built using Vue.js for enhanced user interaction.

## Features

- **Weather Forecast**: Retrieve current weather conditions and forecasts for a specified location from a external api.
- **User Registration/Login**: Users can register, login, and save their favorite locations for weather forecasts.
- **Entity Framework**: Utilizes Entity Framework to manage database interactions for user data.
- **Vue.js Integration**: Frontend development powered by Vue.js for dynamic and responsive user interfaces.

## Technologies Used

- **ASP.NET MVC**: Backend framework for the web application.
- **Entity Framework**: ORM (Object-Relational Mapping) for database operations.
- **Vue.js**: JavaScript framework for building interactive user interfaces.
- **External API**: Integrates with a third-party weather API for weather data.
- **HTML/CSS/JavaScript**: Frontend development for user interaction and display.
- **C#**: Primary programming language for backend logic.

## Getting Started

### Prerequisites

- Visual Studio (or any compatible IDE) for running and editing the application.
- .NET Core 6.0.
- https://marketplace.visualstudio.com/items?itemName=MakotoAtsu.AspNetCoreViteStarter For seting up production use.

### Installation

1. Clone the repository: `git clone https://github.com/ItsSimko/MVC-Weather-App.git`
2. Open the solution file in Visual Studio.
3. Restore necessary packages using NuGet Package Manager.
4. Update the API keys or configurations for the external weather service in the `appsettings.json` file.
5. Set up the database connection string in the `appsettings.json` file.
6. Navigate to the Vue.js frontend directory and install dependencies using npm or yarn.
7. Build and run the application.
8. Setup for production using IIS and following VS [extenstion](https://marketplace.visualstudio.com/items?itemName=MakotoAtsu.AspNetCoreViteStarter).

## Usage

1. **Homepage**: Upon accessing the application, users can view the current weather for a default location.
2. **Register/Login**: Users can register an account or log in to save favorite locations.
3. **Search**: Enter a location to get the current weather conditions and forecast.
4.  **Admin**: Ability to set user privelage levels, and update site headers.

## API Reference

This application uses [OpenWeather](https://openweathermap.org/) for weather data. Please refer to their documentation for specific API usage and endpoints.


## Contact
For any questions or concerns, please contact Alex at alexsimko4@gmail.com
