using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JWTIdentity.API.Controllers
{
    public class TestController : Controller
    {
       


        public async Task<IActionResult> Index()
        {
           
            return View();
        }
    }
}
