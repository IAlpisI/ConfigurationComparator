namespace ConfigurationComparator.Commands
{
    public class ViewFilesCommand
    {
        private readonly string SourceFile;
        private readonly string TargetFile;
        private readonly IConsole _console;

        public ViewFilesCommand(string sf, string tf, IConsole console)
        {
            SourceFile = sf;
            TargetFile = tf;
            _console = console;
        }

        public void Execute()
        {
            _console.PrintToConsole($"Source file - {SourceFile} \nTarget file - {TargetFile}");
        }
    }
}
