using Vectron.InteractiveConsole.Commands;

namespace Vectron.InteractiveConsole.Sandbox.Opc;

/// <summary>
/// A <see cref="IConsoleCommand"/> for writing a variable from the PLC.
/// </summary>
internal sealed class OpcWriteCommand : IConsoleCommand
{
    /// <inheritdoc/>
    public string[] CommandParameters => new[] { "opc", "write" };

    /// <inheritdoc/>
    public string HelpText => "Write a value to the PLC through OPC";

    /// <inheritdoc/>
    public int MaxArguments => 2;

    /// <inheritdoc/>
    public int MinArguments => 2;

    /// <inheritdoc/>
    public void Execute(string[] arguments)
        => Console.WriteLine($"Wrote {arguments[1]} to {arguments[0]} in the PLC");
}