using imtahanMvc.Areas.Manage.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace imtahanMvc.Areas.Manage.Controllers
{
    public class DashBoardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
