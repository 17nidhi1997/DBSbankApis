using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
   public  class TradeIBLCcs
    {
        public string msgId { get; set; }
        public string orgId { get; set; }
        public string timeStamp { get; set; }
        public string channelId { get; set; }
        public string ctry { get; set; }
        public string noOfDocAttached { get; set; }
        public string txnType { get; set; }
        public string accountNumber { get; set; }
        public string ccy { get; set; }
        public string billCategory { get; set; }
        public string bankReference { get; set; }
        public string customerReference { get; set; }
        public string discrepancy { get; set; }
        public string billCcy { get; set; }
        public string billAmount { get; set; }
        public string billOutstandingAmount { get; set; }
        public string response { get; set; }
        public string conditions { get; set; }
        public string importBillRef { get; set; }
        public string settlementOptions { get; set; }
        public string settlementAccountNoCcy { get; set; }
        public string settlementAmt { get; set; }
        public string settlementBoardRateAmt { get; set; }
        public string settlementForwardContractNumber { get; set; }
        public string settlementForwardContractAmtUse { get; set; }
        public string amtToFinance { get; set; }
        public string financingCcy { get; set; }
        public string financePeriod { get; set; }
        public string financeBoardRateAmt { get; set; }
        public string financingForwardContractNumber { get; set; }
        public string financingForwardContractAmtUse { get; set; }
        public string accountNumberCcy { get; set; }
        public string contactPerson { get; set; }
        public string contactNumber { get; set; }
        public string specialInstructions { get; set; }
        public string typeOfDocument { get; set; }
        public string noOfSets { get; set; }
        public string noOfOriginal { get; set; }
        public string noOfCopies { get; set; }

    }
}
