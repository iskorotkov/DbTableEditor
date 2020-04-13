using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Services.Auth
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
