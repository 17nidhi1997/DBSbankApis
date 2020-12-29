
using DBSBankComman.Model;
using DBSBankComman.Utilities;
using DBSBankRepo;
using DBSBankRepo.RepoImplementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PgpCore;
using Serilog;
using Serilog.Events;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;

namespace ApiCalls
{
    //this is the 214 program
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();

                Log.Logger = new LoggerConfiguration().
                    MinimumLevel.Debug()
                    .WriteTo.File("D:\\NIDHI\\LOGFILE\\LogFile.txt")
                    .CreateLogger();

                Log.Write(LogEventLevel.Information, "Testing Log File");
                LogCreate.LogWrite(LogEventLevel.Information, "ApiCall.Programs", "Program.Main", null, "The process has been started");

                pushAccordingToScheduler pushAccording = new pushAccordingToScheduler();
                classHttpsRequest classHttps = new classHttpsRequest();
                classJsonConverter json = new classJsonConverter();
                //var result = pushAccording.DBSStatus();

                //if (!result.Equals(null))
                //{
                //    ////***********************************************************part one************************************
                //int i = 0;

                //if (!result.Equals(null))
                //{
                //    var jsons = json.serialJson(result);
                //    Console.WriteLine(jsons);
                //    i++;
                //}
                //using (PGP pgp = new PGP())
                //{
                //    // Encrypt file and sign
                //    pgp.HashAlgorithmTag = Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha256;
                //    pgp.CompressionAlgorithm = Org.BouncyCastle.Bcpg.CompressionAlgorithmTag.Zip;
                //    pgp.SymmetricKeyAlgorithm = Org.BouncyCastle.Bcpg.SymmetricKeyAlgorithmTag.Aes256;
                //    pgp.EncryptFileAndSign(ConfigurationManager.AppSettings["JsonData"], ConfigurationManager.AppSettings["Output"], ConfigurationManager.AppSettings["DBS_Public_Key"], ConfigurationManager.AppSettings["IBS_Private_Key"], ConfigurationManager.AppSettings["IBS_PASS"], true, true);
                //}

                //string readText = File.ReadAllText(ConfigurationManager.AppSettings["Output"]);
                //var data = new StringContent(readText );
                //LogCreate.LogWrite(LogEventLevel.Information, "ApiCall.Programs", "Program.Main", null, "bofer The process has been started for http request");

                //Console.WriteLine("before");
                //var ack1_2_Result = await classHttps.RequestAsync(readText);
                //LogCreate.LogWrite(LogEventLevel.Information, "ApiCall.Programs", "Program.Main", null, "TThe HTTPS request after1");
                //System.IO.File.WriteAllText(@"D:\NIDHI\pgpOperation\newData.pgp", (string)ack1_2_Result);
                //Console.WriteLine(ack1_2_Result);
                //using (PGP pgp = new PGP())
                //{
                //    // Decrypt file and verify

                //    pgp.DecryptFile(@"D:\NIDHI\pgpOperation\newData.pgp", @"D:\NIDHI\pgpOperation\decryptedAndVerified.txt", ConfigurationManager.AppSettings["IBS_Private_Key"], ConfigurationManager.AppSettings["IBS_PASS"]);
                //    //  pgp.VerifyFile()
                //}

                ////******************************************************* part2 ***********************************************

                TradeLC_ack tradeLC_Ack = new TradeLC_ack();
                    string readText1 = File.ReadAllText(@"D:\NIDHI\pgpOperation\decryptedAndVerified.txt");
                    TradeLC_ack obj = JsonConvert.DeserializeObject<TradeLC_ack>(readText1);
                    var docfile = pushAccording.ACK1_2_TradeLc(obj);
                    Console.WriteLine(docfile);

                    if (!docfile.Equals(null))
                    {
                        Console.WriteLine(docfile);
                        Console.WriteLine("before docfile");
                        var Json = json.serialJson(docfile);
                        Console.WriteLine(Json);

                        using (PGP pgp = new PGP())
                        {
                            // Encrypt file and sign
                            pgp.HashAlgorithmTag = Org.BouncyCastle.Bcpg.HashAlgorithmTag.Sha256;
                            pgp.CompressionAlgorithm = Org.BouncyCastle.Bcpg.CompressionAlgorithmTag.Zip;
                            pgp.SymmetricKeyAlgorithm = Org.BouncyCastle.Bcpg.SymmetricKeyAlgorithmTag.Aes256;
                            pgp.EncryptFileAndSign(ConfigurationManager.AppSettings["JsonData"], ConfigurationManager.AppSettings["Output1"], ConfigurationManager.AppSettings["DBS_Public_Key"], ConfigurationManager.AppSettings["IBS_Private_Key"], ConfigurationManager.AppSettings["IBS_PASS"], true, true);
                        }

                        string readText2 = File.ReadAllText(ConfigurationManager.AppSettings["Output1"]);
                        var data1 = new StringContent(readText2);
                        LogCreate.LogWrite(LogEventLevel.Information, "ApiCall.Programs", "Program.Main", null, "bofer The process has been started for http request");

                        Console.WriteLine("before");
                        var ack1_2_Result1 = await classHttps.RequestAsync1(readText2);
                        LogCreate.LogWrite(LogEventLevel.Information, "ApiCall.Programs", "Program.Main", null, "TThe HTTPS request after1");
                        System.IO.File.WriteAllText(@"D:\NIDHI\pgpOperation\newData1.txt", (string)ack1_2_Result1);
                        Console.WriteLine(ack1_2_Result1);
                        using (PGP pgp = new PGP())
                        {
                            // Decrypt file and verify

                            pgp.DecryptFile(@"D:\NIDHI\pgpOperation\newData1.txt", @"D:\NIDHI\pgpOperation\decryptedAndVerified1.txt", ConfigurationManager.AppSettings["IBS_Private_Key"], ConfigurationManager.AppSettings["IBS_PASS"]);
                            //  pgp.VerifyFile()
                        }

                    }
                    
               //}
            }

            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "Program", "Main method", exception, string.Empty);
               
            }
        }
    }
}
        