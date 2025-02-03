using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloEmpty.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            HelloMessage msg = new HelloMessage()
            {
                Message = "Wellcom to Asp.Net MVC !"
            };

            ViewBag.Noti = "Input message and click submit";

            return View(msg);
        }
    

        //post를 처리하는 index
        [HttpPost]
        public IActionResult Index(HelloMessage obj)
        {
            ViewBag.Noti = "Message Changed";
            return View(obj);
        }
    }

}