using ConfigurationComparator.Enums;
using ConfigurationComparator.Logging;
using System.IO;

namespace ConfigurationComparator.HandleFiles
{
    public class LocateFiles
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        public string GetSourceFile => SourceFilePath;
        public string GetTargetFile => TargetFilePath;
        public LocateFiles(IMessageWriter messageWriter, IMessageReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;
        }

        public void LookForFile(FileType fileType)
        {
            while (true)
            {
                _messageWriter.Write($"Write the {fileType} file name in the data folder");
                var file = _messageReader.Read();
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
                _messageWriter.Write("File not found");
            }
        }
    }
}
