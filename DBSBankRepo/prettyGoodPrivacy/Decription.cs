using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PgpCore;
//using PgpCore;

namespace DBSBankRepo.prettyGoodPrivacy
{
    public class  Decription
    {
        public object decriptFiles(string httpContent)
        {
            using (PGP pgp = new PGP())
            {
                // Decrypt file
                pgp.DecryptFile(httpContent, @"D:\pgpOperation\FINAL\default.txt", @"D:\pgpOperation\FINAL\IBSFINTECH_0x858175FD_SECRET.asc", "IBSFINTECH");
                string PlainText = File.ReadAllText(@"D:\pgpOperation\FINAL\default1.txt");
                return PlainText;
            }
        }
    }
}