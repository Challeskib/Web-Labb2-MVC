using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;

namespace Web_Labb1_MVC.Services.ServiceInterfaces
{
    public interface IAuthorService
    {
        Task<T> GetAllAuthors<T>();

        Task<T> GetAuthorById<T>(int id);

        Task<T> CreateAuthorAsync<T>(Author author);
        Task<T> UpdateAuthorAsync<T>(Author author);

        Task<T> DeleteAuthorAsync<T>(int id);
    }
}
