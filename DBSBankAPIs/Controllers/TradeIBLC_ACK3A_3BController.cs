﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBSBankComman.Model;
using DBSBankComman.Utilities;
using DBSBankManager;
using DBSBankManager.Manage;
using DBSBankRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PgpCore;
using Serilog.Events;

namespace DBSBankAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeIBLC_ACK3A_3BController : ControllerBase
    {
        public IManagerIBLC_ACK _Manager;
        public TradeIBLC_ACK3A_3BController(IManagerIBLC_ACK manager)
        {
            this._Manager = manager;
        }

        [HttpPost]
        public IActionResult ack_IBLC(string path)
        {
            try
            {
                using (PGP pgp = new PGP())
                {
                    pgp.DecryptFile(path, @"D:\pgpOperation\FINAL\default1.txt", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_SECRET.asc", "IBSFINTECH");
                }
                classJsonConverter json = new classJsonConverter();
                string JSONPATHS = @"D:\pgpOperation\FINAL\default1.txt";
                StreamReader streamReader = System.IO.File.OpenText(@"D:\pgpOperation\FINAL\default1.txt");
                string text = streamReader.ReadToEnd();               
                List<TradeIBLCcs> obj = JsonConvert.DeserializeObject<List<TradeIBLCcs>>(text);               
                foreach (var IBLC in obj)
                {
                    var result = this._Manager.ACKTradeIBLC(IBLC);
                }
                var jsons = json.deSerialJson(JSONPATHS);
                string message;
                message = "ouput";
                return this.Ok(new { message });
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "TradeIBLC_ACK3A_3BController", "getack", exception, string.Empty);
                throw exception;
            }
        }
    }
}

