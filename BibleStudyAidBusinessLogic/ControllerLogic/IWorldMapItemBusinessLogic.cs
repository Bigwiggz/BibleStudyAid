
namespace BibleStudyAidBusinessLogic.ControllerLogic
{
    public interface IWorldMapItemBusinessLogic
    {
        Task CreatePostBusinessLogic(string geoJSON);
        Task DeletePostBusinessLogic(string geoJSON);
        Task EditPostBusinessLogic(string geoJSON);
        Task<string> IndexBusinessLogic();
        Task PrimaryProjectEditBusinessLogic(string foreignKey);
    }
}