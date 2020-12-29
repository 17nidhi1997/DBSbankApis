//using DBSBankComman.Utilities;
using DBSBankComman.Utilities;
using RestSharp;
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
       
       // public static System.Collections.Specialized.NameValueCollection AppSetting { get; }
        public async System.Threading.Tasks.Task<object> RequestAsync(string data)
        {
            try
            {
                //string Uri;
                //var cl = new HttpClient();
                //cl.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);
                //int _TimeoutSec = 90;
                //cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                //string _ContentType = "text/plain";
                //cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                //cl.DefaultRequestHeaders.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                //cl.DefaultRequestHeaders.Add("X-DBS-ORG_ID", "INBLUS01");
                //HttpResponseMessage response;

                //HttpContent _Body = new StringContent(data);

                //_Body.Headers.ContentType = new MediaTypeHeaderValue(_ContentType);

                //response = cl.PostAsync(ConfigurationManager.AppSettings["url"], _Body).Result;


                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "TThe HTTPS request after Result =" + response.StatusCode  +"-------" +response.RequestMessage);


                //var content = response.Content.ReadAsStringAsync().Result;

                //return content;


                //HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);
                //client.

                //HttpRequestMessage request = new HttpRequestMessage()
                //{
                //    Content = new StringContent(data, Encoding.UTF8, "text/plain"),
                //    RequestUri = new Uri(ConfigurationManager.AppSettings["url"]),
                //    Method = HttpMethod.Post
                //};
                //HttpResponseMessage responseMessage = null;


                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                //request.Headers.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                //request.Headers.Add("X-DBS-ORG_ID", "INBLUS01");


                //responseMessage = await client.SendAsync(request);
                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + responseMessage.StatusCode + " " + responseMessage.ToString());
                //string results = await responseMessage.Content.ReadAsStringAsync();

                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "TThe HTTPS request after Result " + results);
                //return results;

                var client = new RestClient("https://testcld-enterprise-api.dbs.com/api/in/doctrade/v4/import/letterofcredit");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                request.AddHeader("X-DBS-ORG_ID", "INBLUS01");
                request.AddHeader("Content-Type", "text/plain");
                request.AddParameter("text/plain", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status = " + response.StatusCode + " " + response.ContentType + "" + response.StatusDescription + "" + response.Content);
                return response.Content;
                //----------------------------
                //var client = new RestClient(ConfigurationManager.AppSettings["LC_URL"]);
                //client.Timeout = -1;
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                //request.AddHeader("X-DBS-ORG_ID", "INBLUS01");
                //request.AddHeader("Content-Type", "text/plain");
                //request.AddParameter("text/plain", data, ParameterType.RequestBody);
                //IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status = " + response.StatusCode + " " + response.ContentType + "" + response.StatusDescription + "" + response.Content);
                //string results = await responseMessage.Content.ReadAsStringAsync();

                // LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "TThe HTTPS request after Result " + results);
                //return response.Content;
                //------------
                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + responseMessage.StatusCode + " " + responseMessage.ToString());
                //string results = await responseMessage.Content.ReadAsStringAsync();
                //results= responseMessage;
                //LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "TThe HTTPS request after Result ="  + results);
                //return results;
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classHttpsRequest", "RequestAsync", exception, "Error occure while sending data through URLs");
                throw exception;

            }
        }


        public async System.Threading.Tasks.Task<object> RequestAsync1(string data)
        {
            try
            {

                var client = new RestClient("https://testcld-enterprise-api.dbs.com/api/in/doctrade/v4/import/financedocument");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                request.AddHeader("X-DBS-ORG_ID", "INBLUS01");
                request.AddHeader("Content-Type", "text/plain");
                request.AddParameter("text/plain", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status = " + response.StatusCode + " " + response.ContentType + "" + response.StatusDescription + "" + response.Content);
                return response.Content;
            }
            catch (Exception exception)
            {
                LogCreate.LogWrite(LogEventLevel.Error, "classHttpsRequest", "RequestAsync", exception, "Error occure while sending data through URLs");
                throw exception;

            }
        }
    }
}

