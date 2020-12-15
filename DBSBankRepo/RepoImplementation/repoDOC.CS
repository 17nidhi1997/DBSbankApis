using DBSBankComman.Model;
using DBSBankComman.Model.Doc;
using DBSBankComman.Querie;
using DBSBankRepo.IRepo;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBSBankRepo.RepoImplementation
{
    public class repoDOC : IRepoDOC
    {
        private readonly IConfiguration configuration;
        public repoDOC(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object DOCDetails()
        {
            List<docFiles> list = new List<docFiles>();
            var commandText = Queries.LC_Doc;
            using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    docFiles dBS = new docFiles();
                    docFiles1 header = new docFiles1();
                    docFiles2 txnInfo = new docFiles2();
                    docFiles3 documents = new docFiles3();
                    dBS.header = header;
                    dBS.txnInfo = txnInfo;
                    dBS.txnInfo.documents = new List<docFiles3>();
                    dBS.txnInfo.documents.Add(documents);

                    dBS.header.msgId = reader.GetString(0);
                    dBS.header.orgId = reader.GetString(1);
                    dBS.header.timeStamp = reader.GetString(2);
                    dBS.header.channelId = reader.GetString(3);
                    dBS.header.ctry = reader.GetString(4);
                    dBS.txnInfo.attachmentRef = reader.GetString(5);
                    //         list.Add(dBS);

                    //     }


                    var commandText1 = Queries.DOC;
                    // using (var _db = new OracleConnection(configuration.GetConnectionString("UserDbConnection")))
                    using (OracleCommand cmd1 = new OracleCommand(commandText1, _db))
                    {
                        //cmd.Connection = _db;
                        cmd1.CommandType = CommandType.Text;
                        // _db.Open();
                        OracleDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            //docFiles dBS = new docFiles();
                            //docFiles1 header = new docFiles1();
                            //docFiles2 txnInfo = new docFiles2();
                            //docFiles3 documents = new docFiles3();
                            dBS.header = header;
                            dBS.txnInfo = txnInfo;
                            dBS.txnInfo.documents = new List<docFiles3>();
                            dBS.txnInfo.documents.Add(documents);

                            dBS.txnInfo.documents[0].file = (Byte[])(reader1.GetOracleBlob(0)).Value;
                            dBS.txnInfo.documents[0].DOCUMENT_NAME = reader1.GetString(1);
                            list.Add(dBS);
                            //return content;
                        }

                    }
                }
                _db.Close();
                return list;
            }           
        }
    }
}




   