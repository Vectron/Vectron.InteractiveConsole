using Vectron.InteractiveConsole.Commands;

namespace Vectron.InteractiveConsole.Sandbox.Opc;

/// <summary>
/// A <see cref="IConsoleCommand"/> for connecting to the PLC through OPC.
/// </summary>
internal sealed class OpcConnectCommand : IConsoleCommand
{
    /// <inheritdoc/>
    public string[]? ArgumentNames => null;

    /// <inheritdoc/>
    public string[] CommandParameters => ["opc", "connect"];

    /// <inheritdoc/>
    public string HelpText => "Connect to the PLC through OPC";

    /// <inheritdoc/>
    public int MaxArguments => 0;

    /// <inheritdoc/>
    public int MinArguments => 0;

    /// <inheritdoc/>
    public void Execute(string[] arguments)
        => Console.WriteLine("Connected to PLC");
}
