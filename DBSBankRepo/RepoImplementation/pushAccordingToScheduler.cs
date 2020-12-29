using DBSBankComman;
using DBSBankComman.Model;
using DBSBankComman.Model.Doc;
using DBSBankComman.Model.TradeLc;
using DBSBankComman.Querie;
using DBSBankComman.Utilities;
//using DBSBankComman.Utilities;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DBSBankRepo.RepoImplementation
{
    public class pushAccordingToScheduler
    {

        //localhost
        public Object DBSStatus()
        {
            try
            {
                locModel dBS = new locModel();
                List<locModel> list = new List<locModel>();
                var commandText = Queries.locget;
                using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                using (OracleCommand cmd = new OracleCommand(commandText, _db))
                {
                    cmd.Connection = _db;
                    cmd.CommandType = CommandType.Text;
                    _db.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // locModel dBS = new locModel();
                        locModel1 header = new locModel1();
                        locModel2 txnInfo = new locModel2();
                        locModel3 partiesInfo = new locModel3();
                        locModel4 txnDetails = new locModel4();
                        locModel5 shipmentDetails = new locModel5();
                        locModel6 transportDocsDetails = new locModel6();
                        locModel7 documentsDetails = new locModel7();
                        locModel8 instructionsDetails = new locModel8();
                        locModel9 additionalDocuments = new locModel9();


                        dBS.header = header;
                        dBS.txnInfo = txnInfo;
                        dBS.txnInfo.partiesInfo = partiesInfo;
                        dBS.txnInfo.txnDetails = txnDetails;

                        //dBS.txnInfo = txnInfo;

                        dBS.txnInfo.shipmentDetails = shipmentDetails;

                        dBS.txnInfo.transportDocsDetails = new List<locModel6>();
                        dBS.txnInfo.transportDocsDetails.Add(transportDocsDetails);


                        dBS.txnInfo.documentsDetails = documentsDetails;
                        dBS.txnInfo.instructionsDetails = instructionsDetails;

                        dBS.txnInfo.additionalDocuments = new List<locModel9>();
                        dBS.txnInfo.additionalDocuments.Add(additionalDocuments);
                        // DataTable dt = ((DataTable)(reader.g));

                        // DataTableReader dr= 
                        dBS.header.msgId = reader["msgId"].ToString();
                        dBS.header.orgId = reader["rgId"].ToString();
                        dBS.header.timeStamp = reader["TimeStamp"].ToString();
                        dBS.header.channelId = reader["channelId"].ToString();
                        dBS.header.ctry = reader["ctry"].ToString();
                        dBS.header.noOfDocAttached = reader["noOfDocAttached"].ToString();

                        dBS.txnInfo.txnType = reader["txnType"].ToString();
                        dBS.txnInfo.accountNumber = reader["accountNumber"].ToString();
                        dBS.txnInfo.ccy = reader["ccy"].ToString();
                        // reader["Disabled"].ToString()
                        dBS.txnInfo.partiesInfo.customerReference = reader.IsDBNull(9) ? "" : reader["customerReference"].ToString();
                        dBS.txnInfo.partiesInfo.applicantContactName = reader.IsDBNull(10) ? "" : reader["applicantContactName"].ToString();
                        dBS.txnInfo.partiesInfo.applicantContactNumber = reader.IsDBNull(11) ? "0" : reader["applicantContactNumber"].ToString();
                        dBS.txnInfo.partiesInfo.thirdPartyName = reader.IsDBNull(12) ? "" : reader["thirdPartyName"].ToString();
                        dBS.txnInfo.partiesInfo.thirdPartyAddress = reader.IsDBNull(13) ? "" : reader["thirdPartyAddress"].ToString();
                        dBS.txnInfo.partiesInfo.beneName = reader.IsDBNull(14) ? "" : reader["beneName"].ToString();
                        dBS.txnInfo.partiesInfo.beneAddress = reader.IsDBNull(15) ? "" : reader["beneAddress"].ToString();
                        dBS.txnInfo.partiesInfo.beneCountry = reader.IsDBNull(16) ? "" : reader["beneCountry"].ToString();
                        dBS.txnInfo.partiesInfo.beneContactName = reader.IsDBNull(17) ? "" : reader["beneContactName"].ToString();
                        dBS.txnInfo.partiesInfo.beneContactNumber = reader.IsDBNull(18) ? "" : reader["beneContactNumber"].ToString();
                        //Int64.Parse(reader.GetValue(18).ToString());
                        // dBS.txnInfo.partiesInfo.beneContactNumber = reader.IsDBNull(18) ? 1 : reader.GetInt32(18);
                        //  (reader["beneContactNumber"] != DBNull.Value) ? int.Parse(reader["beneContactNumber"].ToString()) : (int?)null;
                        dBS.txnInfo.partiesInfo.advisingBank = reader.IsDBNull(19) ? "" : reader["advisingBank"].ToString();
                        dBS.txnInfo.partiesInfo.advisingBankAddress = reader.IsDBNull(20) ? "" : reader["advisingBankAddress"].ToString();
                        dBS.txnInfo.partiesInfo.advisingBankSwiftCode = reader.IsDBNull(21) ? "" : reader["beneContactNumber"].ToString();

                        dBS.txnInfo.txnDetails.sendVia = reader.IsDBNull(22) ? "" : reader["sendVia"].ToString();
                        dBS.txnInfo.txnDetails.expiryDate = reader.IsDBNull(23) ? "" : reader["expiryDate"].ToString();
                        dBS.txnInfo.txnDetails.expiryCountry = reader.IsDBNull(24) ? "" : reader["expiryCountry"].ToString();
                        
                        dBS.txnInfo.txnDetails.lcType = reader.IsDBNull(25) ? "0" : reader["lcType"].ToString();
                        //if (!reader.IsDBNull(26))
                        //{
                        //    dBS.txnDetails.lcType = reader.GetString(26);
                        //}
                        dBS.txnInfo.txnDetails.lcCcy = reader.IsDBNull(26) ? "" : reader["lcCcy"].ToString();
                        dBS.txnInfo.txnDetails.expiryPlace = reader.IsDBNull(27) ? "" : reader["expiryPlace"].ToString();
                        dBS.txnInfo.txnDetails.lcAmount = reader.IsDBNull(28) ? "0" : reader["lcAmount"].ToString();
                        
                        dBS.txnInfo.txnDetails.localLcAmtIs = reader.IsDBNull(29) ? "" : reader["localLcAmtIs"].ToString();
                        dBS.txnInfo.txnDetails.tolCrAmtGoodsQuanPlus = reader.IsDBNull(30) ? "0" : reader["tolCrAmtGoodsQuanPlus"].ToString();
                        //dBS.txnDetails.tolCrAmtGoodsQuanPlus = reader.IsDBNull(30) ? 0 : reader.GetInt32(30);
                        dBS.txnInfo.txnDetails.tolCrAmtGoodsQuanMinus = reader.IsDBNull(31) ? "0" : reader["tolCrAmtGoodsQuanMinus"].ToString();
                        dBS.txnInfo.txnDetails.creditAvailableWith = reader.IsDBNull(32) ? "0" : reader["creditAvailableWith"].ToString();
                        dBS.txnInfo.txnDetails.creditAvailableWithOthersName = reader.IsDBNull(33) ? "" : reader["creditAvailableWithOthersName"].ToString();
                        dBS.txnInfo.txnDetails.creditAvailableWithOthersAddress = reader.IsDBNull(34) ? "" : reader["creditAvailableWithOthersAdd"].ToString();
                        dBS.txnInfo.txnDetails.creditAvailableBy = reader.IsDBNull(35) ? "0" : reader["creditAvailableBy"].ToString();
                        dBS.txnInfo.txnDetails.draftDrawnOn = reader.IsDBNull(36) ? "0" : reader["creditAvailableBy"].ToString();
                        dBS.txnInfo.txnDetails.tenor = reader.IsDBNull(37) ? "" : reader["tenor"].ToString();
                        dBS.txnInfo.txnDetails.tenorDays = reader.IsDBNull(38) ? "0" : reader["tenorDays"].ToString();
                        dBS.txnInfo.txnDetails.tenorPhrase = reader.IsDBNull(39) ? "" : reader["tenorPhrase"].ToString();
                        dBS.txnInfo.txnDetails.tenorPhraseOthers = reader.IsDBNull(40) ? "" : reader["tenorPhraseOthers"].ToString();
                        dBS.txnInfo.txnDetails.tenorPhraseFxdMat = reader.IsDBNull(41) ? "" : reader["tenorPhraseFxdMat"].ToString(); ;
                        dBS.txnInfo.txnDetails.paymentDetails = reader.IsDBNull(42) ? "" : reader["paymentDetails"].ToString();
                        dBS.txnInfo.txnDetails.creditTransferable = reader.IsDBNull(43) ? "" : reader["creditTransferable"].ToString();
                        dBS.txnInfo.txnDetails.confirmationRequired = reader.IsDBNull(44) ? "" : reader["confirmationRequired"].ToString();
                        dBS.txnInfo.txnDetails.confirmationCharges = reader.IsDBNull(45) ? "" : reader["confirmationCharges"].ToString();
                        dBS.txnInfo.txnDetails.confirmingBank = reader.IsDBNull(46) ? "" : reader["confirmingBank"].ToString();
                        dBS.txnInfo.txnDetails.confirmingBankAddress = reader.IsDBNull(47) ? "" : reader["confirmingBankAddress"].ToString();

                        dBS.txnInfo.shipmentDetails.goodsDescription = reader.IsDBNull(48) ? "" : reader["goodsDescription"].ToString();
                        dBS.txnInfo.shipmentDetails.placeOfReceipt = reader.IsDBNull(49) ? "" : reader["placeOfReceipt"].ToString();
                        dBS.txnInfo.shipmentDetails.portOfLoading = reader.IsDBNull(50) ? "" : reader["portOfLoading"].ToString();
                        dBS.txnInfo.shipmentDetails.portOfDischarge = reader.IsDBNull(51) ? "" : reader["portOfDischarge"].ToString();
                        dBS.txnInfo.shipmentDetails.placeOfDelivery = reader.IsDBNull(52) ? "" : reader["placeOfDelivery"].ToString();
                        dBS.txnInfo.shipmentDetails.partialShipmentAllowed = reader.IsDBNull(53) ? "" : reader["partialShipmentAllowed"].ToString();
                        dBS.txnInfo.shipmentDetails.transhipmentAllowed = reader.IsDBNull(54) ? "" : reader["transhipmentAllowed"].ToString();
                        dBS.txnInfo.shipmentDetails.latestShipmentDate = reader.IsDBNull(55) ? "" : reader["latestShipmentDate"].ToString();
                        dBS.txnInfo.shipmentDetails.shipmentPeriod = reader.IsDBNull(56) ? "" : reader["shipmentPeriod"].ToString();
                        dBS.txnInfo.shipmentDetails.presentationPeriod = reader.IsDBNull(57) ? "0" : reader["presentationPeriod"].ToString();
                        dBS.txnInfo.shipmentDetails.presentationPeriodFrom = reader.IsDBNull(58) ? "" : reader["presentationPeriodFrom"].ToString();
                        dBS.txnInfo.shipmentDetails.presentationPeriodOth = reader.IsDBNull(59) ? "" : reader["presentationPeriodOth"].ToString();
                        dBS.txnInfo.shipmentDetails.shippingTerms = reader.IsDBNull(60) ? "" : reader["shippingTerms"].ToString();
                        dBS.txnInfo.shipmentDetails.insuranceBy = reader.IsDBNull(61) ? "" : reader["insuranceBy"].ToString();
                        dBS.txnInfo.shipmentDetails.buyerInsuranceDetails = reader.IsDBNull(62) ? "" : reader["buyerInsuranceDetails"].ToString();
                        dBS.txnInfo.shipmentDetails.coverNoteDetails = reader.IsDBNull(63) ? "" : reader["buyerInsuranceDetails"].ToString();

                        dBS.txnInfo.transportDocsDetails[0].transportDocType = reader.IsDBNull(64) ? "" : reader["transportDocType"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].freight = reader.IsDBNull(65) ? "" : reader["freight"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].freightOthers = reader.IsDBNull(66) ? "" : reader["freightOthers"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].totalOriginals = reader.IsDBNull(67) ? "0 " : reader["totalOriginals"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].originalsRequired = reader.IsDBNull(68) ? "0" : reader["originalsRequired"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].copiesRequired = reader.IsDBNull(69) ? "0" : reader["copiesRequired"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].consignedTo = reader.IsDBNull(70) ? "0" : reader["consignedTo"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].consignedToOthers = reader.IsDBNull(71) ? "" : reader["consignedToOthers"].ToString();
                        dBS.txnInfo.transportDocsDetails[0].notifyParty = reader.IsDBNull(72) ? "" : reader["notifyParty"].ToString();


                        dBS.txnInfo.documentsDetails.docRequired = reader.IsDBNull(73) ? "" : reader["docRequired"].ToString();
                        dBS.txnInfo.documentsDetails.insuranceDocs = reader.IsDBNull(74) ? "" : reader["insuranceDocs"].ToString();
                        dBS.txnInfo.documentsDetails.additionalConditions = reader.IsDBNull(75) ? "" : reader["additionalConditions"].ToString();
                        dBS.txnInfo.documentsDetails.specialConditionBene = reader.IsDBNull(76) ? "" : reader["specialConditionBene"].ToString();
                        dBS.txnInfo.documentsDetails.specialConditionAdv = reader.IsDBNull(77) ? "" : reader["specialConditionAdv"].ToString();

                        dBS.txnInfo.instructionsDetails.charges = reader.IsDBNull(78) ? "" : reader["charges"].ToString();
                        dBS.txnInfo.instructionsDetails.chargesAccountNo = reader.IsDBNull(79) ? "" : reader["chargesAccountNo"].ToString();
                        dBS.txnInfo.instructionsDetails.chargesOthers = reader.IsDBNull(80) ? "" : reader["chargesOthers"].ToString();
                        dBS.txnInfo.instructionsDetails.specialInstruction = reader.IsDBNull(81) ? "" : reader["specialInstruction"].ToString();
                        dBS.txnInfo.instructionsDetails.financeRequired = reader.IsDBNull(82) ? "" : reader["financeRequired"].ToString();
                        dBS.txnInfo.instructionsDetails.financeCurrency = reader.IsDBNull(83) ? "" : reader["financeCurrency"].ToString();
                        dBS.txnInfo.instructionsDetails.forwardContractNumber = reader.IsDBNull(84) ? "" : reader["forwardContractNumber"].ToString();
                        dBS.txnInfo.instructionsDetails.chargesAccountCcy = reader.IsDBNull(85) ? "" : reader["chargesAccountCcy"].ToString();
                        dBS.txnInfo.additionalDocuments[0].typeOfDocument = reader.IsDBNull(86) ? "" : reader["typeOfDocument"].ToString();
                        dBS.txnInfo.additionalDocuments[0].noOfSets = reader.IsDBNull(87) ? "0" : reader["noOfSets"].ToString();
                        dBS.txnInfo.additionalDocuments[0].noOfOriginal = reader.IsDBNull(88) ? "0" : reader["noOfOriginal"].ToString();

                        dBS.txnInfo.additionalDocuments[0].noOfCopies = reader.IsDBNull(89) ? "0" : reader["noOfCopies"].ToString();
                        list.Add(dBS);
                    }
                    _db.Close();
                    var commandText1 = Queries.UpdateLCQuery + dBS.header.msgId + "";
                    using (OracleCommand cmd1 = new OracleCommand(commandText1, _db))
                    {
                        cmd1.Connection = _db;
                        _db.Open();
                        cmd1.CommandType = CommandType.Text;
                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd1.Parameters.Add("PROCESSSTATUS", "12400001");
                        cmd1.ExecuteNonQueryAsync();
                        txn.Commit();
                        _db.Close();
                    }
                    return dBS;
                }
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "pushAccordingToScheduler", "DBSStatus", exception, "NULL_EXCEPTION:Requested data not found");
                throw exception;
            }
        }









        //***********************************************************************************************************




        //-------------------------------------------------------for ACK1, ACK2-----------------------------------------
        /// <summary>
        /// ACK1---------Failed Response
        /// ACK1---------Failed Response (from API Gateway)
        /// ACK2A--------Success Response
        /// ACK2A--------Reject Response
        /// ACK2A--------Success Response (Exceed cutoff time)
        /// </summary>
        /// <param name="LC_ack"></param>
        /// <returns></returns>
        public object ACK1_2_TradeLc(TradeLC_ack LC_ack)
        {
            try
            {
                TradeLC_ack tradeLC_Ack = new TradeLC_ack();
                TradeLC_ack1 tradeLC_Ack1 = new TradeLC_ack1();
                TradeLC_ack2 tradeLC_Ack2 = new TradeLC_ack2();
                TradeLC_ack3 tradeLC_Ack3 = new TradeLC_ack3();

                tradeLC_Ack.header = tradeLC_Ack1;
                tradeLC_Ack.txnResponses = tradeLC_Ack2;
                tradeLC_Ack.error = tradeLC_Ack3;

                docFiles list1 = new docFiles();
                List<docFiles> list = new List<docFiles>();
                docFiles doc = new docFiles();
                docFiles1 header = new docFiles1();
                docFiles2 txnInfo = new docFiles2();
                docFiles3 documents = new docFiles3();
                doc.header = header;
                doc.txnInfo = txnInfo;
                doc.txnInfo.documents = new List<docFiles3>();
                doc.txnInfo.documents.Add(documents);
                //string ackRejectCode = LC_ack.error.status;
                //string code = "RJCT";
                //var commandText = "UPDATE BLUESTARTF_PROD.letterofcredit SET code=" + LC_ack.error.code + ",txnStatusDescription" + LC_ack.error.description + " where msgid = '" + LC_ack.header.msgId + "'";

                //////ACK1---------Failed Response (from API Gateway)
                //if (ackRejectCode.Equals(code))
                //{
                //    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                //    using (OracleCommand cmd = new OracleCommand(commandText, _db))
                //    {
                //        cmd.Connection = _db;
                //        _db.Open();
                //        cmd.CommandType = CommandType.Text;
                //        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                //        cmd.Parameters.Add("code", LC_ack.error.code);
                //        cmd.Parameters.Add("txnStatusDescription", LC_ack.error.description);
                //        cmd.ExecuteNonQuery();
                //        txn.Commit();
                //        _db.Close();
                //    }
                //}

                ////ACK1---------Failed Response

                string responseType = LC_ack.txnResponses.responseType;
                string AckType = "ACK1";
                string msgId1 = LC_ack.header.msgId;

                var commandText1 = Queries.LC_ACK1_failed + "'" + LC_ack.header.msgId + "'";
                // "UPDATE BLUESTARTF_PROD.letterofcredit SET responseType =:responseType ,txnStatus=:txnStatus ,txnStatusDescription =:txnStatusDescription WHERE msgId='20201222C7' ";
                //+ LC_ack.txnResponses.responseType + ",txnStatus=" + LC_ack.txnResponses.txnStatus + ",txnStatusDescription =" + LC_ack.txnResponses.txnStatusDescription + " where msgid = " + LC_ack.header.msgId + "";
                if (responseType.Equals(AckType))
                {
                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                    using (OracleCommand cmd1 = new OracleCommand(commandText1, _db))
                    {
                        cmd1.Connection = _db;
                        _db.Open();
                        cmd1.CommandType = CommandType.Text;
                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd1.BindByName = true;
                        cmd1.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
                        cmd1.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
                        cmd1.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
                        //cmd1.ExecuteScalar();
                        cmd1.ExecuteNonQuery();
                        txn.Commit();
                        _db.Close();
                        return "svhbaxcjnx ";
                    }

                }

                ////ACK2A AND ACK2C
                ////ACK2A AND ACK2C
                string Ack2Type = "RJCT";
                string txnStatus = LC_ack.txnResponses.txnStatus;
                string txncode = "ACK2C";
                if (txnStatus.Equals(Ack2Type) || responseType.Equals(txncode))
                {
                    var commandText2 = "UPDATE BLUESTARTF_PROD.letterofcredit SET responseType=" + LC_ack.txnResponses.responseType + ",txnStatus" + LC_ack.txnResponses.txnStatus + ",txnStatusDescription" + LC_ack.txnResponses.txnStatusDescription + " where msgid = '" + LC_ack.header.msgId;
                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                    using (OracleCommand cmd2 = new OracleCommand(commandText2, _db))
                    {
                        cmd2.Connection = _db;
                        _db.Open();
                        cmd2.CommandType = CommandType.Text;
                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd2.BindByName = true;
                        cmd2.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
                        cmd2.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
                        cmd2.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
                        cmd2.ExecuteNonQuery();
                        txn.Commit();
                        _db.Close();
                        return "zsdxcfgvhbj";
                    }

                }

                else
                {
                    ////ACK2A
                    var commandText2 = Queries.LC_ACK2_Sucess + "'" + LC_ack.header.msgId + "'";
                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                    using (OracleCommand cmd2 = new OracleCommand(commandText2, _db))
                    {
                        cmd2.Connection = _db;
                        _db.Open();
                        cmd2.CommandType = CommandType.Text;
                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd2.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
                        cmd2.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
                        cmd2.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
                        cmd2.Parameters.Add("attachmentRef", LC_ack.txnResponses.attachmentRef);
                        cmd2.ExecuteNonQuery();
                        txn.Commit();
                        _db.Close();
                    }

                    var commandText4 = Queries.LC_Doc_Upload + "'" + LC_ack.header.msgId + "'";
                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                    using (OracleCommand cmd4 = new OracleCommand(commandText4, _db))
                    {
                        cmd4.Connection = _db;
                        cmd4.CommandType = CommandType.Text;
                        _db.Open();
                        OracleDataReader reader = cmd4.ExecuteReader();
                        while (reader.Read())
                        {
                            Lc_Number lcnum = new Lc_Number();



                            doc.header.msgId = reader["msgId"].ToString();
                            doc.header.orgId = reader["rgId"].ToString();
                            doc.header.timeStamp = reader["timeStamp"].ToString();
                            doc.header.channelId = reader["channelId"].ToString();
                            doc.header.ctry = reader["ctry"].ToString();
                            doc.txnInfo.attachmentRef = reader["attachmentRef"].ToString();

                            var commandText5 = Queries.LC_NUM + "'" + LC_ack.header.msgId + "'";
                            using (OracleCommand cmd5 = new OracleCommand(commandText5, _db))
                            {
                                cmd5.CommandType = CommandType.Text;
                                OracleDataReader reader2 = cmd5.ExecuteReader();
                                while (reader2.Read())
                                {
                                    lcnum.LCnumber = reader2["LCNUMBER"].ToString();
                                }
                                var commandText6 = Queries.DOC; // + "'" + lcnum.LCnumber + "'";
                                using (OracleCommand cmd6 = new OracleCommand(commandText6, _db))
                                {
                                    cmd6.CommandType = CommandType.Text;
                                    OracleDataReader reader3 = cmd6.ExecuteReader();
                                    while (reader3.Read())
                                    {
                                        //dBS.txnInfo = txnInfo;
                                        //dBS.txnInfo.documents = new List<docFiles3>();
                                        //dBS.txnInfo.documents.Add(documents);

                                        doc.txnInfo.documents[0].DOCUMENT_NAME = reader3["IMAG_DOCUMENT_NAME"].ToString();
                                        doc.txnInfo.documents[0].file = (Byte[])(reader3.GetOracleBlob(1)).Value;

                                        list.Add(doc);
                                        Console.WriteLine(doc);
                                    }
                                }
                            }
                        }

                        _db.Close();
                    }
                    return doc;
                }
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error,  "repoTradeLcAck", "ACKTradeLc", exception, "INVALID_INPUT:Error occure while inserting data to DB");
                throw exception;
            }
        }

    }
}

        //-------------------------------------------------------for ACK1, ACK2-----------------------------------------
