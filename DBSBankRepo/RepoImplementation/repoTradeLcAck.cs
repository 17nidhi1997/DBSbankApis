using DBSBankComman;
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
    public class repoTradeLcAck:IRepoLC
    {
        private readonly IConfiguration configuration;
        public repoTradeLcAck(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object ACKTradeLc(TradeLC_ack LC_ack)
        {
            try { 
                var commandText = Queries.locpush;
                using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
                using (OracleCommand cmd = new OracleCommand(commandText, _db))
                {
                    
                    //cmd.Connection = _db;
                    //cmd.Parameters.Add("msgId", locModel.header.msgId);
                    //cmd.Parameters.Add("orgId", locModel.header.orgId);
                    //cmd.Parameters.Add("TimeStamp", locModel.header.TimeStamp);
                    //cmd.Parameters.Add("channelId", locModel.header.channelId);
                    //cmd.Parameters.Add("ctry", locModel.header.ctry);

                    //cmd.Parameters.Add("noOfDocAttached", locModel.header.noOfDocAttached);
                    //cmd.Parameters.Add("txnType", locModel.txnInfo.txnType);
                    //cmd.Parameters.Add("accountNumber", locModel.txnInfo.accountNumber);
                    //cmd.Parameters.Add("ccy", locModel.txnInfo.ccy);
                    //cmd.Parameters.Add("customerReference", locModel.txnInfo.partiesInfo.customerReference);

                    //cmd.Parameters.Add("applicantContactName", locModel.txnInfo.partiesInfo.applicantContactName);
                    //cmd.Parameters.Add("applicantContactNumber", locModel.txnInfo.partiesInfo.applicantContactNumber);
                    //cmd.Parameters.Add("thirdPartyName", locModel.txnInfo.partiesInfo.thirdPartyName);
                    //cmd.Parameters.Add("thirdPartyAddress", locModel.txnInfo.partiesInfo.thirdPartyAddress);
                    //cmd.Parameters.Add("beneName", locModel.txnInfo.partiesInfo.beneName);

                    //cmd.Parameters.Add("beneAddress", locModel.txnInfo.partiesInfo.beneAddress);
                    //cmd.Parameters.Add("beneCountry", locModel.txnInfo.partiesInfo.beneCountry);
                    //cmd.Parameters.Add("beneContactName", locModel.txnInfo.partiesInfo.beneContactName);
                    //cmd.Parameters.Add("beneContactNumber", locModel.txnInfo.partiesInfo.beneContactNumber);
                    //cmd.Parameters.Add("advisingBank", locModel.txnInfo.partiesInfo.advisingBank);

                    //cmd.Parameters.Add("advisingBankAddress", locModel.txnInfo.partiesInfo.advisingBankAddress);
                    //cmd.Parameters.Add("advisingBankSwiftCode", locModel.txnInfo.partiesInfo.advisingBankSwiftCode);
                    //cmd.Parameters.Add("sendVia", locModel.txnDetails.sendVia);
                    //cmd.Parameters.Add("expiryDate", locModel.txnDetails.expiryDate);
                    //cmd.Parameters.Add("expiryCountry", locModel.txnDetails.expiryCountry);

                    //cmd.Parameters.Add("expiryPlace", locModel.txnDetails.expiryPlace);
                    //cmd.Parameters.Add("lcType", locModel.txnDetails.lcType);
                    //cmd.Parameters.Add("lcCcy", locModel.txnDetails.lcCcy);
                    //cmd.Parameters.Add("lcAmount", locModel.txnDetails.lcAmount);
                    //cmd.Parameters.Add("localLcAmtIs", locModel.txnDetails.localLcAmtIs);

                    //cmd.Parameters.Add("tolCrAmtGoodsQuanPlus", locModel.txnDetails.tolCrAmtGoodsQuanPlus);
                    //cmd.Parameters.Add("tolCrAmtGoodsQuanMinus", locModel.txnDetails.tolCrAmtGoodsQuanMinus);
                    //cmd.Parameters.Add("creditAvailableWith", locModel.txnDetails.creditAvailableWith);
                    //cmd.Parameters.Add("creditAvailableWithOthersName", locModel.txnDetails.creditAvailableWithOthersName);
                    //cmd.Parameters.Add("creditAvailableWithOthersAdd", locModel.txnDetails.creditAvailableWithOthersAdd);

                    //cmd.Parameters.Add("creditAvailableBy", locModel.txnDetails.creditAvailableBy);
                    //cmd.Parameters.Add("draftDrawnOn", locModel.txnDetails.draftDrawnOn);
                    //cmd.Parameters.Add("tenor", locModel.txnDetails.tenor);
                    //cmd.Parameters.Add("tenorDays", locModel.txnDetails.tenorDays);
                    //cmd.Parameters.Add("tenorPhrase", locModel.txnDetails.tenorPhrase);

                    //cmd.Parameters.Add("tenorPhraseOthers", locModel.txnDetails.tenorPhraseOthers);
                    //cmd.Parameters.Add("tenorPhraseFxdMat", locModel.txnDetails.tenorPhraseFxdMat);
                    //cmd.Parameters.Add("paymentDetails", locModel.txnDetails.paymentDetails);
                    //cmd.Parameters.Add("creditTransferable", locModel.txnDetails.creditTransferable);
                    //cmd.Parameters.Add("confirmationRequired", locModel.txnDetails.confirmationRequired);

                    //cmd.Parameters.Add("confirmationCharges", locModel.txnDetails.confirmationCharges);
                    //cmd.Parameters.Add("confirmingBank", locModel.txnDetails.confirmingBank);
                    //cmd.Parameters.Add("confirmingBankAddress", locModel.txnDetails.confirmingBankAddress);
                    //cmd.Parameters.Add("goodsDescription", locModel.shipmentDetails[0].goodsDescription);
                    //cmd.Parameters.Add("placeOfReceipt", locModel.shipmentDetails[0].placeOfReceipt);

                    //cmd.Parameters.Add("portOfLoading", locModel.shipmentDetails[0].portOfLoading);
                    //cmd.Parameters.Add("portOfDischarge", locModel.shipmentDetails[0].portOfDischarge);
                    //cmd.Parameters.Add("placeOfDelivery", locModel.shipmentDetails[0].placeOfDelivery);
                    //cmd.Parameters.Add("partialShipmentAllowed", locModel.shipmentDetails[0].partialShipmentAllowed);
                    //cmd.Parameters.Add("transhipmentAllowed", locModel.shipmentDetails[0].transhipmentAllowed);

                    //cmd.Parameters.Add("latestShipmentDate", locModel.shipmentDetails[0].latestShipmentDate);
                    //cmd.Parameters.Add("shipmentPeriod", locModel.shipmentDetails[0].shipmentPeriod);
                    //cmd.Parameters.Add("presentationPeriod", locModel.shipmentDetails[0].presentationPeriod);
                    //cmd.Parameters.Add("presentationPeriodFrom", locModel.shipmentDetails[0].presentationPeriodFrom);
                    //cmd.Parameters.Add("presentationPeriodOth", locModel.shipmentDetails[0].presentationPeriodOth);

                    //cmd.Parameters.Add("shippingTerms", locModel.shipmentDetails[0].shippingTerms);
                    //cmd.Parameters.Add("insuranceBy", locModel.shipmentDetails[0].insuranceBy);
                    //cmd.Parameters.Add("buyerInsuranceDetails", locModel.shipmentDetails[0].buyerInsuranceDetails);
                    //cmd.Parameters.Add("coverNoteDetails", locModel.shipmentDetails[0].coverNoteDetails);
                    //cmd.Parameters.Add("transportDocType", locModel.transportDocsDetails.transportDocType);

                    //cmd.Parameters.Add("freight", locModel.transportDocsDetails.freight);
                    //cmd.Parameters.Add("freightOthers", locModel.transportDocsDetails.freightOthers);
                    //cmd.Parameters.Add("totalOriginals", locModel.transportDocsDetails.totalOriginals);
                    //cmd.Parameters.Add("originalsRequired", locModel.transportDocsDetails.originalsRequired);
                    //cmd.Parameters.Add("copiesRequired", locModel.transportDocsDetails.copiesRequired);

                    //cmd.Parameters.Add("consignedTo", locModel.transportDocsDetails.consignedTo);
                    //cmd.Parameters.Add("consignedToOthers", locModel.transportDocsDetails.consignedToOthers);
                    //cmd.Parameters.Add("notifyParty", locModel.transportDocsDetails.notifyParty);
                    //cmd.Parameters.Add("docRequired", locModel.documentsDetails.docRequired);
                    //cmd.Parameters.Add("insuranceDocs", locModel.documentsDetails.insuranceDocs);

                    //cmd.Parameters.Add("additionalConditions", locModel.documentsDetails.additionalConditions);
                    //cmd.Parameters.Add("specialConditionBene", locModel.documentsDetails.specialConditionBene);
                    //cmd.Parameters.Add("specialConditionAdv", locModel.documentsDetails.specialConditionAdv);
                    //cmd.Parameters.Add("charges", locModel.instructionsDetails.charges);
                    //cmd.Parameters.Add("chargesOthers", locModel.instructionsDetails.chargesOthers);

                    //cmd.Parameters.Add("chargesAccountNo", locModel.instructionsDetails.chargesAccountNo);
                    //cmd.Parameters.Add("chargesAccountCcy", locModel.instructionsDetails.chargesAccountCcy);
                    //cmd.Parameters.Add("specialInstruction", locModel.instructionsDetails.specialInstruction);
                    //cmd.Parameters.Add("financeRequired", locModel.instructionsDetails.financeRequired);
                    //cmd.Parameters.Add("financeCurrency", locModel.instructionsDetails.financeCurrency);

                    //cmd.Parameters.Add("forwardContractNumber", locModel.instructionsDetails.forwardContractNumber);
                    //cmd.Parameters.Add("typeOfDocument", locModel.additionalDocuments[0].typeOfDocument);
                    //cmd.Parameters.Add("noOfSets", locModel.additionalDocuments[0].noOfSets);
                    //cmd.Parameters.Add("noOfOriginal", locModel.additionalDocuments[0].noOfOriginal);
                    //cmd.Parameters.Add("noOfCopies", locModel.additionalDocuments[0].noOfCopies);
                    //_db.Open();
                    //cmd.ExecuteNonQuery();
                    //_db.Close();

                    //return locModel.header.msgId + " = DBSS_LC_CODE is sucessfull added";
                      cmd.Parameters.Add("msgId", LC_ack.header.msgId);
                      cmd.Parameters.Add("orgId", LC_ack.header.orgId);
                      cmd.Parameters.Add("timeStamp", LC_ack.header.timeStamp);
                      cmd.Parameters.Add("channelId", LC_ack.header.channelId);
                      cmd.Parameters.Add("noOfDocAttached", LC_ack.header.noOfDocAttached);
                      cmd.Parameters.Add("ctry", LC_ack.header.ctry);

                      cmd.Parameters.Add("responseType", LC_ack.txnResponses.responseType);
                      cmd.Parameters.Add("txnRefId", LC_ack.txnResponses.txnRefId);
                      cmd.Parameters.Add("txnStatus", LC_ack.txnResponses.txnStatus);
                      cmd.Parameters.Add("txnRejectCode", LC_ack.txnResponses.txnRejectCode);
                      cmd.Parameters.Add("txnStatusDescription", LC_ack.txnResponses.txnStatusDescription);
                      cmd.Parameters.Add("attachmentRef", LC_ack.txnResponses.attachmentRef);
                      cmd.Parameters.Add("imexReference", LC_ack.txnResponses.imexReference);

                      cmd.Parameters.Add("txnStatusDescription", LC_ack.error.status);
                      cmd.Parameters.Add("txnStatusDescription", LC_ack.error.code);
                      cmd.Parameters.Add("txnStatusDescription", LC_ack.error.description);
                      _db.Open();
                      cmd.ExecuteNonQuery();
                      _db.Close();
                      return LC_ack.header.msgId + " = DBSS_LC_CODE is sucessfull added";
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
           