using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YouiCodingEx
{
    public class CsvFileProcessor
    {
        private const string outputPathNamesOrdered = @"C:\\ExportedOrderedNames.txt";
        private const string inputPath = @"C:\\data.csv";
        private const string outPutPathAddressesOrdered = @"C:\\ExportedOrderedAddresses.txt";

        public List<People> People { get; set; }
        public List<Address> Addresses { get; set; }





        public CsvFileProcessor()
        {
            People = new List<People>();
            Addresses = new List<Address>();

        }

        public void Process()
        {

            var success = ParseCsvFile();
            if (!success) return;
            ExportOrderedNames();
            ExportOrderedAddresses();
        }

        private bool ParseCsvFile()
        {

            var success = true;

            using (var parser = new TextFieldParser(inputPath))
            {
                parser.SetDelimiters(new string[] { "," });

                parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (fields != null && fields.Any())
                    {
                        People.Add(new People(fields[0], fields[1]));

                        var strNumber = TextTool.GetStreetNumber(fields[2]);
                        var strName = TextTool.GetStreetName(fields[2]);

                        Addresses.Add(new Address(strNumber, strName));
                    }
                    else
                    {
                        success = false;
                    }

                }

            }

            return success;
        }

        private void ExportOrderedNames()
        {
            foreach (var p in People)
            {
                p.FirstNameFrequency = TextTool.CountStringOccurrences(p.FirstName, People.Select(x => x.FirstName).ToList());
                p.LastNameFrequency = TextTool.CountStringOccurrences(p.LastName, People.Select(x => x.LastName).ToList());

            }

            var orderedNames =
                People.OrderByDescending(o => o.FirstNameFrequency)
                    .ThenBy(o => o.FirstName)
                    .ThenByDescending(o => o.LastNameFrequency)
                    .ThenBy(o => o.LastName)
                    .ToList();


            using (var tw = new StreamWriter(outputPathNamesOrdered))
            {
                foreach (var op in orderedNames)
                {
                    tw.WriteLine(op.Output);

                }
            }
        }

        private void ExportOrderedAddresses()
        {
            var orderedAddresses = Addresses.OrderBy(a => a.StreetName).ToList();

            using (TextWriter tw = new StreamWriter(outPutPathAddressesOrdered))
            {
                foreach (var oa in orderedAddresses)
                {
                    tw.WriteLine(oa.OutPut);

                }
            }
        }





    }
}
