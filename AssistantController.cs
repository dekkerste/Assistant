using Assistant.Commands;
using Microsoft.VisualBasic.Logging;
using System.Speech.Recognition;
using System.Speech.Synthesis;

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

            List<ICommands> commands = GetInumeralListTemp();

            foreach (var command in commands)
            {
                if (commandCode != null)
                {
                    string responce = command.CommandResult(commandCode);

                    AssistantResponce(speech, responce, true);
                }
                break;
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
            List<ICommands> commands = GetInumeralListTemp();

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
        private static List<ICommands> GetInumeralListTemp()
        {
            // fix bug where only one of those will be seen / activated
            List<ICommands> commands = new()
            {
                new BasicCommands(),
                //new FunCommands(),
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

        public static void AssistantResponce(string userText, string assistantResponce, bool assistantSpeak = false, bool assistantResponcePrefix = true)
        {
            // maybe there's another solution to write to the richTextBox?
            RichTextBox assistantLog = Application.OpenForms["AssistantForm"].Controls["AssistantLog"] as RichTextBox;
            assistantLog.AppendText($"User: {userText}\n");

            if (assistantResponcePrefix)
            {
                assistantLog.AppendText($"Assistant: {assistantResponce}\n");
            }
            else
            {
                assistantLog.AppendText($"{assistantResponce}\n");
            }

            if (assistantSpeak)
            {
                SpeechSynthesizer synthesizer = new();
                synthesizer.SpeakAsync($"{assistantResponce}\n");
            }
        }
    }
}
