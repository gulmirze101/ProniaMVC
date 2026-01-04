using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Contexts;
using Pronia.Models;
using Pronia.ViewModels.ServiceFeatureViewModels;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class ServiceFeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ServiceFeatureController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var features = await _context.ServiceFeatures.ToListAsync();
            return View(features);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceFeatureCreateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (!vm.Icon.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Icon", "File şəkil formatında olmalıdır!");
                return View(vm);
            }

            if (vm.Icon.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Icon", "File ölçüsü maksimum 2MB ola bilər!");
                return View(vm);
            }

            string fileName = Guid.NewGuid() + vm.Icon.FileName;
            string path = Path.Combine(
                _environment.WebRootPath,
                "assets", "images", "website-images",
                fileName
            );

            using FileStream stream = new(path, FileMode.Create);
            await vm.Icon.CopyToAsync(stream);

            ServiceFeature feature = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                IconPath = fileName
            };

            await _context.ServiceFeatures.AddAsync(feature);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var feature = await _context.ServiceFeatures.FindAsync(id);
            if (feature is null) return NotFound();

            _context.ServiceFeatures.Remove(feature);
            await _context.SaveChangesAsync();

            string iconPath = Path.Combine(
                _environment.WebRootPath,
                "assets", "images", "website-images",
                feature.IconPath
            );

            if (System.IO.File.Exists(iconPath))
            {
                System.IO.File.Delete(iconPath);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var feature = await _context.ServiceFeatures.FindAsync(id);
            if (feature is null) return NotFound();

            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServiceFeature feature)
        {
            if (!ModelState.IsValid)
                return View(feature);

            var existFeature = await _context.ServiceFeatures.FindAsync(feature.Id);
            if (existFeature is null) return NotFound();

            existFeature.Title = feature.Title;
            existFeature.Description = feature.Description;
           

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Info(int id)
        {
            var feature = await _context.ServiceFeatures.FindAsync(id);
            if (feature is null) return NotFound();

            return View(feature);
        }
    }

}
