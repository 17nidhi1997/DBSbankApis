using DBSBankComman.Model;
using DBSBankManager.Manage;
using DBSBankRepo.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankManager.ManagerImplementations
{
    public class ManagerImplementation_PushAdvice : IManagerPush_Advice
    {
        private IRepoPA _IManager;
        public ManagerImplementation_PushAdvice(IRepoPA dBS)
        {
            _IManager = dBS;
        }
        public object pushAdvice_responce(pushAdvice push_Advice)
        {
            return this._IManager.pushAdvice_responce(push_Advice);
        }
    }
}
