using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Would prefer doing Dependency injection
            FileDetails fileDetails = new FileDetails();
            FileDataManager fileDataManager = new FileDataManager(fileDetails);
            var result = fileDataManager.GetFileData(args);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
