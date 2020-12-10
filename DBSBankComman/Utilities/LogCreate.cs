using DBSBankComman.Model;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Utilities
{
    public static class LogCreate
    {
        public static locModel locmodel;

        public static void LogWrite(LogEventLevel lev, string className, string methodName, Exception ex, string Msg)
        {
            try
            {
                Log.Write(LogEventLevel.Information, "********************************* Date and Time : " + DateTime.Now + "*********************************");

                if (ex != null)
                {
                    string _username = "LoggedUser";
                    if (locmodel.header.msgId != null) { _username = locmodel.header.orgId; }

                    Log.Write(lev, ex, "User : " + _username + " Class : " + className + " Method : " + methodName + " Error Msg : " + ex.Message + " Operation Message : " + Msg);

                    if (ex.InnerException != null)
                    {
                        Log.Write(LogEventLevel.Error, ex, className + " : " + methodName + " : " + " Inner Exception " + ex.InnerException);
                    }
                }
                else
                {
                    Log.Write(lev, className + " : " + methodName + " : " + Msg);
                }
            }
            catch (Exception ex1)
            {
                Log.Write(LogEventLevel.Fatal, "LogCreateClass - " + ex1, "Error in LogCreate class: " + ex1.Message);
            }
        }
    }
}
