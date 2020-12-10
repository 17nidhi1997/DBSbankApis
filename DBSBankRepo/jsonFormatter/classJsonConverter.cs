using DBSBankComman.Model;
using DBSBankComman.Utilities;
using Newtonsoft.Json;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBSBankRepo
{
    public class classJsonConverter
    {
        public object serialJson(object result)
        {
            try
            {
                var json = JsonConvert.SerializeObject(result);
                System.IO.File.WriteAllText(@"D:\pgpOperation\FINAL\JsonData.txt", json);
                return json;
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classJsonConverter", "serialJson", exception, "Error occure while Serializing data");
                throw exception;
            }

        }

        public object deSerialJson(string filePath)
        {
            try
            {
                List<locModel> ack = new List<locModel>();
                string json = File.ReadAllText(filePath);
                ack = JsonConvert.DeserializeObject<List<locModel>>(json);
                return ack;
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classJsonConverter", "deSerialJson", exception, "Error occure while Deserializing data");
                throw exception;
            }
        }

        public object deSerialTradeLc(TradeLC_ack text)
        {
            try
            {                      
                TradeLC_ack obj = JsonConvert.DeserializeObject<TradeLC_ack>(text);
                return obj;
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classJsonConverter", "deSerialTradeLc", exception, "Error occure while Deserializing data");
                throw exception;
            }
        }
    }
}
