using RestAPICompleted.Models;

namespace RestAPICompleted.Helper
{
    public interface IJwtAuth
    {
        string Authentication(Member user);
    }
}
