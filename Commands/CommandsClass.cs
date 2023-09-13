namespace Assistant.Commands
{
    internal class CommandsClass
    {
        /// <summary>
        /// Commands that the user can use to activate this command.
        /// </summary>
        public List<string>? CommandInput { get; set; }
        /// <summary>
        /// The text that the controller can check for.
        /// </summary>
        public string? CommandCheck { get; set; }
        //public string? CommandOutput { get; set; }
    }
}
