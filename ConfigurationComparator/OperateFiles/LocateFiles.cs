using ConfigurationComparator.Enums;
using System.IO;

namespace ConfigurationComparator.HandleFiles
{
    public class LocateFiles
    {
        private string SourceFilePath { get; set; }
        private string TargetFilePath { get; set; }
        private readonly IDataProcess _dataProcess;
        public string GetSourceFile => SourceFilePath;
        public string GetTargetFile => TargetFilePath;
        public LocateFiles(IDataProcess dataProcess)
        {
            _dataProcess = dataProcess;
        }

        public void LookForFile(FileType fileType)
        {
            while (true)
            {
                _dataProcess.Print($"Write the {fileType} file name in the data folder");
                var file = _dataProcess.ReadInput();
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
                _dataProcess.Print("File not found");
            }
        }
    }
}
