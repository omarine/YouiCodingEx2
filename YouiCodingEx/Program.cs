
using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace YouiCodingEx
{
    class Program
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            var csvFileProcessor = new CsvFileProcessor();
            try
            {
                
                csvFileProcessor.Process();
                Log.Info("the operation ended with sucess");
            }
            catch (Exception ex)
            {
                Log.FatalFormat("the operation ended with the following error : ", ex.Message);

            }

            Console.WriteLine("please hit any Key to end the operation !");
            Console.ReadLine();




        }

    }
}
