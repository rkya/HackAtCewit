
# HackAtCewitManagementSystem

This is a .NET Core application - a website for Hackathon. It contains both the backend and frontend code for the website. It has some of its APIs exposed so that other applications can fetch data and display on other platforms like the React Native application for Android and iOS users.

## Introduction

For development purposes, it can run on localhost. You can also run it on the IP address of your computer found using `ifconfig` command (for Linux users).

### Requirements

* Desktop / Laptop
* Browser (Tested on Google Chrome)

### Installation

Clone the **dev** branch and start expo.

```bash
git clone < URL >
cd < path >
```

Open Visual Studio and start the application to run on localhost. If you want it to be accessible to everyone besides your computer, find your IP address using `ifconfig` (for Linux users) and set it as the host address in `Properties/launchSettings.json`.

## Running the tests

Use Visual Studio's test runner UI to run the tests.

## Deployment

Just copy the code to the server and change the host address in `Properties/launchSettings.json` to the server IP address.

## Built With

* [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) - An open-source, general-purpose development platform maintained by Microsoft and the .NET community on GitHub.

## Contributing

Please read [CEWIT's Code Policy](https://dev.cewit.stonybrook.edu/snippets/12) for committing code to GitLab.

## Author

* **Rohan Karhadkar**
