using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;
using Web_Labb1_MVC.Models;
using Web_Labb1_MVC.Services.ServiceInterfaces;

namespace Web_Labb1_MVC.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _clientFactory;
        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateBookAsync<T>(BookDto bookDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = bookDto,
                Url = StaticDetails.BookApiBase + "/books",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/books/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/books/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(EditBookDto book)
        {
            return await SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = book,
                Url = StaticDetails.BookApiBase + "/books",
                AccessToken = ""
            });
        }
    }
}
