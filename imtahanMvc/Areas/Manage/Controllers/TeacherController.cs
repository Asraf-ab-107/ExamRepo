using imtahanMvc.Areas.Manage.Controllers.Base;
using imtahanMvc.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imtahanMvc.Areas.Manage.Controllers
{
    public class TeacherController : BaseController
    {
        AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.Include(p=>p.Position).ToList();
            return View(teachers);
        }



    }
}
