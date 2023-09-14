namespace Assistant.Commands
{
    internal class BasicCommands : ICommands
    {
        public List<CommandsClass> SetCommands()
        {
            List<string> sayHello = new() { "Say hello." };
            List<string> sayGoodbye = new() { "Say bye.", "Say goodbye." };
            List<string> tellTime = new() { "What time is it?", "Tell me the time.", "What is the time?" };
            List<string> CloseAssistant = new() { "Go away.", "Stop running." };

            List<CommandsClass> commandsList = new()
            {
                AssistantController.SetCommand(sayHello, "SayHello"),
                AssistantController.SetCommand(sayGoodbye, "SayGoodbye"),
                AssistantController.SetCommand(tellTime, "TellTime"),
                AssistantController.SetCommand(CloseAssistant, "CloseAssistant"),
            };

            return commandsList;
        }

        public string CommandResult(string command)
        {
            string result = "";

            switch (command)
            {
                case "SayHello":
                    result = "Hello, sir.";
                    break;
                case "SayGoodbye":
                    result = "Goodbye, sir.";
                    break;
                case "TellTime":
                    result = DateTime.Now.ToShortTimeString();
                    break;
                case "CloseAssistant":
                    result = "Goodbye, sir.";
                    Application.Exit();
                    break;
            }

            return result;
        }
    }
}
