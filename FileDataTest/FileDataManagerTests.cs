using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
using Moq;
using ThirdPartyTools;

namespace FileDataTest
{
    [TestClass]
    public class FileDataManagerTests
    {
        // Would prefer to use Moq here and not use Contains to validate the result

        [TestMethod]
        public void GetFileData_Version()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "-V",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        [TestMethod]
        public void GetFileData_Size()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "-S",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        [TestMethod]
        public void GetFileData_Version_Size()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "-V",
                "-S",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
            Assert.IsTrue(result.Contains("File size:"));
        }

        // -v
        [TestMethod]
        public void GetFileData_Version_First_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "-v",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        // –v
        [TestMethod]
        public void GetFileData_Version_Second_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "–v",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        // --v
        [TestMethod]
        public void GetFileData_Version_Third_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--v",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        // --v
        [TestMethod]
        public void GetFileData_Version_Fourth_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "/v",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        // --v
        [TestMethod]
        public void GetFileData_Version_fifth_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--version",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        // -s
        [TestMethod]
        public void GetFileData_Size_First_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "-s",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        // –s
        [TestMethod]
        public void GetFileData_Size_Second_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "–s",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        // --s
        [TestMethod]
        public void GetFileData_Size_Third_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--s",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        // /s
        [TestMethod]
        public void GetFileData_Size_Fourth_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "/s",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        // --size
        [TestMethod]
        public void GetFileData_Size_Fifth_Pattern()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--size",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File size:"));
        }

        [TestMethod]
        public void GetFileData_NullInput()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--size",
                "f:/test.txt"
            };

            var result = manager.GetFileData(null);

            Assert.AreEqual("No valid input", result);
        }

        [TestMethod]
        public void GetFileData_No_Valid_File_Path()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--size",
            };

            var result = manager.GetFileData(arguments);

            Assert.AreEqual("No valid input", result);
        }

        [TestMethod]
        public void GetFileData_No_Argument()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.AreEqual("No valid input", result);
        }

        [TestMethod]
        public void GetFileData_No_Valid_Argument()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "----R",
                "f:/test.txt"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("Invalid argument(s) supplied"));
        }

        [TestMethod]
        public void GetFileData_Verions_Size_Arugments_Different_Position()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--version",
                "f:/test.txt",
                "--size"
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
            Assert.IsTrue(result.Contains("File size:"));
        }

        [TestMethod]
        public void GetFileData_Verions_Size_More_Arguments()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--version",
                "f:/test.txt",
                "--size",
                "--size",
                "--size",
            };

            var result = manager.GetFileData(arguments);

            Assert.AreEqual("No valid input", result);
        }

        [TestMethod]
        public void GetFileData_Verions_Mixed_case()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--VeRsiOn",
                "f:/test.txt",
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("File version:"));
        }

        [TestMethod]
        public void GetFileData_Verions_Mixed_case_Invalid_Symbol()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--VeRsiOn//",
                "f:/test.txt",
            };

            var result = manager.GetFileData(arguments);

            Assert.IsTrue(result.Contains("Invalid argument(s) supplied"));
        }

        [TestMethod]
        public void GetFileData_More_File_Paths()
        {
            FileDetails fileDetails = new FileDetails();
            FileDataManager manager = new FileDataManager(fileDetails);

            var arguments = new string[] {
                "--VeRsiOn//",
                "f:/test.txt",
                "f:/test.txt",
                "f:/test.txt",
            };

            var result = manager.GetFileData(arguments);

            Assert.AreEqual("No valid input", result);
        }
    }
}