/// <summary>
/// ACK1---------Failed Response
/// ACK1---------Failed Response (from API Gateway)
/// ACK2A--------Success Response
/// ACK2A--------Reject Response
/// ACK2A--------Success Response (Exceed cutoff time)
/// </summary>
/// <param name="LC_ack"></param>
/// <returns></returns>
//        public object ACK1_2_TradeLc(TradeLC_ack LC_ack)
//        {
//            try
//            {
//                List<docFiles> list = new List<docFiles>();
//                string ackRejectCode = LC_ack.error.status;
//                string code = "RJCT";
//                var commandText = "UPDATE BLUESTARTF_PROD.letterofcredit SET code="+LC_ack.error.code+ ",txnStatusDescription"+LC_ack.error.description+ " where msgid = '" + LC_ack.header.msgId + "'";

//                ////ACK1---------Failed Response (from API Gateway)
//                if (ackRejectCode.Equals(code))
//                {
//                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//                    using (OracleCommand cmd = new OracleCommand(commandText, _db))
//                    {
//                        cmd.Connection = _db;
//                        _db.Open();
//                        cmd.CommandType = CommandType.Text;
//                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
//                        cmd.Parameters.Add("code", LC_ack.error.code);
//                        cmd.Parameters.Add("txnStatusDescription", LC_ack.error.description);
//                        cmd.ExecuteNonQuery();
//                        txn.Commit();
//                        _db.Close();
//                    }
//                }

