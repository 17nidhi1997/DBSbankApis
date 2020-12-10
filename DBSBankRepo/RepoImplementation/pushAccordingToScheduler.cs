using DBSBankComman;
using DBSBankComman.Model;
using DBSBankComman.Querie;
using DBSBankComman.Utilities;
using DBSBankRepo.IRepo;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBSBankRepo.RepoImplementation
{
    public class pushAccordingToScheduler 
    {
        //private readonly IConfiguration configuration;


        /*    public  RepoImplementation(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public object AddtoDatabase(locModel locModel)
            {//91
                try
                {
                    var commandText = Queries.locpush;
                    using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
                    using (OracleCommand cmd = new OracleCommand(commandText, _db))
                    {
                        cmd.Connection = _db;
                        cmd.Parameters.Add("msgId", locModel.header.msgId);
                        cmd.Parameters.Add("rgId", locModel.header.rgId);
                        cmd.Parameters.Add("TimeStamp", locModel.header.TimeStamp);
                        cmd.Parameters.Add("channelId", locModel.header.channelId);
                        cmd.Parameters.Add("ctry", locModel.header.ctry);

                        cmd.Parameters.Add("noOfDocAttached", locModel.header.noOfDocAttached);
                        cmd.Parameters.Add("txnType", locModel.txnInfo.txnType);
                        cmd.Parameters.Add("accountNumber", locModel.txnInfo.accountNumber);
                        cmd.Parameters.Add("ccy", locModel.txnInfo.ccy);
                        cmd.Parameters.Add("customerReference", locModel.txnInfo.partiesInfo.customerReference);

                        cmd.Parameters.Add("applicantContactName", locModel.txnInfo.partiesInfo.applicantContactName);
                        cmd.Parameters.Add("applicantContactNumber", locModel.txnInfo.partiesInfo.applicantContactNumber);
                        cmd.Parameters.Add("thirdPartyName", locModel.txnInfo.partiesInfo.thirdPartyName);
                        cmd.Parameters.Add("thirdPartyAddress", locModel.txnInfo.partiesInfo.thirdPartyAddress);
                        cmd.Parameters.Add("beneName", locModel.txnInfo.partiesInfo.beneName);

                        cmd.Parameters.Add("beneAddress", locModel.txnInfo.partiesInfo.beneAddress);
                        cmd.Parameters.Add("beneCountry", locModel.txnInfo.partiesInfo.beneCountry);
                        cmd.Parameters.Add("beneContactName", locModel.txnInfo.partiesInfo.beneContactName);
                        cmd.Parameters.Add("beneContactNumber", locModel.txnInfo.partiesInfo.beneContactNumber);
                        cmd.Parameters.Add("advisingBank", locModel.txnInfo.partiesInfo.advisingBank);

                        cmd.Parameters.Add("advisingBankAddress", locModel.txnInfo.partiesInfo.advisingBankAddress);
                        cmd.Parameters.Add("advisingBankSwiftCode", locModel.txnInfo.partiesInfo.advisingBankSwiftCode);
                        cmd.Parameters.Add("sendVia", locModel.txnDetails.sendVia);
                        cmd.Parameters.Add("expiryDate", locModel.txnDetails.expiryDate);
                        cmd.Parameters.Add("expiryCountry", locModel.txnDetails.expiryCountry);

                        cmd.Parameters.Add("expiryPlace", locModel.txnDetails.expiryPlace);
                        cmd.Parameters.Add("lcType", locModel.txnDetails.lcType);
                        cmd.Parameters.Add("lcCcy", locModel.txnDetails.lcCcy);
                        cmd.Parameters.Add("lcAmount", locModel.txnDetails.lcAmount);
                        cmd.Parameters.Add("localLcAmtIs", locModel.txnDetails.localLcAmtIs);

                        cmd.Parameters.Add("tolCrAmtGoodsQuanPlus", locModel.txnDetails.tolCrAmtGoodsQuanPlus);
                        cmd.Parameters.Add("tolCrAmtGoodsQuanMinus", locModel.txnDetails.tolCrAmtGoodsQuanMinus);
                        cmd.Parameters.Add("creditAvailableWith", locModel.txnDetails.creditAvailableWith);
                        cmd.Parameters.Add("creditAvailableWithOthersName", locModel.txnDetails.creditAvailableWithOthersName);
                        cmd.Parameters.Add("creditAvailableWithOthersAdd", locModel.txnDetails.creditAvailableWithOthersAdd);

                        cmd.Parameters.Add("creditAvailableBy", locModel.txnDetails.creditAvailableBy);
                        cmd.Parameters.Add("draftDrawnOn", locModel.txnDetails.draftDrawnOn);
                        cmd.Parameters.Add("tenor", locModel.txnDetails.tenor);
                        cmd.Parameters.Add("tenorDays", locModel.txnDetails.tenorDays);
                        cmd.Parameters.Add("tenorPhrase", locModel.txnDetails.tenorPhrase);

                        cmd.Parameters.Add("tenorPhraseOthers", locModel.txnDetails.tenorPhraseOthers);
                        cmd.Parameters.Add("tenorPhraseFxdMat", locModel.txnDetails.tenorPhraseFxdMat);
                        cmd.Parameters.Add("paymentDetails", locModel.txnDetails.paymentDetails);
                        cmd.Parameters.Add("creditTransferable", locModel.txnDetails.creditTransferable);
                        cmd.Parameters.Add("confirmationRequired", locModel.txnDetails.confirmationRequired);

                        cmd.Parameters.Add("confirmationCharges", locModel.txnDetails.confirmationCharges);
                        cmd.Parameters.Add("confirmingBank", locModel.txnDetails.confirmingBank);
                        cmd.Parameters.Add("confirmingBankAddress", locModel.txnDetails.confirmingBankAddress);
                        cmd.Parameters.Add("goodsDescription", locModel.shipmentDetails[0].goodsDescription);
                        cmd.Parameters.Add("placeOfReceipt", locModel.shipmentDetails[0].placeOfReceipt);

                        cmd.Parameters.Add("portOfLoading", locModel.shipmentDetails[0].portOfLoading);
                        cmd.Parameters.Add("portOfDischarge", locModel.shipmentDetails[0].portOfDischarge);
                        cmd.Parameters.Add("placeOfDelivery", locModel.shipmentDetails[0].placeOfDelivery);
                        cmd.Parameters.Add("partialShipmentAllowed", locModel.shipmentDetails[0].partialShipmentAllowed);
                        cmd.Parameters.Add("transhipmentAllowed", locModel.shipmentDetails[0].transhipmentAllowed);

                        cmd.Parameters.Add("latestShipmentDate", locModel.shipmentDetails[0].latestShipmentDate);
                        cmd.Parameters.Add("shipmentPeriod", locModel.shipmentDetails[0].shipmentPeriod);
                        cmd.Parameters.Add("presentationPeriod", locModel.shipmentDetails[0].presentationPeriod);
                        cmd.Parameters.Add("presentationPeriodFrom", locModel.shipmentDetails[0].presentationPeriodFrom);
                        cmd.Parameters.Add("presentationPeriodOth", locModel.shipmentDetails[0].presentationPeriodOth);

                        cmd.Parameters.Add("shippingTerms", locModel.shipmentDetails[0].shippingTerms);
                        cmd.Parameters.Add("insuranceBy", locModel.shipmentDetails[0].insuranceBy);
                        cmd.Parameters.Add("buyerInsuranceDetails", locModel.shipmentDetails[0].buyerInsuranceDetails);
                        cmd.Parameters.Add("coverNoteDetails", locModel.shipmentDetails[0].coverNoteDetails);
                        cmd.Parameters.Add("transportDocType", locModel.transportDocsDetails.transportDocType);

                        cmd.Parameters.Add("freight", locModel.transportDocsDetails.freight);
                        cmd.Parameters.Add("freightOthers", locModel.transportDocsDetails.freightOthers);
                        cmd.Parameters.Add("totalOriginals", locModel.transportDocsDetails.totalOriginals);
                        cmd.Parameters.Add("originalsRequired", locModel.transportDocsDetails.originalsRequired);
                        cmd.Parameters.Add("copiesRequired", locModel.transportDocsDetails.copiesRequired);

                        cmd.Parameters.Add("consignedTo", locModel.transportDocsDetails.consignedTo);
                        cmd.Parameters.Add("consignedToOthers", locModel.transportDocsDetails.consignedToOthers);
                        cmd.Parameters.Add("notifyParty", locModel.transportDocsDetails.notifyParty);
                        cmd.Parameters.Add("docRequired", locModel.documentsDetails.docRequired);
                        cmd.Parameters.Add("insuranceDocs", locModel.documentsDetails.insuranceDocs);

                        cmd.Parameters.Add("additionalConditions", locModel.documentsDetails.additionalConditions);
                        cmd.Parameters.Add("specialConditionBene", locModel.documentsDetails.specialConditionBene);
                        cmd.Parameters.Add("specialConditionAdv", locModel.documentsDetails.specialConditionAdv);
                        cmd.Parameters.Add("charges", locModel.instructionsDetails.charges);
                        cmd.Parameters.Add("chargesOthers", locModel.instructionsDetails.chargesOthers);

                        cmd.Parameters.Add("chargesAccountNo", locModel.instructionsDetails.chargesAccountNo);
                        cmd.Parameters.Add("chargesAccountCcy", locModel.instructionsDetails.chargesAccountCcy);
                        cmd.Parameters.Add("specialInstruction", locModel.instructionsDetails.specialInstruction);
                        cmd.Parameters.Add("financeRequired", locModel.instructionsDetails.financeRequired);
                        cmd.Parameters.Add("financeCurrency", locModel.instructionsDetails.financeCurrency);

                        cmd.Parameters.Add("forwardContractNumber", locModel.instructionsDetails.forwardContractNumber);
                        cmd.Parameters.Add("typeOfDocument", locModel.additionalDocuments[0].typeOfDocument);
                        cmd.Parameters.Add("noOfSets", locModel.additionalDocuments[0].noOfSets);
                        cmd.Parameters.Add("noOfOriginal", locModel.additionalDocuments[0].noOfOriginal);
                        cmd.Parameters.Add("noOfCopies", locModel.additionalDocuments[0].noOfCopies);
                        _db.Open();
                        cmd.ExecuteNonQuery();
                        _db.Close();

                        return locModel.header.msgId + " = DBSS_LC_CODE is sucessfull added";
                    }
                }
                catch (CustomException exception)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_INPUT, exception.Message);
                }
            }*/

        public Object DBSStatus()
        {
            try
            {
                List<locModel> list = new List<locModel>();
                var commandText = Queries.locget;
                using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
                using (OracleCommand cmd = new OracleCommand(commandText, _db))
                {
                    cmd.Connection = _db;
                    cmd.CommandType = CommandType.Text;
                    _db.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        locModel dBS = new locModel();
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
                        dBS.txnDetails = txnDetails;
                        dBS.txnInfo = txnInfo;

                        dBS.shipmentDetails = new List<locModel5>();
                        dBS.shipmentDetails.Add(shipmentDetails);

                        dBS.transportDocsDetails = transportDocsDetails;
                        dBS.documentsDetails = documentsDetails;
                        dBS.instructionsDetails = instructionsDetails;

                        dBS.additionalDocuments = new List<locModel9>();
                        dBS.additionalDocuments.Add(additionalDocuments);


                        dBS.header.msgId = reader.GetString(0);
                        dBS.header.orgId = reader.GetString(1);
                        dBS.header.TimeStamp = reader.GetString(2);
                        dBS.header.channelId = reader.GetString(3);
                        dBS.header.ctry = reader.GetString(4);
                        dBS.header.noOfDocAttached = reader.GetInt32(5);

                        dBS.txnInfo.txnType = reader.GetString(6);
                        dBS.txnInfo.accountNumber = reader.GetString(7);
                        dBS.txnInfo.ccy = reader.GetString(8);

                        dBS.txnInfo.partiesInfo.customerReference = reader.GetString(9);
                        dBS.txnInfo.partiesInfo.applicantContactName = reader.GetString(10);
                        dBS.txnInfo.partiesInfo.applicantContactNumber = reader.GetString(11);
                        dBS.txnInfo.partiesInfo.thirdPartyName = reader.GetString(12);
                        dBS.txnInfo.partiesInfo.thirdPartyAddress = reader.GetString(13);
                        dBS.txnInfo.partiesInfo.beneName = reader.GetString(14);
                        dBS.txnInfo.partiesInfo.beneAddress = reader.GetString(15);
                        dBS.txnInfo.partiesInfo.beneCountry = reader.GetString(16);
                        dBS.txnInfo.partiesInfo.beneContactName = reader.GetString(17);
                        dBS.txnInfo.partiesInfo.beneContactNumber = reader.GetInt16(18);
                        dBS.txnInfo.partiesInfo.advisingBank = reader.GetString(19);
                        dBS.txnInfo.partiesInfo.advisingBankAddress = reader.GetString(20);
                        dBS.txnInfo.partiesInfo.advisingBankSwiftCode = reader.GetString(21);

                        dBS.txnDetails.sendVia = reader.GetString(22);
                        dBS.txnDetails.expiryDate = reader.GetDateTime(23);
                        dBS.txnDetails.expiryCountry = reader.GetString(24);
                        dBS.txnDetails.expiryPlace = reader.GetString(25);
                        dBS.txnDetails.lcType = reader.GetInt32(26);
                        dBS.txnDetails.lcCcy = reader.GetString(27);
                        dBS.txnDetails.lcAmount = reader.GetInt32(28);
                        dBS.txnDetails.localLcAmtIs = reader.GetString(29);
                        dBS.txnDetails.tolCrAmtGoodsQuanPlus = reader.GetInt32(30);
                        dBS.txnDetails.tolCrAmtGoodsQuanMinus = reader.GetInt32(31);
                        dBS.txnDetails.creditAvailableWith = reader.GetInt32(32);
                        dBS.txnDetails.creditAvailableWithOthersName = reader.GetString(33);
                        dBS.txnDetails.creditAvailableWithOthersAdd = reader.GetString(34);
                        dBS.txnDetails.creditAvailableBy = reader.GetInt32(35);
                        dBS.txnDetails.draftDrawnOn = reader.GetInt32(36);
                        dBS.txnDetails.tenor = reader.GetString(37);
                        dBS.txnDetails.tenorDays = reader.GetInt32(38);
                        dBS.txnDetails.tenorPhrase = reader.GetString(39);
                        dBS.txnDetails.tenorPhraseOthers = reader.GetString(40);
                        dBS.txnDetails.tenorPhraseFxdMat = reader.GetDateTime(41);
                        dBS.txnDetails.paymentDetails = reader.GetString(42);
                        dBS.txnDetails.creditTransferable = reader.GetString(43);
                        dBS.txnDetails.confirmationRequired = reader.GetString(44);
                        dBS.txnDetails.confirmationCharges = reader.GetString(45);
                        dBS.txnDetails.confirmingBank = reader.GetString(46);
                        dBS.txnDetails.confirmingBankAddress = reader.GetString(47);

                        dBS.shipmentDetails[0].goodsDescription = reader.GetString(48);
                        dBS.shipmentDetails[0].placeOfReceipt = reader.GetString(49);
                        dBS.shipmentDetails[0].portOfLoading = reader.GetString(50);
                        dBS.shipmentDetails[0].portOfDischarge = reader.GetString(51);
                        dBS.shipmentDetails[0].placeOfDelivery = reader.GetString(52);
                        dBS.shipmentDetails[0].partialShipmentAllowed = reader.GetString(53);
                        dBS.shipmentDetails[0].transhipmentAllowed = reader.GetString(54);
                        dBS.shipmentDetails[0].latestShipmentDate = reader.GetDateTime(55);
                        dBS.shipmentDetails[0].shipmentPeriod = reader.GetString(56);
                        dBS.shipmentDetails[0].presentationPeriod = reader.GetInt32(57);
                        dBS.shipmentDetails[0].presentationPeriodFrom = reader.GetString(58);
                        dBS.shipmentDetails[0].presentationPeriodOth = reader.GetString(59);
                        dBS.shipmentDetails[0].shippingTerms = reader.GetString(60);
                        dBS.shipmentDetails[0].insuranceBy = reader.GetString(61);
                        dBS.shipmentDetails[0].buyerInsuranceDetails = reader.GetString(62);
                        dBS.shipmentDetails[0].coverNoteDetails = reader.GetString(63);

                        dBS.transportDocsDetails.transportDocType = reader.GetString(64);
                        dBS.transportDocsDetails.freight = reader.GetString(65);
                        dBS.transportDocsDetails.freightOthers = reader.GetString(66);
                        dBS.transportDocsDetails.totalOriginals = reader.GetInt32(67);
                        dBS.transportDocsDetails.originalsRequired = reader.GetInt32(68);
                        dBS.transportDocsDetails.copiesRequired = reader.GetInt32(69);
                        dBS.transportDocsDetails.consignedTo = reader.GetInt32(70);
                        dBS.transportDocsDetails.consignedToOthers = reader.GetString(71);
                        dBS.transportDocsDetails.notifyParty = reader.GetString(72);


                        dBS.documentsDetails.docRequired = reader.GetString(73);
                        dBS.documentsDetails.insuranceDocs = reader.GetString(74);
                        dBS.documentsDetails.additionalConditions = reader.GetString(75);
                        dBS.documentsDetails.specialConditionBene = reader.GetString(76);
                        dBS.documentsDetails.specialConditionAdv = reader.GetString(77);

                        dBS.instructionsDetails.charges = reader.GetString(78);
                        dBS.instructionsDetails.chargesOthers = reader.GetString(79);
                        dBS.instructionsDetails.chargesAccountNo = reader.GetString(80);
                        dBS.instructionsDetails.chargesAccountCcy = reader.GetString(81);
                        dBS.instructionsDetails.specialInstruction = reader.GetString(82);
                        dBS.instructionsDetails.financeRequired = reader.GetString(83);
                        dBS.instructionsDetails.financeCurrency = reader.GetString(84);
                        dBS.instructionsDetails.forwardContractNumber = reader.GetString(85);

                        dBS.additionalDocuments[0].typeOfDocument = reader.GetString(86);
                        dBS.additionalDocuments[0].noOfSets = reader.GetInt32(87);
                        dBS.additionalDocuments[0].noOfOriginal = reader.GetInt32(88);
                        dBS.additionalDocuments[0].noOfCopies = reader.GetInt32(89);
                        list.Add(dBS);
                        
                    }
                    _db.Close();
                    var commandText1 = Queries.UnParkingUpdateQuery;
                    using (OracleCommand cmd1 = new OracleCommand(commandText1, _db))
                    {
                        cmd1.Connection = _db;
                        _db.Open();
                        cmd1.CommandType = CommandType.Text;
                        OracleTransaction txn = _db.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd1.Parameters.Add(" PROCESSSTATUS", "12400001");
                        cmd1.ExecuteNonQuery();
                        txn.Commit();
                        _db.Close();
                    }
                    return list;
                   
                }
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "pushAccordingToScheduler", "DBSStatus", exception, "NULL_EXCEPTION:Requested data not found");
                throw exception;
            }
        }

        public Object docread()
        {
            List<docfiles> list = new List<docfiles>();
            var commandText = Queries.DocQuery;
            using (var _db = new OracleConnection("User Id=BLUESTARTF_PROD;Password=BLUESTARTF_PROD;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=122.166.201.214)(PORT=1521))(CONNECT_DATA=(FAILOVER_MODE=(TYPE=select)(METHOD=basic))(SERVER=dedicated)(SERVICE_NAME=IBSorcl))))"))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    docfiles docfiles = new docfiles();
                    /*  OracleBlob b = reader.GetOracleBlob(1);
                      var sr = new System.IO.StreamReader(b);
                      docfiles.DOCUMENT_IMAGE = sr.ReadToEnd();*/
                    Byte[] buffer = (Byte[])(reader.GetOracleBlob(1)).Value;
                    var content = new String(Encoding.UTF8.GetChars(buffer));
                    docfiles.DOCUMENT_IMAGE = content;
                    docfiles.DOCUMENT_NAME = reader.GetString(2);
                    docfiles.DOCUMENT_TYPE = reader.GetString(3);
                    list.Add(docfiles);
                }
                _db.Close();
            }
            return list;
        }
    }
}
           
