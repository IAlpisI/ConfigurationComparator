using ConfigurationComparator.Enums;
using ConfigurationComparator.Logging;
using System.IO;
using ConfigurationComparator.Extensions;

namespace ConfigurationComparator.HandleFiles
{
    public class LocateFiles
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        public string GetSourceFilePath => SourceFilePath;
        public string GetTargetFilePath => TargetFilePath;
        public LocateFiles(IMessageWriter messageWriter, IMessageReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;
        }

        public void LookForFile(FileType fileType, string extension)
        {
            while (true)
            {
                _messageWriter.Write($"Write the {fileType} file name in the data folder");
                var file = _messageReader.Read();
                var filePath = Path.Combine(Constants.DefaultPath, file);

                if (extension.CheckFile(Constants.DefaultPath, file))
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
