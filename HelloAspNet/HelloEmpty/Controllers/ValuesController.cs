using HelloEmpty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelloEmpty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public List<HelloMessage> get()
        {
            List<HelloMessage> messages = new List<HelloMessage>();
            messages.Add(new HelloMessage() { Message = "Hellow Web Api 1!" });
            messages.Add(new HelloMessage() { Message = "Hellow Web Api 2!" });
            messages.Add(new HelloMessage() { Message = "Hellow Web Api 3!" });

            return messages;
        }
    }
}
