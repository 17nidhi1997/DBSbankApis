using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class locModel2
    {
        public string txnType { get; set; }
        public string accountNumber { get; set; }
        public string ccy { get; set; }
        public locModel3 partiesInfo { get; set; }
        public locModel4 txnDetails { get; set; }
        public locModel5 shipmentDetails { get; set; }
        public List<locModel6> transportDocsDetails { get; set; }
        public locModel7 documentsDetails { get; set; }
        public locModel8 instructionsDetails { get; set; }
        public List<locModel9> additionalDocuments { get; set; }
    }
}
