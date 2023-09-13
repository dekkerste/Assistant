using Assistant.Commands;
using System.Speech.Recognition;

namespace Assistant
{
    internal class AssistantController
    {
        public static void InitializeSpeechRecognition()
        {
            SpeechRecognitionEngine speechRecognitionEngine = new();

            GrammarBuilder grammarBuilder = new(GetAllCommands());
            Grammar grammar = new(grammarBuilder);

            speechRecognitionEngine.LoadGrammarAsync(grammar);
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
        }

        private static void SpeechRecognitionEngine_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            var result = GetInumeralList().Select(s => s.CommandResult(speech).Where(w => !w.Equals("")));
        }

        private static Choices GetAllCommands()
        {
            return (Choices)GetInumeralList().Select(s => s.SetCommands());
        }

        // temporary solution
        // this is purely to prevent to rewrite the same code
        private static List<ICommands> GetInumeralList()
        {
            List<ICommands> commands = new()
            {
                new BasicCommands(),
            };

            return commands;
        }

        public static CommandsClass SetCommand(List<string> input, string check)
        {
            CommandsClass commandsClass = new()
            {
                CommandInput = input,
                CommandCheck = check,
            };

            return commandsClass;
        }
    }
}
