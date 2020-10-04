using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
{
    public interface IVideoService
    {
        Task<bool> VideoInsert(Video video);
    }
}