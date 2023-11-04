using DatabasePostgres.Persistance.Dto;


namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(string Login,string Password,string Email,DateTime Create);
        Task<UserInfoDto> GetByUserId(string Login);
        
    }
}
