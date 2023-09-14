namespace Assistant.Commands
{
    internal class BasicCommands : ICommands
    {
        public List<CommandsClass> SetCommands()
        {
            List<string> sayHello = new() { "Say hello." };
            List<string> sayGoodbye = new() { "Say bye.", "Say goodbye." };
            List<string> tellTime = new() { "What time is it?", "Tell me the time.", "What is the time?" };

            List<CommandsClass> commandsList = new()
            {
                AssistantController.SetCommand(sayHello, "SayHello"),
                AssistantController.SetCommand(sayGoodbye, "SayGoodbye"),
                AssistantController.SetCommand(tellTime, "TellTime")
            };

            return commandsList;
        }

        public string CommandResult(string command)
        {
            string result = "";

            switch (command)
            {
                case "SayHello":
                    result = "Hi";
                    break;
                case "SayGoodbye":
                    result = "Bye";
                    break;
                case "TellTime":
                    result = DateTime.Now.TimeOfDay.ToString();
                    break;
            }

            return result;
        }
    }
}
