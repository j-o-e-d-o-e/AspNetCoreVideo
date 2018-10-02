using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVideo.Controllers
{
    [Route("company/[controller]/[action]")]
    public class EmployeeController : Controller
    {
//        [Route("")]
//        [Route("[action]")]
        public string index()
        {
            return "Hello from Employee";
        }

//        [Route("[action]")]
        public ContentResult Name()
        {
            return Content("Jonas");
        }

//        [Route("[action]")]
        public string Country()
        {
            return "Sweden";
        }
    }
}