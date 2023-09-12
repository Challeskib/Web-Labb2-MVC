using Labb1_Minimal_Api.Models;

namespace Web_Labb1_MVC.Services.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<T> GetAllGenres<T>();

        Task<T> GetGenreById<T>(int id);

        Task<T> CreateGenreAsync<T>(Genre genre);
        Task<T> UpdateGenreAsync<T>(Genre genre);

        Task<T> DeleteGenreAsync<T>(int id);
    }
}