//                ////ACK1---------Failed Response
//                string responseType = LC_ack.txnResponses.responseType;
//                string AckType = "ACK1";
//                var commandText1 = "UPDATE BLUESTARTF_PROD.letterofcredit SET responseType=" + LC_ack.txnResponses.responseType + ",txnStatus" + LC_ack.txnResponses.txnStatus + ",txnStatusDescription"+ LC_ack.txnResponses.txnStatusDescription + " where msgid = '" + LC_ack.header.msgId + "'";
//                if (responseType.Equals(AckType))
//                {
//                    using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//                    using (OracleCommand cmd1 = new OracleCommand(commandText1, _db))
//                    {
//                        cmd1.Connection = _db;
//                        _db.Open();
//                        cmd1.CommandType = CommandType.Text;
//                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
//                        cmd1.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
//                        cmd1.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
//                        cmd1.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
//                        cmd1.ExecuteNonQuery();
//                        txn.Commit();
//                        _db.Close();
//                    }

//                }

//                ////ACK2A AND ACK2C
//                else
//                {
//                    ////ACK2A AND ACK2C
//                    string Ack2Type = "RJCT";
//                    string txnStatus = LC_ack.txnResponses.txnStatus;
//                    string txncode = "ACK2C";
//                    if (txnStatus.Equals(Ack2Type) || responseType.Equals(txncode))
//                    {
//                        var commandText2 = "UPDATE BLUESTARTF_PROD.letterofcredit SET responseType=" + LC_ack.txnResponses.responseType + ",txnStatus" + LC_ack.txnResponses.txnStatus + ",txnStatusDescription" + LC_ack.txnResponses.txnStatusDescription + " where msgid = '" + LC_ack.header.msgId + "'";
//                        using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//                        using (OracleCommand cmd2 = new OracleCommand(commandText2, _db))
//                        {
//                            cmd2.Connection = _db;
//                            _db.Open();
//                            cmd2.CommandType = CommandType.Text;
//                            OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
//                            cmd2.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
//                            cmd2.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
//                            cmd2.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
//                            cmd2.ExecuteNonQuery();
//                            txn.Commit();
//                            _db.Close();
//                        }
//                    }

