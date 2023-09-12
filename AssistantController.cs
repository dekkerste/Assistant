using System.Speech.Recognition;

namespace Assistant
{
    internal class AssistantController
    {
        public static void InitializeSpeechRecognition()
        {
            SpeechRecognitionEngine speechRecognitionEngine = new SpeechRecognitionEngine();

            GrammarBuilder grammarBuilder = new GrammarBuilder(GetAllCommands());
            Grammar grammar = new Grammar(grammarBuilder);

            speechRecognitionEngine.LoadGrammarAsync(grammar);
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
        }

        private static void SpeechRecognitionEngine_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            var speech = e.Result.Text;
        }

        private static Choices GetAllCommands()
        {
            return new Choices("hello world");
        }
    }
}
