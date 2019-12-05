using Microsoft.AspNetCore.Mvc;

namespace Course.WebApi.Controllers
{
    
    [Route("[controller]/[Action]")]
    public class TestController: Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}