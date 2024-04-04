using MovieCatalog.BLL.Models;

namespace MovieCatalog.WebAPI.Validation
{
    public static class CategoryValidator
    {
        public static string Validation(CategoryModel model)
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
