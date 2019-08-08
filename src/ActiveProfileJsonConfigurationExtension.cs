using System;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Extension methods for adding <see cref="ActiveProfileJsonConfiguration"/>.
/// </summary>
public static class ActiveProfileJsonConfigurationExtension
{
  const string APPLICATION_ACTIVE_PROFILES = "APPLICATION_ACTIVE_PROFILES";
  /// <summary>
  /// Adds the JSON configuration provider at <paramref name="path"/> to <paramref name="builder"/> on the basis of ASPNETCORE_PROFILES.
  /// </summary>
  /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
  /// <returns></returns>
  public static IConfigurationBuilder AddActiveProfileJsonConfiguration(
      this IConfigurationBuilder builder)
  {
    return AddActiveProfileJsonConfiguration(builder, false);
  }

  /// <summary>
  /// Adds the JSON configuration provider at <paramref name="path"/> to <paramref name="builder"/> on the basis of ASPNETCORE_PROFILES.
  /// </summary>
  /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
  /// <param name="optional">Whether the file is optional.</param>
  /// <returns></returns>
  public static IConfigurationBuilder AddActiveProfileJsonConfiguration(
      this IConfigurationBuilder builder, bool optional)
  {
    return AddActiveProfileJsonConfiguration(builder, optional, false);
  }

  /// <summary>
  /// Adds the JSON configuration provider at <paramref name="path"/> to <paramref name="builder"/> on the basis of ASPNETCORE_PROFILES.
  /// </summary>
  /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
  /// <param name="optional">Whether the file is optional.</param>
  /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
  /// <returns></returns>
  public static IConfigurationBuilder AddActiveProfileJsonConfiguration(
      this IConfigurationBuilder builder, bool optional, bool reloadOnChange)
  {
    string profiles = Environment.GetEnvironmentVariable(APPLICATION_ACTIVE_PROFILES) ?? "";
    if (profiles == "")
    {
      System.Console.WriteLine($"Environment variable {APPLICATION_ACTIVE_PROFILES} is empty. Active profiles are not loaded in configuration.");
      return builder;
    }
    foreach (var profile in profiles.Split(','))
    {
      builder.AddJsonFile($"appsettings.{profile}.json", optional, reloadOnChange);
    }
    return builder;
  }
}
