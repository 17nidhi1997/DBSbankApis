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
    }
}