//HttpClient client = new HttpClient();
//HttpRequestMessage request = new HttpRequestMessage()
//{
//    Content = new StringContent(data, Encoding.UTF8, "text/plain"),
//    RequestUri = new Uri(ConfigurationManager.AppSettings["url"]),
//    Method = HttpMethod.Post
//};
// HttpResponseMessage responseMessage = null;


//client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

//request.Headers.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
//request.Headers.Add("X-DBS-ORG_ID", "INBLUS01");


//responseMessage = await client.SendAsync(request);
//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + responseMessage.StatusCode + " " + responseMessage.ToString());
//string results = await responseMessage.Content.ReadAsStringAsync();

//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "TThe HTTPS request after Result " + results);
//return results;




// var url = ConfigurationManager.AppSettings["url"];
//using var client = new HttpClient();             
//client.DefaultRequestHeaders.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
//client.DefaultRequestHeaders.Add("X-DBS-ORG_ID", "INBLUS01");
//client.DefaultRequestHeaders.Add("Content-Type", "text/plain");
////client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
//var response = await client.PostAsync(ConfigurationManager.AppSettings["url"], data);
//string results = response.Content.ReadAsStringAsync().Result;
// return results;
//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request before");

//Console.WriteLine("before");
//HttpClient client = new HttpClient() ;

//HttpRequestMessage request = new HttpRequestMessage()
//{
//    Content =new StringContent(data, Encoding.UTF8, "text/plain"),
//    RequestUri = new Uri(ConfigurationManager.AppSettings["url"]),
//    Method = HttpMethod.Post
//};
//HttpResponseMessage responseMessage = null;
//---------------------
//HttpRequestMessage request = new HttpRequestMessage()
//{
//    Content = new StringContent(data, Encoding.UTF8, "text/plain"),
//    RequestUri = new Uri(ConfigurationManager.AppSettings["url"]),
//    Method = HttpMethod.Post
//};
// request.Headers.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
//request.Headers.Add("X-DBS-ORG_ID", "INBLUS01");
//request.Content.Headers.ContentType.CharSet = "";
////HttpResponseMessage responseMessage = null;
//responseMessage = await client.SendAsync(request);
//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + data + " " +"status code"+ responseMessage.StatusCode +""+responseMessage.ToString());

//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request before");
//string results = await responseMessage.Content.ReadAsStringAsync();
//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request before");
//LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + data + " " + results.ToString());
//Console.WriteLine("before");
//return results;
//--------------------------------------
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                // request.Method = HttpMethod.Post;
                // request.RequestUri = new Uri(ConfigurationManager.AppSettings["url"]);
                //request.Headers.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
                //request.Headers.Add("X-DBS-ORG_ID", "INBLUS01");
                //HttpContent content = new StringContent(data.ToString());

//content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
// request.Content.Headers.Add("Content-Type", "text/plain");
// request.Headers.Add("Content-Type", "text/plain");
//request.Content = new StringContent(data.ToString(), Encoding.UTF8, "text/plain");
// request.Content = data;
//responseMessage = await client.PostAsync();
//responseMessage = await client.SendAsync(request);
//client.DefaultRequestHeaders.Add("x-api-key", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
//client.DefaultRequestHeaders.Add("X-DBS-ORG_ID", "INBLUS01");
// client.DefaultRequestHeaders.Add("Content-Type", "text/plain");

//client.DefaultRequestHeaders.TryAddWithoutValidation("INBLUS01", "6d602f17-c2d7-408d-a00c-066651aa5e1c");
// var responce=await request.
//var response = await client.PostAsync(ConfigurationManager.AppSettings["url"], data);
//responseMessage.StatusCode.CompareTo(response);
// LogCreate.LogWrite(LogEventLevel.Information, "Repo.classHttpsRequest", "classHttpsRequest.RequestAsync", null, "The HTTPS request After Request Status " + data + " " + response.ToString());
//------------;