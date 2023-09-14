namespace Assistant.Commands
{
    internal class FunCommands : ICommands
    {
        public List<CommandsClass> SetCommands()
        {
            List<string> tellJoke = new() { "Tell me a joke." };
            List<string> tellStory = new() { "Tell me a story." };

            List<CommandsClass> commandsList = new()
            {
                AssistantController.SetCommand(tellJoke, "TellJoke"),
                AssistantController.SetCommand(tellStory, "TellStory"),
            };

            return commandsList;
        }

        public string CommandResult(string command)
        {
            string result = "";

            switch (command)
            {
                case "TellJoke":
                    Random rnd = new();
                    List<string> jokes = new()
                    {
                        "What's the best ting about Switzerland? I don't know, but the flag is a big plus.",
                        "Did you hear about the mathematician who’s afraid of negative numbers? He’ll stop at nothing to avoid them.",
                        "Hear about the new restaurant called Karma? There’s no menu: You get what you deserve.",
                    };
                    int rndNum = rnd.Next(0, jokes.Count - 1);
                    result = jokes[rndNum];
                    break;
                case "TellStory":
                    result = "I don't have a story at the moment. I will have on ready when I'm done with my adventure!";
                    break;
            }

            return result;
        }
    }
}
