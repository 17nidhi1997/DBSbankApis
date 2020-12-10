using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBSBankComman.Model;
using DBSBankComman.Utilities;
using DBSBankManager;
using DBSBankRepo;
using DBSBankRepo.prettyGoodPrivacy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PgpCore;
using Serilog.Events;

namespace DBSBankAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeLC_ACK3A_3BController : ControllerBase
    {
        public IManagerLC_ACK _Manager;

        public TradeLC_ACK3A_3BController(IManagerLC_ACK manager)
        {
            this._Manager = manager;
        }
        //FileStreamResult fileStreamResult
        [HttpPost]
        public  IAsyncResult ack_LC([FromBody] string httpContent)
        {
            try
            {               
                Decription decription = new Decription();
                var plaintext= decription.decriptFiles(httpContent);
                classJsonConverter json = new classJsonConverter();
                TradeLC_ack obj = (TradeLC_ack)json.deSerialTradeLc((TradeLC_ack)plaintext);
                var result = this._Manager.ACKTradeLc(obj);

                //string readText1 = System.IO.File.WriteAllTextAsync(fileStream);
                // string text = System.IO.File.ReadAllText(path);
                //using (PGP pgp = new PGP())
                //{
                //    // Decrypt file
                //    pgp.DecryptFile(httpContent, @"D:\pgpOperation\FINAL\default1.txt", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_SECRET.asc", "IBSFINTECH");
                //}

                //classJsonConverter json = new classJsonConverter();
                //string JSONPATHS = @"D:\pgpOperation\FINAL\default1.txt";
                //TradeLC_ack obj= (TradeLC_ack)json.deSerialTradeLc((TradeLC_ack)plaintext);

                // StreamReader streamReader = System.IO.File.OpenText(@"D:\pgpOperation\FINAL\default1.txt");
                //string text = streamReader.ReadToEnd();
                // TradeLC_ack obj = (TradeLC_ack)json.deSerialTradeLc(text);
                //List<locModel> locModels = new List<locModel>();
                //  List<locModel> obj = JsonConvert.DeserializeObject<List<locModel>>(text);
                // var obj = JsonConvert.DeserializeObject<List<locModel>>(text);
                //TradeLC_ack obj = JsonConvert.DeserializeObject<TradeLC_ack>(text);

                //foreach (var LC in obj)
                //{
                //var result = this._Manager.ACKTradeLc(obj);
                //var jsons = json.deSerialJson(JSONPATHS);

                // locModel obj = JsonConvert.DeserializeObject<locModel>(text);

                string message;
                // var result = this._Manager.ACKTradeLc(obj);

                message = "ouput";
                return (IAsyncResult)this.Ok(new { message });
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "TradeLC_ACK3A_3BController", "Getack", exception, string.Empty);
                throw exception;
            }
        }
    }
}
