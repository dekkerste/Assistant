namespace Assistant.Commands
{
    internal interface ICommands
    {
        List<CommandsClass> SetCommands();

        //List<string> GetCommands();

        string CommandResult(string command);
    }
}
