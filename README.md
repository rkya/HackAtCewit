
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

## APIs
- Faq
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Faq`</td>
    <td>Get all the FAQs.</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/Faq/Add`</td>
    <td>Add new FAQ (admin).</td>
  </tr>
  <tr>
    <td>`PUT`</td>
    <td>`/Faq/Edit/{id}`</td>
    <td>Edit existing FAQ (admin).</td>
  </tr>
  <tr>
    <td>`DELETE`</td>
    <td>`/Faq/Delete/{id}`</td>
    <td>Delete FAQ (admin).</td>
  </tr>
</table>

- Resources
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Resources`</td>
    <td>Get all the Resources.</td>
  </tr>
  <tr>
    <td>`GET`</td>
    <td>`/Resources/{id}`</td>
    <td>Get a particular Resource.</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/Resources/Add`</td>
    <td>Add a new Resource (admin).</td>
  </tr>
  <tr>
    <td>`PUT`</td>
    <td>`/Resources/Edit/{id}`</td>
    <td>Edit existing Resource (admin).</td>
  </tr>
  <tr>
    <td>`DELETE`</td>
    <td>`/Resources/Delete/{id}`</td>
    <td>Delete Resource (admin).</td>
  </tr>
</table>

- Schedule
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Schedule`</td>
    <td>Get all the events.</td>
  </tr>
  <tr>
    <td>`GET`</td>
    <td>`/Schedule/{id}`</td>
    <td>Get details of a particular event.</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/Schedule/Add`</td>
    <td>Add a new event (admin).</td>
  </tr>
  <tr>
    <td>`PUT`</td>
    <td>`/Schedule/Edit/{id}`</td>
    <td>Edit an existing event (admin).</td>
  </tr>
  <tr>
    <td>`DELETE`</td>
    <td>`/Schedule/Delete/{id}`</td>
    <td>Delete event (admin).</td>
  </tr>
</table>

- Day
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Day/{year}/{month}/{day}`</td>
    <td>Get all the events on this day.</td>
  </tr>
</table>

- Checkin
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Checkin`</td>
    <td>Get the list of checkedin and non-checkedin users (admin).</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/Checkin`</td>
    <td>Checkin a user (admin).</td>
  </tr>
</table>

- Videos
<table>
  <tr>
    <td>`GET`</td>
    <td>`/Videos`</td>
    <td>Get all the Videos.</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/Videos/Add`</td>
    <td>Add new Video (admin).</td>
  </tr>
  <tr>
    <td>`PUT`</td>
    <td>`/Videos/Edit/{id}`</td>
    <td>Edit existing Video (admin).</td>
  </tr>
  <tr>
    <td>`DELETE`</td>
    <td>`/Videos/Delete/{id}`</td>
    <td>Delete Video (admin).</td>
  </tr>
</table>

- LeaderBoard
<table>
  <tr>
    <td>`GET`</td>
    <td>`/LeaderBoard`</td>
    <td>Get the entire leaderboard.</td>
  </tr>
  <tr>
    <td>`POST`</td>
    <td>`/LeaderBoard/Add`</td>
    <td>Add new participant to the leaderboard (admin).</td>
  </tr>
  <tr>
    <td>`PUT`</td>
    <td>`/LeaderBoard/Edit/{id}`</td>
    <td>Edit score of a participant on leaderboard (admin).</td>
  </tr>
  <tr>
    <td>`DELETE`</td>
    <td>`/LeaderBoard/Delete/{id}`</td>
    <td>Delete participant from the leaderboard (admin).</td>
  </tr>
</table>

## Built With

* [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) - An open-source, general-purpose development platform maintained by Microsoft and the .NET community on GitHub.

## Contributing

Please read [CEWIT's Code Policy](https://dev.cewit.stonybrook.edu/snippets/12) for committing code to GitLab.

## Author

* **Rohan Karhadkar**
