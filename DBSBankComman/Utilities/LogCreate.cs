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
        public static void LogWrite(LogEventLevel lev, string className, string methodName, Exception ex, string Msg)
        {
            try
            {
                Log.Write(LogEventLevel.Information, "********************************* Date and Time : " + DateTime.Now + "*********************************");

                if (ex != null)
                {
                    Log.Write(lev, ex, " Method : " + methodName + " Error Msg : " + ex.Message + " Operation Message : " + Msg);

                    if (ex.InnerException != null)
                    {
                        Log.Write(LogEventLevel.Error, ex, className + " : " + methodName + " : " + " Inner Exception " + ex.InnerException);
                    }
                }
                else
                {

                    Log.Write(lev, className + " : " + methodName + " : " + Msg);
                }

                Log.Write(LogEventLevel.Information, "***********************************END***********************************************");
            }
            catch (Exception ex1)
            {
                Log.Write(LogEventLevel.Fatal, "LogCreateClass - " + ex1, "Error in LogCreate class: " + ex1.Message);
            }
        }
    }
}

