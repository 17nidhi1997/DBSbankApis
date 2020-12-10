using DBSBankComman.Model;
using DBSBankComman.Querie;
using DBSBankComman.Utilities;
using DBSBankRepo.IRepo;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankRepo.RepoImplementation
{
    public class repoPushAdvice : IRepoPA
    {
        private readonly IConfiguration configuration;
        public repoPushAdvice(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object pushAdvice_responce(pushAdvice push_Advice)
        {
            try
            {
                var commandText = Queries.locpush;
                using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
                using (OracleCommand cmd = new OracleCommand(commandText, _db))
                {

                    cmd.Connection = _db;
                    cmd.Parameters.Add("msgId", push_Advice.msgId);
                    cmd.Parameters.Add("orgId", push_Advice.orgId);
                    cmd.Parameters.Add("timeStamp", push_Advice.timeStamp);
                    cmd.Parameters.Add("channelId", push_Advice.channelId);
                    cmd.Parameters.Add("ctry", push_Advice.ctry);
                    cmd.Parameters.Add("noOfDocAttached", push_Advice.documentDescription);
                    cmd.Parameters.Add("txnType", push_Advice.documentName);
                    cmd.Parameters.Add("accountNumber", push_Advice.customerReference);
                    cmd.Parameters.Add("ccy", push_Advice.bankReference);
                    cmd.Parameters.Add("billCategory", push_Advice.encodedFile);                    
                    _db.Open();
                    cmd.ExecuteNonQuery();
                    _db.Close();
                    return push_Advice.msgId + " = DBSS_LC_CODE is sucessfull added";
                }
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "repoTradeLcAck", "ACKTradeLc", exception, "INVALID_INPUT:Error occure while inserting data to DB");
                throw exception;
            }
        }
    }
}
