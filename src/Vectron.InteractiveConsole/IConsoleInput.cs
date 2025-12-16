namespace Vectron.InteractiveConsole;

/// <summary>
/// Class that maintains the current console input.
/// </summary>
public interface IConsoleInput
{
    /// <summary>
    /// Gets or sets the current user input.
    /// </summary>
    public string CurrentInput
    {
        get;
        set;
    }
}
