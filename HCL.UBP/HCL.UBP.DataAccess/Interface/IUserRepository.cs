using HCL.UBP.DataAccess.Model;
using System.Collections.Generic;

namespace HCL.UBP.DataAccess.Interface
{
    public interface IUserRepository
    {
        bool CreateUser(UserDetails input);

        bool DeleteUser(int id);

        UserDetails GetUser(int id);

        IEnumerable<UserDetails> GetUsers();

        bool UpdateUser(UserDetails input);
    }
}
