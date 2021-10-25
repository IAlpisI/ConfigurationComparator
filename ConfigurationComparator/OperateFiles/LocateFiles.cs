using ConfigurationComparator.Enums;
using ConfigurationComparator.Logging;
using ConfigurationComparator.Extensions;

namespace ConfigurationComparator.HandleFiles
{
    public class LocateFiles
    {
        private readonly IWriter _messageWriter;
        private readonly IReader _messageReader;
        public LocateFiles(IWriter messageWriter, IReader messageReader)
        {
            _messageWriter = messageWriter;
            _messageReader = messageReader;
        }

        /// <summary>
        /// Get user's input and check whenever file type is correct
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="fileType">File type</param>
        public string LookForFile(string path, FileType fileType)
        {
            _messageWriter.Write($"Write the {fileType} file name in the data folder");
            var fileName = _messageReader.Read();            
            var isFilePresent = Constants.CFGFileExtension.CheckFile(path, fileName);

            if (isFilePresent)
            {
                return fileName;
            }

            _messageWriter.Write("File not found");

            return string.Empty;
        }
    }
}
