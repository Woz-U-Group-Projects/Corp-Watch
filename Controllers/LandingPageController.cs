using System.Collections.Generic;
using Corp_Watch.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corp_Watch.Controllers
{
    [Route("api/[controller]")]
    public class LandingPageController: Controller
    {
        private List<LandingPage> LandingPage = new List<LandingPage>();
        public LandingPageController(){
            LandingPage.Add(new LandingPage{
                Id = 1,
                Title = "Corp-Watch",
                Description = "Keep a watchful eye on your operation!"
            });
        
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Json(LandingPage);
        }  
        
    }
}