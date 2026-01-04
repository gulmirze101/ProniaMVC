namespace Pronia.ViewModels.ProductViewModels
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<int> TagIds { get; set; }

        [Required]
        public IFormFile MainImage { get; set; } = null!;

        public IFormFile? HoverImage { get; set; }

        public List<IFormFile> Images { get; set; } = [];
    }
}
