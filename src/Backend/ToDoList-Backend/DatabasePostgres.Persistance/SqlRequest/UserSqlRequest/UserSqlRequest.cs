

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id SERIAL PRIMARY KEY, Login TEXT UNIQUE, Password TEXT,Email TEXT UNIQUE,Role TEXT, Created DATE);";

        public string UserAdd = $"INSERT INTO Users (login,password,email,role,Created)" +
             "VALUES (@Login,@Password,@Email,@Role,@Created)";

        public string GetByUserInfo = "SELECT login,password,email,role FROM Users WHERE login = @login;";
    }
}
