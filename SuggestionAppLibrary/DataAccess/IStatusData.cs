
namespace SuggestionAppLibrary.DataAccess
{
    public interface IStatusData
    {
        Task CreateUser(StatusModel category);
        Task<List<StatusModel>> GetAllStatuses();
    }
}