//                    else
//                    {
//                        ////ACK2A
//                        var commandText2 = "UPDATE BLUESTARTF_PROD.letterofcredit SET responseType=" + LC_ack.txnResponses.responseType + ",txnStatus" + LC_ack.txnResponses.txnStatus + ",txnStatusDescription" + LC_ack.txnResponses.txnStatusDescription + ",attachmentRef="+ LC_ack.txnResponses.attachmentRef + " where msgid = '" + LC_ack.header.msgId + "'";
//                        using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//                        using (OracleCommand cmd2 = new OracleCommand(commandText2, _db))
//                        {
//                            cmd2.Connection = _db;
//                            _db.Open();
//                            cmd2.CommandType = CommandType.Text;
//                            OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
//                            cmd2.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
//                            cmd2.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
//                            cmd2.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
//                            cmd2.Parameters.Add("attachmentRef", LC_ack.txnResponses.attachmentRef);
//                            cmd2.ExecuteNonQuery();
//                            txn.Commit();
//                            _db.Close();
//                        }
//                        var commandText4 = Queries.LC_Doc + "'" + LC_ack.header.msgId + "'";
//                        using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//                        using (OracleCommand cmd4 = new OracleCommand(commandText4, _db))
//                        {
//                            cmd4.Connection = _db;
//                            cmd4.CommandType = CommandType.Text;
//                            _db.Open();
//                            OracleDataReader reader = cmd4.ExecuteReader();
//                            while (reader.Read())
//                            {
//                                docFiles dBS = new docFiles();
//                                docFiles1 header = new docFiles1();
//                                docFiles2 txnInfo = new docFiles2();
//                                docFiles3 documents = new docFiles3();
//                                dBS.header = header;
//                                dBS.txnInfo = txnInfo;
//                                dBS.txnInfo.documents = new List<docFiles3>();
//                                dBS.txnInfo.documents.Add(documents);

