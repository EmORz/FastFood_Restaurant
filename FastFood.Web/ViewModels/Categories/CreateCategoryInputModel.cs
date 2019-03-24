using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [MinLength(3), MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
