using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace HCL.UBP.DataAccess
{
    public class Program
    {
        public static void Main()
        {
            //IUnityContainer unitycontainer = new Unity.UnityContainer();
            //unitycontainer.RegisterType<Interface.IUserRepository, Repositories.UserRepository>();
            //Repositories.UserRepository user = unitycontainer.Resolve<Repositories.UserRepository>();
            //var result = user.GetUsers();
            //string password = EncryptSource("admin12345");
            //user.CreateUser(new Model.UserDetails {
            //    Id = 0,
            //    Username = "admin12345",
            //    Password = password,
            //    CreationTime = DateTime.Now,
            //    LastModificationTime = DateTime.Now
            //});
            //result = user.GetUsers();
        }

        //private static string EncryptSource(string text)
        //{
        //    byte[] bytes = Encoding.Unicode.GetBytes(text.Trim());
        //    byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        //    return Convert.ToBase64String(inArray);
        //}
    }
}
