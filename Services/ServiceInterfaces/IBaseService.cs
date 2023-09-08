using Labb1_Minimal_Api.Models;
using Web_Labb1_MVC.Models;

namespace Web_Labb1_MVC.Services.ServiceInterfaces
{
    public interface IBaseService : IDisposable
    {
        Models.ApiResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }

}
