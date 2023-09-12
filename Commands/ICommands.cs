namespace Assistant.Commands
{
    internal interface ICommands
    {
        List<string> GetCommands();

        string CommandResult();
    }
}
