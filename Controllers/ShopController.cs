using Microsoft.AspNetCore.Mvc;
using Pronia.Contexts;
using Pronia.ViewModels.ProductViewModels;

namespace Pronia.Controllers
{
    public class ShopController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products.Select(x => new ProductGetVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePaths = x.ProductImages.Select(x => x.ImagePath).ToList(),
                CategoryName = x.Category.Name,
                HoverImagePath = x.HoverImagePath,
                MainImagePath = x.MainImagePath,
                Price = x.Price,
                TagNames = x.ProductTags.Select(x => x.Tag.Name).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);

        }
    }
}
