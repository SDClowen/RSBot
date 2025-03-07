using Microsoft.Extensions.DependencyInjection;
using RSBot.Party.Services;
using RSBot.Party.ViewModels;
using System;

namespace RSBot.Party;

/// <summary>
/// Manages application-level dependencies and services for the Party plugin
/// </summary>
public static class App
{
    private static IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes the application services and dependencies
    /// </summary>
    public static void Initialize()
    {
        var services = new ServiceCollection();

        // Register services
        services.AddSingleton<IPartyService, PartyService>();

        // Register view models
        services.AddTransient<MainViewModel>();
        services.AddTransient<AutoFormPartyViewModel>();

        _serviceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Gets a service of the specified type from the service provider
    /// </summary>
    public static T GetService<T>() where T : class
    {
        return _serviceProvider.GetService<T>();
    }
} 