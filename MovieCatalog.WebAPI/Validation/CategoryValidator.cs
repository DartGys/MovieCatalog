using MovieCatalog.BLL.Models.DtoModels;
using MovieCatalog.BLL.Models.ViewModels;

namespace MovieCatalog.WebAPI.Validation
{
    public static class CategoryValidator
    {
        public static string Validation(CategoryInputModel model)
        {
            string error = string.Empty;

            if(model == null)
            {
                error = "Category model is null";
            }

            else if(string.IsNullOrWhiteSpace(model.Name))
            {
                error = "Category name is empty or whitespace";
            }

            return error;
        }
    }
}
