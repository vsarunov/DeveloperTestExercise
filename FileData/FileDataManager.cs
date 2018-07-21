using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileDataManager
    {
        // Would be better if this would have an interface
        // thus allowing to mock it on testing
        private readonly FileDetails _fileDetailsManager;

        public FileDataManager(FileDetails fileDetailsManager)
        {
            _fileDetailsManager = fileDetailsManager;
        }

        public string GetFileData(string[] args)
        {
            if (args != null)
            {
                var filePath = args.GetValidFilePath();
                if (args != null && args.ValidateArgumentSize(2, 3) && filePath != null)
                {
                    //Get all invalid arguments supplied excluding the filepath
                    //If there are not valid arguments reject command
                    var generalPattern = StaticPatterns.VersionPatterns;
                    generalPattern.AddRange(StaticPatterns.SizePatterns);
                    var invalidArguments = args.GetInvalidArguments(generalPattern).Where(x => x != filePath);

                    if (invalidArguments != null && invalidArguments.Count() != 0)
                    {
                        return $"Invalid argument(s) supplied: {string.Join(",", invalidArguments)}";
                    }

                    return GetDetailsByArguments(args, filePath);
                }
            }
            return "No valid input";
        }

        private string GetDetailsByArguments(IEnumerable<string> arguments, string filePath)
        {
            StringBuilder resultBuilder = new StringBuilder();
            var sizeArgument = arguments.GetValidArguments(StaticPatterns.SizePatterns);
            var versionArgument = arguments.GetValidArguments(StaticPatterns.VersionPatterns);

            if (sizeArgument != null && sizeArgument.Count() != 0)
            {
                resultBuilder.AppendLine($"File size: {_fileDetailsManager.Size(filePath)}");
            }

            if (versionArgument != null && versionArgument.Count() != 0)
            {
                resultBuilder.AppendLine($"File version: {_fileDetailsManager.Version(filePath)}");
            }

            return resultBuilder.ToString();
        }

    }
}
