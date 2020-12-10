using DBSBankAPIs;
using DBSBankComman.Utilities;
using DBSBankManager;
using DBSBankRepo;
using DBSBankRepo.IRepo;
using DBSBankRepo.prettyGoodPrivacy;
using DBSBankRepo.RepoImplementation;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PgpCore;
using Serilog.Events;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;

namespace ApiCalls
{
   public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                //var result = _Manager.DBSStatus();
                Console.WriteLine("hello");
                pushAccordingToScheduler abc = new pushAccordingToScheduler();
                var result = abc.DBSStatus();
                // var result1 = abc.docread();
                // string message;

                if (!result.Equals(null))
                {
                    int i = 0;
                    classJsonConverter json = new classJsonConverter();
                    if (!result.Equals(null))
                    {
                        var jsons = json.serialJson(result);
                        Console.WriteLine(jsons);
                        i++;
                    }

                    Encription.EncryptFile(@"D:\pgpOperation\FINAL\OUTPUT.pgp", @"D:\pgpOperation\FINAL\JsonData.txt", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_public.asc", true, true);
                    // Pgp.DecryptFile(@"D:\pgpOperation\FINAL\OUTPUT.pgp", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_SECRET.asc", "IBSFINTECH".ToCharArray(), @"D:\pgpOperation\FINAL\default.txt");
                    // string readText1 = File.ReadAllText(@"D:\pgpOperation\FINAL\default.txt");
                    //   Console.WriteLine(readText1);


                   using (PGP pgp = new PGP())
                    {
                        // Decrypt file
                        pgp.DecryptFile(@"D:\pgpOperation\FINAL\OUTPUT.pgp", @"D:\pgpOperation\FINAL\default.txt", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_SECRET.asc", "IBSFINTECH");
                    }
                    string readText = File.ReadAllText(@"D:\pgpOperation\FINAL\OUTPUT.pgp");

                    var data = new StringContent(readText);
                    classHttpsRequest classHttps = new classHttpsRequest();
                    await classHttps.RequestAsync(data);
                }
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "Programmer", "Main method", exception, string.Empty);
                throw exception;
            }       
        }       
    }
}
