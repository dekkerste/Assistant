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

            // need a fix for 'may be null here' warning
            var commandCode = GetInumeralList()
                .Where(w => w.CommandInput
                .Contains(speech))
                .Select(s => s.CommandCheck)
                .FirstOrDefault();

            // run command
            List<ICommands> commands = new()
            {
                new BasicCommands(),
            };

            foreach (var command in commands)
            {
                if (commandCode != null)
                {
                    command.CommandResult(commandCode);
                }
            }
        }

        // find a way to create a better version of this
        private static Choices GetAllCommands()
        {
            List<string> commands = new();

            var commandsList = GetInumeralList()
                .Select(s => s.CommandInput)
                .ToList();

            foreach (var command in commandsList)
            {
                if (command != null)
                {
                    foreach (var comm in command)
                    {
                        commands.Add(comm);
                    }
                }
            }

            return new Choices(commands.ToArray());
        }

        // temporary solution
        // this is purely to prevent to write the same commands list twice
        // idea solution: create an <T>Class, where you can select the one or the other object type
        private static List<CommandsClass> GetInumeralList()
        {
            List<ICommands> commands = new()
            {
                new BasicCommands(),
            };

            List<CommandsClass>? result = commands
                .Select(s => s.SetCommands())
                .FirstOrDefault();

            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<CommandsClass>();
            }
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
