using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;
using Web_Labb1_MVC.Models;

namespace Web_Labb1_MVC.Services.ServiceInterfaces
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();

        Task<T> GetBookById<T>(int id);

        Task<T> CreateBookAsync<T>(BookDto book);
        Task<T> UpdateBookAsync<T>(EditBookDto book);

        Task<T> DeleteBookAsync<T>(int id);
    }
}