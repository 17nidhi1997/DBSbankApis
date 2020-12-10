using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class locModel5
    {
        public string goodsDescription { get; set; }
        public string placeOfReceipt { get; set; }
        public string portOfLoading { get; set; }
        public string portOfDischarge { get; set; }
        public string placeOfDelivery { get; set; }
        public string partialShipmentAllowed { get; set; }
        public string transhipmentAllowed { get; set; }
        public DateTime latestShipmentDate { get; set; }
        public string shipmentPeriod { get; set; }
        public int presentationPeriod { get; set; }
        public string presentationPeriodFrom { get; set; }
        public string presentationPeriodOth { get; set; }
        public string shippingTerms { get; set; }
        public string insuranceBy { get; set; }
        public string buyerInsuranceDetails { get; set; }
        public string coverNoteDetails { get; set; }
    }
}
