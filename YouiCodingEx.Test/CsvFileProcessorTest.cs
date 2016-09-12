using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YouiCodingEx.Test
{


    [TestClass]
    public class CsvFileProcessorTest
    {
        private CsvFileProcessor CsvFileProcessor = new CsvFileProcessor();
        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

        [TestMethod]
        public void TestOrderedNames()
        {
            CsvFileProcessor.Process();

            const string resultedFile = @"C:\\ExportedOrderedNames.txt";
            const string expectedFile = @"c:\\Projects\\YouiCodingEx\\YouiCodingEx.Test\\ExpectedOrderedNames.txt";

           
            var resultedFileHashed = GetFileHash(resultedFile);
            var expectedFileHashed = GetFileHash(expectedFile);

            Assert.AreEqual(expectedFileHashed, resultedFileHashed);

        }

        [TestMethod]
        public void TestOrderedAddresses()
        {
            CsvFileProcessor.Process();

            const string resultedFile = @"C:\\ExportedOrderedAddresses.txt";
            const string expectedFile = @"c:\Projects\YouiCodingEx\YouiCodingEx.Test\ExpectedOrderedAddresses.txt";


            var resultedFileHashed = GetFileHash(resultedFile);
            var expectedFileHashed = GetFileHash(expectedFile);

            Assert.AreEqual(expectedFileHashed, resultedFileHashed);
        }


    }
}
