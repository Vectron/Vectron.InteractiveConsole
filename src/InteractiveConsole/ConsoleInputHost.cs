using InteractiveConsole.KeyHandlers;
using Microsoft.Extensions.Hosting;

namespace InteractiveConsole;

/// <summary>
/// A console input checker.
/// </summary>
internal sealed class ConsoleInputHost : BackgroundService
{
    private const string InteractiveModeText = "INTERACTIVE MODE - type 'help' for help or 'exit' to EXIT";
    private readonly IEnumerable<IKeyHandler> keyHandlers;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleInputHost"/> class.
    /// </summary>
    /// <param name="keyHandlers">The key handlers for processing the input.</param>
    public ConsoleInputHost(IEnumerable<IKeyHandler> keyHandlers)
        => this.keyHandlers = keyHandlers;

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine(InteractiveModeText);
        while (!stoppingToken.IsCancellationRequested)
        {
            var keyInfo = await ReadKeyAsync(intercept: true, stoppingToken).ConfigureAwait(false);
            foreach (var keyHandler in keyHandlers)
            {
                keyHandler.Handle(keyInfo);
            }
        }
    }

    private static async Task<ConsoleKeyInfo> ReadKeyAsync(bool intercept, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(intercept);
            }

            await Task.Delay(5, cancellationToken).ConfigureAwait(false);
        }

        return default;
    }
}
