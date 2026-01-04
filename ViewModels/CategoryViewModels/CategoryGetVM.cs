using Microsoft.AspNetCore.Mvc;

namespace Pronia.ViewModels.CategoryViewModels
{
    public class CategoryGetVM : Controller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