//                                dBS.header.msgId = reader.GetString(0);
//                                dBS.header.orgId = reader.GetString(1);
//                                dBS.header.timeStamp = reader.GetString(2);
//                                dBS.header.channelId = reader.GetString(3);
//                                dBS.header.ctry = reader.GetString(4);
//                                dBS.txnInfo.attachmentRef = reader.GetString(5);

//                                var lc_number = Queries.LC_NUM +"'" + LC_ack.header.msgId + "'";
//                                var commandText5 = Queries.DOC + "'" + lc_number +"'";
//                                using (OracleCommand cmd5 = new OracleCommand(commandText5, _db))
//                                {
//                                    cmd5.CommandType = CommandType.Text;
//                                    OracleDataReader reader2 = cmd5.ExecuteReader();
//                                    while (reader2.Read())
//                                    {

//                                        dBS.header = header;
//                                        dBS.txnInfo = txnInfo;
//                                        dBS.txnInfo.documents = new List<docFiles3>();
//                                        dBS.txnInfo.documents.Add(documents);

//                                        dBS.txnInfo.documents[0].file = (Byte[])(reader2.GetOracleBlob(0)).Value;
//                                        dBS.txnInfo.documents[0].DOCUMENT_NAME = reader2.GetString(1);
//                                        list.Add(dBS);
//                                    }
//                                }
//                            }
//                            _db.Close();
//                        }
//                    }
//                }
//                return list;
//            }
//            catch (Exception exception)
//            {
//                LogCreate.LogWrite(LogEventLevel.Error,  "repoTradeLcAck", "ACKTradeLc", exception, "INVALID_INPUT:Error occure while inserting data to DB");
//                throw exception;
//            }
//        }



