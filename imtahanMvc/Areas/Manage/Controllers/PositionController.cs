using imtahanMvc.Areas.Manage.Controllers.Base;
using imtahanMvc.DAL;
using imtahanMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace imtahanMvc.Areas.Manage.Controllers
{
    public class PositionController : BaseController
    {
        AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var positions = _context.Positions.ToList();
            return View(positions);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Positions.Add(position);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var position = _context.Positions.FirstOrDefault(p => p.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }
        [HttpPost]
        public IActionResult Update(Position newPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var oldPosition = _context.Positions.FirstOrDefault(p=>p.Id == newPosition.Id);
            if (oldPosition == null)
            {
                return NotFound();
            }
            oldPosition.Name = newPosition.Name;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var position = _context.Positions.FirstOrDefault(p=>p.Id == id); 
            if (position == null)
            {
                return NotFound();
            }
            _context.Positions.Remove(position);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}
