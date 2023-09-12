namespace Assistant
{
    public partial class AssistantForm : Form
    {
        public AssistantForm()
        {
            InitializeComponent();
            AssistantController.InitializeSpeechRecognition();
        }
    }
}