//    }
//}

//---------------------------------------------ading to database-----------------------------------------
////private readonly IConfiguration configuration;


///*    public  RepoImplementation(IConfiguration configuration)
//    {
//        this.configuration = configuration;
//    }
//    public object AddtoDatabase(locModel locModel)
//    {//91
//        try
//        {
//            var commandText = Queries.locpush;
//            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
//            using (OracleCommand cmd = new OracleCommand(commandText, _db))
//            {
//                cmd.Connection = _db;
//                cmd.Parameters.Add("msgId", locModel.header.msgId);
//                cmd.Parameters.Add("rgId", locModel.header.rgId);
//                cmd.Parameters.Add("TimeStamp", locModel.header.TimeStamp);
//                cmd.Parameters.Add("channelId", locModel.header.channelId);
//                cmd.Parameters.Add("ctry", locModel.header.ctry);

//                cmd.Parameters.Add("noOfDocAttached", locModel.header.noOfDocAttached);
//                cmd.Parameters.Add("txnType", locModel.txnInfo.txnType);
//                cmd.Parameters.Add("accountNumber", locModel.txnInfo.accountNumber);
//                cmd.Parameters.Add("ccy", locModel.txnInfo.ccy);
//                cmd.Parameters.Add("customerReference", locModel.txnInfo.partiesInfo.customerReference);

