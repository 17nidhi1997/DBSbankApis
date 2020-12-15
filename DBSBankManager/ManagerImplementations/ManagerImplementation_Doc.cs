using DBSBankManager.Manage;
using DBSBankRepo.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankManager.ManagerImplementations
{
    public class ManagerImplementation_Doc : IManagerDOC
    {
        private IRepoDOC _IManager;
        public ManagerImplementation_Doc(IRepoDOC dBS)
        {
            _IManager = dBS;
        }
        public object DOCDetails()
        {
            return this._IManager.DOCDetails();
        }
    }
}
