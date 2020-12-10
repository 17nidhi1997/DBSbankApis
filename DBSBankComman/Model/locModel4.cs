using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
   public class locModel4
    {
        public string sendVia { get; set; }
        public DateTime expiryDate { get; set; }
        public string expiryCountry { get; set; }
        public string expiryPlace { get; set; }
        public int lcType { get; set; }
        public string lcCcy { get; set; }
        public int lcAmount { get; set; }
        public string localLcAmtIs { get; set; }
        public int tolCrAmtGoodsQuanPlus { get; set; }
        public int tolCrAmtGoodsQuanMinus { get; set; }
        public int creditAvailableWith { get; set; }
        public string creditAvailableWithOthersName { get; set; }
        public string creditAvailableWithOthersAdd { get; set; }
        public int creditAvailableBy { get; set; }
        public int draftDrawnOn { get; set; }
        public string tenor { get; set; }
        public int tenorDays { get; set; }
        public string tenorPhrase { get; set; }
        public string tenorPhraseOthers { get; set; }
        public DateTime tenorPhraseFxdMat { get; set; }
        public string paymentDetails { get; set; }
        public string creditTransferable { get; set; }
        public string confirmationRequired { get; set; }
        public string confirmationCharges { get; set; }
        public string confirmingBank { get; set; }
        public string confirmingBankAddress { get; set; }
    }
}
