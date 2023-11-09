using TaskList_Frontend.Services.TaskListApi.Models;

namespace TaskList_Frontend.Services.TaskListApi.Interface
{
    public interface IUserControllers
    {
        Task<string> Registration(UserRegistrationModel userRegistration);
        Task<string> Authorization(UserAuthorizationModel userAuthorization);
    }
}
