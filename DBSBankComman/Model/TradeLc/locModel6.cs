using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class locModel6
    {
        public string transportDocType { get; set; }
        public string freight { get; set; }
        public string freightOthers { get; set; }
        public int totalOriginals { get; set; }
        public int originalsRequired { get; set; }
        public int copiesRequired { get; set; }
        public int consignedTo { get; set; }
        public string consignedToOthers { get; set; }
        public string notifyParty { get; set; }
    }
}
