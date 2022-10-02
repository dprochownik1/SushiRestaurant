using Sushi.Web.Models;
using Sushi.Web.Models.Dtos;

namespace Sushi.Web.Services.Interfaces
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseDto { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
