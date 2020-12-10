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
    public class repoTradeIBLC_ACK: IRepoIBLC
    {
        private readonly IConfiguration configuration;
        public repoTradeIBLC_ACK(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object ACKTradeIBLC(TradeIBLCcs IBLC)
        {
            try
            {
                var commandText = Queries.locpush;
                using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
                using (OracleCommand cmd = new OracleCommand(commandText, _db))
                {

                    cmd.Connection = _db;
                    cmd.Parameters.Add("msgId", IBLC.msgId);
                    cmd.Parameters.Add("orgId", IBLC.orgId);
                    cmd.Parameters.Add("timeStamp", IBLC.timeStamp);
                    cmd.Parameters.Add("channelId", IBLC.channelId);
                    cmd.Parameters.Add("ctry", IBLC.ctry);
                    cmd.Parameters.Add("noOfDocAttached", IBLC.noOfDocAttached);
                    cmd.Parameters.Add("txnType", IBLC.txnType);
                    cmd.Parameters.Add("accountNumber", IBLC.accountNumber);
                    cmd.Parameters.Add("ccy", IBLC.ccy);
                    cmd.Parameters.Add("billCategory", IBLC.billCategory);
                    cmd.Parameters.Add("bankReference", IBLC.bankReference);
                    cmd.Parameters.Add("customerReference", IBLC.customerReference);
                    cmd.Parameters.Add("discrepancy", IBLC.discrepancy);
                    cmd.Parameters.Add("billCcy", IBLC.billCcy);
                    cmd.Parameters.Add("billAmount", IBLC.billAmount);
                    cmd.Parameters.Add("billOutstandingAmount", IBLC.billOutstandingAmount);
                    cmd.Parameters.Add("response", IBLC.response);
                    cmd.Parameters.Add("conditions", IBLC.conditions);
                    cmd.Parameters.Add("importBillRef", IBLC.importBillRef);
                    cmd.Parameters.Add("settlementOptions", IBLC.settlementOptions);
                    cmd.Parameters.Add("settlementAccountNoCcy", IBLC.settlementAccountNoCcy);
                    cmd.Parameters.Add("settlementAmt", IBLC.settlementAmt);
                    cmd.Parameters.Add("settlementBoardRateAmt", IBLC.settlementBoardRateAmt);
                    cmd.Parameters.Add("settlementForwardContractNumber", IBLC.settlementForwardContractNumber);
                    cmd.Parameters.Add("settlementForwardContractAmtUse", IBLC.settlementForwardContractAmtUse);
                    cmd.Parameters.Add("amtToFinance", IBLC.amtToFinance);
                    cmd.Parameters.Add("financingCcy", IBLC.financingCcy);
                    cmd.Parameters.Add("financePeriod", IBLC.financePeriod);
                    cmd.Parameters.Add("financeBoardRateAmt", IBLC.financeBoardRateAmt);
                    cmd.Parameters.Add("financingForwardContractNumber", IBLC.financingForwardContractNumber);
                    cmd.Parameters.Add("financingForwardContractAmtUse", IBLC.financingForwardContractAmtUse);
                    cmd.Parameters.Add("accountNumberCcy", IBLC.accountNumberCcy);
                    cmd.Parameters.Add("contactPerson", IBLC.contactPerson);
                    cmd.Parameters.Add("contactNumber", IBLC.contactNumber);
                    cmd.Parameters.Add("specialInstructions", IBLC.specialInstructions);
                    cmd.Parameters.Add("typeOfDocument", IBLC.typeOfDocument);
                    cmd.Parameters.Add("noOfSets", IBLC.noOfSets);
                    cmd.Parameters.Add("noOfOriginal", IBLC.noOfOriginal);
                    cmd.Parameters.Add("noOfCopies", IBLC.noOfCopies);
                    _db.Open();
                    cmd.ExecuteNonQuery();
                    _db.Close();

                    return IBLC.msgId + " = DBSS_LC_CODE is sucessfull added";
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