//                cmd.Parameters.Add("applicantContactName", locModel.txnInfo.partiesInfo.applicantContactName);
//                cmd.Parameters.Add("applicantContactNumber", locModel.txnInfo.partiesInfo.applicantContactNumber);
//                cmd.Parameters.Add("thirdPartyName", locModel.txnInfo.partiesInfo.thirdPartyName);
//                cmd.Parameters.Add("thirdPartyAddress", locModel.txnInfo.partiesInfo.thirdPartyAddress);
//                cmd.Parameters.Add("beneName", locModel.txnInfo.partiesInfo.beneName);

//                cmd.Parameters.Add("beneAddress", locModel.txnInfo.partiesInfo.beneAddress);
//                cmd.Parameters.Add("beneCountry", locModel.txnInfo.partiesInfo.beneCountry);
//                cmd.Parameters.Add("beneContactName", locModel.txnInfo.partiesInfo.beneContactName);
//                cmd.Parameters.Add("beneContactNumber", locModel.txnInfo.partiesInfo.beneContactNumber);
//                cmd.Parameters.Add("advisingBank", locModel.txnInfo.partiesInfo.advisingBank);

//                cmd.Parameters.Add("advisingBankAddress", locModel.txnInfo.partiesInfo.advisingBankAddress);
//                cmd.Parameters.Add("advisingBankSwiftCode", locModel.txnInfo.partiesInfo.advisingBankSwiftCode);
//                cmd.Parameters.Add("sendVia", locModel.txnDetails.sendVia);
//                cmd.Parameters.Add("expiryDate", locModel.txnDetails.expiryDate);
//                cmd.Parameters.Add("expiryCountry", locModel.txnDetails.expiryCountry);

//                cmd.Parameters.Add("expiryPlace", locModel.txnDetails.expiryPlace);
//                cmd.Parameters.Add("lcType", locModel.txnDetails.lcType);
//                cmd.Parameters.Add("lcCcy", locModel.txnDetails.lcCcy);
//                cmd.Parameters.Add("lcAmount", locModel.txnDetails.lcAmount);
//                cmd.Parameters.Add("localLcAmtIs", locModel.txnDetails.localLcAmtIs);

//                cmd.Parameters.Add("tolCrAmtGoodsQuanPlus", locModel.txnDetails.tolCrAmtGoodsQuanPlus);
//                cmd.Parameters.Add("tolCrAmtGoodsQuanMinus", locModel.txnDetails.tolCrAmtGoodsQuanMinus);
//                cmd.Parameters.Add("creditAvailableWith", locModel.txnDetails.creditAvailableWith);
//                cmd.Parameters.Add("creditAvailableWithOthersName", locModel.txnDetails.creditAvailableWithOthersName);
//                cmd.Parameters.Add("creditAvailableWithOthersAdd", locModel.txnDetails.creditAvailableWithOthersAdd);

//                cmd.Parameters.Add("creditAvailableBy", locModel.txnDetails.creditAvailableBy);
//                cmd.Parameters.Add("draftDrawnOn", locModel.txnDetails.draftDrawnOn);
//                cmd.Parameters.Add("tenor", locModel.txnDetails.tenor);
//                cmd.Parameters.Add("tenorDays", locModel.txnDetails.tenorDays);
//                cmd.Parameters.Add("tenorPhrase", locModel.txnDetails.tenorPhrase);

//                cmd.Parameters.Add("tenorPhraseOthers", locModel.txnDetails.tenorPhraseOthers);
//                cmd.Parameters.Add("tenorPhraseFxdMat", locModel.txnDetails.tenorPhraseFxdMat);
//                cmd.Parameters.Add("paymentDetails", locModel.txnDetails.paymentDetails);
//                cmd.Parameters.Add("creditTransferable", locModel.txnDetails.creditTransferable);
//                cmd.Parameters.Add("confirmationRequired", locModel.txnDetails.confirmationRequired);

//                cmd.Parameters.Add("confirmationCharges", locModel.txnDetails.confirmationCharges);
//                cmd.Parameters.Add("confirmingBank", locModel.txnDetails.confirmingBank);
//                cmd.Parameters.Add("confirmingBankAddress", locModel.txnDetails.confirmingBankAddress);
//                cmd.Parameters.Add("goodsDescription", locModel.shipmentDetails[0].goodsDescription);
//                cmd.Parameters.Add("placeOfReceipt", locModel.shipmentDetails[0].placeOfReceipt);

//                cmd.Parameters.Add("portOfLoading", locModel.shipmentDetails[0].portOfLoading);
//                cmd.Parameters.Add("portOfDischarge", locModel.shipmentDetails[0].portOfDischarge);
//                cmd.Parameters.Add("placeOfDelivery", locModel.shipmentDetails[0].placeOfDelivery);
//                cmd.Parameters.Add("partialShipmentAllowed", locModel.shipmentDetails[0].partialShipmentAllowed);
//                cmd.Parameters.Add("transhipmentAllowed", locModel.shipmentDetails[0].transhipmentAllowed);

