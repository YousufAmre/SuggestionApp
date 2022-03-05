
namespace SuggestionAppLibrary.DataAccess
{
    public interface ICategoryData
    {
        Task CreateUser(CategoryModel category);
        Task<List<CategoryModel>> GetAllCategories();
    }
}