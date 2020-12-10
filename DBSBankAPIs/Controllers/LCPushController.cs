using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using DBSBankComman.Model;
using DBSBankManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DBSBankAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LCPushController :  Attribute, IAuthorizationFilter
    {
        public IManagerLC_ACK _Manager;

        public LCPushController(IManagerLC_ACK manager)
        {
            this._Manager = manager;
        }

       

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var bodyStr = "";
            var req = context.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
          //  req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }

            // Rewind, so the core is not lost when it looks the body for the request
            req.Body.Position = 0;

            // Do whatever work with bodyStr here


        }
    }

    /*   [HttpPost]
       [Route("AddtoDatabase")]
       public IActionResult AddtoDatabase(locModel locModel)
       {
           string message;
           var result = this._Manager.AddtoDatabase(locModel);
           if (!result.Equals(null))
           {

               //string json = JsonConvert.SerializeObject(locModel);
              //System.IO.File.WriteAllText(@"C:\Users\IBS\Desktop\DBSAPI\New folder\abc.txt ", json);
               message = "added successfully.";
               return this.Ok(new { message, result });
           }
           message = "Please insert correct details.!!";
           return BadRequest(new { message });
       }*/
}

