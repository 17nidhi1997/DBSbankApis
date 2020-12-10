using DBSBankComman.Utilities;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DBSBankRepo
{
    public class classHttpsRequest
    {
        private string url= "https://testcld-enterprise-api.dbs.com/api/in/doctrade/v4/import/letterofcredit";

        public async System.Threading.Tasks.Task<object> RequestAsync(StringContent data)
        {
            try
            {
                // var data = new StringContent(json);
                // string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                //Console.WriteLine(jsonString);
               // var url = "https://testcld-enterprise-api.dbs.com/api/in/doctrade/v4/import/letterofcredit";
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("INBLUS01", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                //var response = await client.PostAsync(url, data);
                var response = await client.PostAsync(url, data);
                string results = response.Content.ReadAsStringAsync().Result;
                return results;

                /*  HttpResponseMessage httpResponseMessage = await c.SendAsync(req);
                  httpResponseMessage.EnsureSuccessStatusCode();
                  HttpContent httpContent = httpResponseMessage.Content;
                  string responseString = await httpContent.ReadAsStringAsync();

                  Console.WriteLine(responseString);*/

            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classHttpsRequest", "RequestAsync", exception, "Error occure while sending data through URLs");
                throw exception;
            }
        }
    }
}
