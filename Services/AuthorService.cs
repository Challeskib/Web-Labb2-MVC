using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;
using Web_Labb1_MVC.Models;
using Web_Labb1_MVC.Services.ServiceInterfaces;

namespace Web_Labb1_MVC.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthorService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateAuthorAsync<T>(Author author)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = author,
                Url = StaticDetails.BookApiBase + "/authors",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteAuthorAsync<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/authors/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllAuthors<T>()
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/authors",
                AccessToken = ""
            });
        }

        public async Task<T> GetAuthorById<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/authors/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateAuthorAsync<T>(Author author)
        {
            return await SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = author,
                Url = StaticDetails.BookApiBase + "/authors",
                AccessToken = ""
            });
        }
    }
}
