## About

This library can be used to add an extension method to **IConfigurationBuilder** to generate configuration object from Json files on the basis on active profiles set in environment variable **APPLICATION_ACTIVE_PROFILES**.

## Usage

### Setup

- Install the nuget package by following the steps given at nuget package [ActiveProfileJsonConfiguration](https://www.nuget.org/packages/ActiveProfileJsonConfiguration/) in your dotnet core application.
- Set the environment variable **APPLICATION_ACTIVE_PROFILES** to the active profiles to be taken. e.g.
  ```
  APPLICATION_ACTIVE_PROFILES=prod,uswest2
  ```
  **NOTE:** Configurations will be loaded in the order of the given profiles. If same configuration is found in configuration files, later one will get the priority.
- Create appsettings files for each profile with the desired configurations on the root of the application. e.g.
  ```
  appsettings.prod.json and
  appsettings.uswest2.json
  ```

### Code

Use the new extension methond **AddActiveProfileJsonConfiguration** added to **IConfigurationBuilder**
```
config.AddActiveProfileJsonConfiguration()
  OR
config.AddActiveProfileJsonConfiguration(optional: true)
  OR
config.AddActiveProfileJsonConfiguration(optional: true, reloadOnChange:true)
```

## Samples
Console and webapi sample projects can be found in sample folder.
Don't forget to set environment variable **APPLICATION_ACTIVE_PROFILES** before running any sample.
