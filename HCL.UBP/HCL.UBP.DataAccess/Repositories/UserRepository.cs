using HCL.UBP.DataAccess.Interface;
using HCL.UBP.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace HCL.UBP.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        [Dependency]
        public UBPDbContext DbContext { get; set; }
        public bool CreateUser(UserDetails input)
        {
            try
            {
                DbContext.UserDetails.Add(input);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: ILogger
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                UserDetails user = DbContext.UserDetails.Find(id);
                DbContext.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: ILogger
                throw new Exception(ex.Message);
            }
        }

        public UserDetails GetUser(int id)
        {
            try
            {
                return DbContext.UserDetails.Where(s => s.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //TODO: ILogger
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<UserDetails> GetUsers()
        {
            try
            {
                return DbContext.UserDetails.ToList();
            }
            catch (Exception ex)
            {
                //TODO: ILogger
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUser(UserDetails input)
        {
            try
            {
                DbContext.Entry(input).State = System.Data.Entity.EntityState.Modified;
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: ILogger
                throw new Exception(ex.Message);
            }
        }
    }
}
