using TaskList_Frontend.Services.TaskListApi.Models.Account;

namespace TaskList_Frontend.Services.TaskListApi.Interface
{
    public interface IUserControllers
    {
        void AccountRegistration(UserRegistrationModel userRegistration);
        void Authorization(UserAuthorizationModel userAuthorization);
    }
}