//                cmd.Parameters.Add("latestShipmentDate", locModel.shipmentDetails[0].latestShipmentDate);
//                cmd.Parameters.Add("shipmentPeriod", locModel.shipmentDetails[0].shipmentPeriod);
//                cmd.Parameters.Add("presentationPeriod", locModel.shipmentDetails[0].presentationPeriod);
//                cmd.Parameters.Add("presentationPeriodFrom", locModel.shipmentDetails[0].presentationPeriodFrom);
//                cmd.Parameters.Add("presentationPeriodOth", locModel.shipmentDetails[0].presentationPeriodOth);

//                cmd.Parameters.Add("shippingTerms", locModel.shipmentDetails[0].shippingTerms);
//                cmd.Parameters.Add("insuranceBy", locModel.shipmentDetails[0].insuranceBy);
//                cmd.Parameters.Add("buyerInsuranceDetails", locModel.shipmentDetails[0].buyerInsuranceDetails);
//                cmd.Parameters.Add("coverNoteDetails", locModel.shipmentDetails[0].coverNoteDetails);
//                cmd.Parameters.Add("transportDocType", locModel.transportDocsDetails.transportDocType);

//                cmd.Parameters.Add("freight", locModel.transportDocsDetails.freight);
//                cmd.Parameters.Add("freightOthers", locModel.transportDocsDetails.freightOthers);
//                cmd.Parameters.Add("totalOriginals", locModel.transportDocsDetails.totalOriginals);
//                cmd.Parameters.Add("originalsRequired", locModel.transportDocsDetails.originalsRequired);
//                cmd.Parameters.Add("copiesRequired", locModel.transportDocsDetails.copiesRequired);

//                cmd.Parameters.Add("consignedTo", locModel.transportDocsDetails.consignedTo);
//                cmd.Parameters.Add("consignedToOthers", locModel.transportDocsDetails.consignedToOthers);
//                cmd.Parameters.Add("notifyParty", locModel.transportDocsDetails.notifyParty);
//                cmd.Parameters.Add("docRequired", locModel.documentsDetails.docRequired);
//                cmd.Parameters.Add("insuranceDocs", locModel.documentsDetails.insuranceDocs);

//                cmd.Parameters.Add("additionalConditions", locModel.documentsDetails.additionalConditions);
//                cmd.Parameters.Add("specialConditionBene", locModel.documentsDetails.specialConditionBene);
//                cmd.Parameters.Add("specialConditionAdv", locModel.documentsDetails.specialConditionAdv);
//                cmd.Parameters.Add("charges", locModel.instructionsDetails.charges);
//                cmd.Parameters.Add("chargesOthers", locModel.instructionsDetails.chargesOthers);

//                cmd.Parameters.Add("chargesAccountNo", locModel.instructionsDetails.chargesAccountNo);
//                cmd.Parameters.Add("chargesAccountCcy", locModel.instructionsDetails.chargesAccountCcy);
//                cmd.Parameters.Add("specialInstruction", locModel.instructionsDetails.specialInstruction);
//                cmd.Parameters.Add("financeRequired", locModel.instructionsDetails.financeRequired);
//                cmd.Parameters.Add("financeCurrency", locModel.instructionsDetails.financeCurrency);

//                cmd.Parameters.Add("forwardContractNumber", locModel.instructionsDetails.forwardContractNumber);
//                cmd.Parameters.Add("typeOfDocument", locModel.additionalDocuments[0].typeOfDocument);
//                cmd.Parameters.Add("noOfSets", locModel.additionalDocuments[0].noOfSets);
//                cmd.Parameters.Add("noOfOriginal", locModel.additionalDocuments[0].noOfOriginal);
//                cmd.Parameters.Add("noOfCopies", locModel.additionalDocuments[0].noOfCopies);
//                _db.Open();
//                cmd.ExecuteNonQuery();
//                _db.Close();

//                return locModel.header.msgId + " = DBSS_LC_CODE is sucessfull added";
//            }
//        }
//        catch (CustomException exception)
//        {
//            throw new CustomException(CustomException.ExceptionType.INVALID_INPUT, exception.Message);
//        }
//    



//---------------------------------------------------for doc ---------------------------------------------------

///* public Object docread()
// {
//     List<docfiles> list = new List<docfiles>();
//     var commandText = Queries.DocQuery;
//     using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
//     using (OracleCommand cmd = new OracleCommand(commandText, _db))
//     {
//         cmd.Connection = _db;
//         cmd.CommandType = CommandType.Text;
//         _db.Open();
//         OracleDataReader reader = cmd.ExecuteReader();
//         while (reader.Read())
//         {
//             docfiles docfiles = new docfiles();
//             /*  OracleBlob b = reader.GetOracleBlob(1);
//               var sr = new System.IO.StreamReader(b);
//               docfiles.DOCUMENT_IMAGE = sr.ReadToEnd();*/
//             Byte[] buffer = (Byte[])(reader.GetOracleBlob(1)).Value;
//             var content = new String(Encoding.UTF8.GetChars(buffer));
//             docfiles.DOCUMENT_IMAGE = content;
//             docfiles.DOCUMENT_NAME = reader.GetString(2);
//             docfiles.DOCUMENT_TYPE = reader.GetString(3);
//             list.Add(docfiles);
//         }
//         _db.Close();
//     }
//     return list;
// }*/

