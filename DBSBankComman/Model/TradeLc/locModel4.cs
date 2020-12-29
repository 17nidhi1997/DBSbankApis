using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
   public class locModel4
    {
        public string sendVia { get; set; }
        public string expiryDate { get; set; }
        public string expiryCountry { get; set; }        
        public string lcType { get; set; }
        public string lcCcy { get; set; }
        public string expiryPlace { get; set; }
        public string lcAmount { get; set; }
        public string localLcAmtIs { get; set; }
        public string tolCrAmtGoodsQuanPlus { get; set; }
        public string tolCrAmtGoodsQuanMinus { get; set; }
        public string creditAvailableWith { get; set; }
        public string creditAvailableWithOthersName { get; set; }
        public string creditAvailableWithOthersAddress { get; set; }
        public string creditAvailableBy { get; set; }
        public string draftDrawnOn { get; set; }
        public string tenor { get; set; }
        public string tenorDays { get; set; }
        public string tenorPhrase { get; set; }
        public string tenorPhraseOthers { get; set; }
        public string tenorPhraseFxdMat { get; set; }
        public string paymentDetails { get; set; }
        public string creditTransferable { get; set; }
        public string confirmationRequired { get; set; }
        public string confirmationCharges { get; set; }
        public string confirmingBank { get; set; }
        public string confirmingBankAddress { get; set; }
    }
}
