using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DBSBankManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DBSBankAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LCPullController : ControllerBase
    {
        private IManagerLC_ACK _Manager;      
        public LCPullController(IManagerLC_ACK manager)
        {
            this._Manager = manager;
        }


        [HttpGet]
        public IActionResult Getdba()
        {
            string message;
            /*  var result =this._Manager.DBSStatus();
              if (!result.Equals(null))
              {
                  var json = JsonConvert.SerializeObject(result);

                  var data = new StringContent(json);
                  string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                  //Console.WriteLine(jsonString);
                  var url = "https://httpbin.org/post"; 

                  using var client = new HttpClient();
                  var response = await client.PostAsync(url,data);

                  string results = response.Content.ReadAsStringAsync().Result;
                 // Console.WriteLine(results);

                  message = "ouput";
                  return this.Ok(new { message, result });
              }*/
            message = "something went working .!!";
            return BadRequest(new { message });
        }
    }
}
    

