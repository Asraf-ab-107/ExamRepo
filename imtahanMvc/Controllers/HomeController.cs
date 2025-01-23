
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace imtahanMvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
