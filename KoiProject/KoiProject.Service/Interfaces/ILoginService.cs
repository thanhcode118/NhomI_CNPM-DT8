using System.Threading.Tasks;

namespace KoiProject.Service.Interfaces
{
    public interface ILoginService
    {
        bool ValidateUser(string username, string password);

    }
}

