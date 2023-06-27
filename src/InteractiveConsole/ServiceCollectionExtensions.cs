using InteractiveConsole.Ansi;
using InteractiveConsole.AutoComplete;
using InteractiveConsole.Commands;
using InteractiveConsole.Cursor;
using InteractiveConsole.History;
using InteractiveConsole.Input;
using InteractiveConsole.KeyHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InteractiveConsole;

/// <summary>
/// Extension methods for adding services to an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the services needed for running interactive console with commands.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddConsoleCommand(this IServiceCollection services)
    {
        _ = services.AddInteractiveConsole();
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IAutoCompleteHandler, CommandAutoCompleteHandler>());
        services.TryAddSingleton<IInputHandler, CommandInputHandler>();
        services.TryAddScoped<IConsoleCommandHierarchy, ConsoleCommandHierarchy>();
        return services;
    }

    /// <summary>
    /// Adds the services needed for running interactive console.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddInteractiveConsole(this IServiceCollection services)
    {
        services.TryAddSingleton<IConsoleInput, AnsiConsoleInput>();
        services.TryAddSingleton<IConsoleOutput>(AnsiConsoleOutput.Instance);
        services.TryAddSingleton<IConsoleCursor, AnsiConsoleCursor>();
        services.TryAddSingleton<IHistoryHandler, HistoryHandler>();
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IKeyHandler, AutoCompleteKeyHandler>());
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IKeyHandler, CursorKeyHandler>());
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IKeyHandler, HistoryKeyHandlers>());
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IKeyHandler, TextKeyHandler>());
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IKeyHandler, EnterKeyHandler>());
        return services.AddHostedService<ConsoleInputHost>()
            .ConfigureOptions<ConsoleInputOptionsDefaults>();
    }
}
