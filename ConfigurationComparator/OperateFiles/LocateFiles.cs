using ConfigurationComparator.Enums;
using System.IO;

namespace ConfigurationComparator.HandleFiles
{
    public class LocateFiles
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }
        private readonly IConsole _console;
        public string GetSourceFile => SourceFilePath;
        public string GetTargetFile => TargetFilePath;
        public LocateFiles(IConsole console)
        {
            _console = console;
        }

        public void LookForFile(FileType fileType)
        {
            while (true)
            {
                _console.PrintToConsole($"Write the {fileType} file name in the data folder");
                var file = _console.ReadInput();
                var filePath = Constants.DefaultPath + file;

                if (File.Exists(filePath) && file[^4..].Equals(Constants.CFGFileExtension))
                {
                    switch (fileType)
                    {
                        case FileType.Source:
                            SourceFilePath = filePath;
                            break;
                        case FileType.Target:
                            TargetFilePath = filePath;
                            break;
                        default:
                            break;
                    }
                    break;
                }
                _console.PrintToConsole("File not found");
            }
        }
    }
}
