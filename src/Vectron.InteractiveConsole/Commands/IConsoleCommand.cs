namespace Vectron.InteractiveConsole.Commands;

/// <summary>
/// A interface describing a command that can be executed.
/// </summary>
public interface IConsoleCommand
{
    /// <summary>
    /// Gets a collection of names for the arguments.
    /// </summary>
    public string[]? ArgumentNames
    {
        get;
    }

    /// <summary>
    /// Gets the command parameters.
    /// </summary>
    public string[] CommandParameters
    {
        get;
    }

    /// <summary>
    /// Gets text explaining this <see cref="IConsoleCommand"/>.
    /// </summary>
    public string HelpText
    {
        get;
    }

    /// <summary>
    /// Gets the maximum arguments needed to run this command.
    /// </summary>
    public int MaxArguments
    {
        get;
    }

    /// <summary>
    /// Gets the minimum arguments needed to run this command.
    /// </summary>
    public int MinArguments
    {
        get;
    }

    /// <summary>
    /// Execute this command.
    /// </summary>
    /// <param name="arguments">Collection of arguments for this command.</param>
    public void Execute(string[] arguments);
}
