using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Contexts;
using Pronia.Models;
using System.Threading.Tasks;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class SliderController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid){
                return View();
            }

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);

            if (slider is null)
            {
                return NotFound();
            }
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Update(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);

            if(slider is not { })
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Slider slider)
        {
            if(!ModelState.IsValid) { 
                return View(); 
            }
            var existSlider = await _context.Sliders.FindAsync(slider.Id);

            if (existSlider is null)
            {
                return BadRequest();
            }

            existSlider.Title = slider.Title;
            existSlider.Description = slider.Description;
            existSlider.OfferPercentage = slider.OfferPercentage;
            existSlider.ImagePath = slider.ImagePath;

            _context.Sliders.Update(existSlider);
            await _context.SaveChangesAsync();
            return Json(slider);
        }
    }

}
