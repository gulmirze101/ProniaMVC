namespace Pronia.ViewModels.ProductViewModels
{
    public class ProductUpdateVM
    {
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IFormFile? NewMainImage { get; set; }  
        public IFormFile? NewHoverImage { get; set; }  

        public string CurrentMainImagePath { get; set; } = null!;
        public string? CurrentHoverImagePath { get; set; }

        public List<int> TagIds { get; set; }

        public IFormFile? MainImage { get; set; }
        public IFormFile? HoverImage { get; set; }
        public string? MainImagePath { get; set; }
        public string? HoverImagePath { get; set; }
        public ICollection<IFormFile>? Images { get; set; } = [];
        public List<string>? ImagePaths { get; set; } = [];
        public List<int>? ImagePathsIds { get; set; } = [];
    }

}
