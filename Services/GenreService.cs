using Labb1_Minimal_Api.Models;
using Web_Labb1_MVC.Models;
using Web_Labb1_MVC.Services.ServiceInterfaces;

namespace Web_Labb1_MVC.Services
{
    public class GenreService : BaseService, IGenreService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GenreService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateGenreAsync<T>(Genre genre)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = genre,
                Url = StaticDetails.BookApiBase + "/genres",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteGenreAsync<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/genres/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllGenres<T>()
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/genres",
                AccessToken = ""
            });
        }

        public async Task<T> GetGenreById<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/genres/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateGenreAsync<T>(Genre genre)
        {
            return await SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = genre,
                Url = StaticDetails.BookApiBase + "/genres",
                AccessToken = ""
            });
        }
    }
}
