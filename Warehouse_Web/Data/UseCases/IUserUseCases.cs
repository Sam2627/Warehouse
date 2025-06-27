using System.Security.Claims;

namespace Warehouse_Web.Data.UseCases
{
    public interface IUserUseCases
    {
        Task<string> GetUserName();
    }
}
