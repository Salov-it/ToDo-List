using DatabasePostgres.Persistance.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(string Login,string Password,string Email,DateTime Create);
        Task<UserInfoDto> GetByUserId(string Login);
        Task<UserDataVerificationDto> UserDataVerification(string Login,string Email);
    }
}
