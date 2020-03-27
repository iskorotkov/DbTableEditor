using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Auth
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
