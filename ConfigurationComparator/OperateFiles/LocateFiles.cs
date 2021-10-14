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
        private readonly IWriter _messageWriter;
        private readonly IReader _messageReader;
        public string GetSourceFilePath => SourceFilePath;
        public string GetTargetFilePath => TargetFilePath;
        public LocateFiles(IWriter messageWriter, IReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;
        }

        /// <summary>
        /// Get user's input and check whenever file type is correct
        /// </summary>
        /// <param name="fileType">File type to look for</param>
        /// <param name="path">File path</param>
        public void LookForFile(FileType fileType, string path)
        {
            while (true)
            {
                _messageWriter.Write($"Write the {fileType} file name in the data folder");
                var file = _messageReader.Read();
                var filePath = Path.Combine(path, file);

                if (Constants.CFGFileExtension.CheckFile(path, file))
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
