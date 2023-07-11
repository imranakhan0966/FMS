//using COI.Application.DTOs;
using Ozone.Infrastructure.Persistence.Models;
//using COI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared
{
    public class UserService
    {
        List<SecUser> users = new List<SecUser>();
        public SecUser GetUser(string userName)
        {
            return users.Find(u => u.UserName == userName);
        }

        public bool CreateUser(string userName, string password, string EmailAddress, string FullName)
        {
            if (GetUser(userName) == null)
            {
                SecUser newUser = new SecUser();
                newUser.UserName = userName;
                newUser.Password = password;
                newUser.Email = EmailAddress;
                newUser.FullName = FullName;
                users.Add(newUser);
            }
            return true;
        }

        //public bool CreateUser(SecUserModel userModel)
        //{
        //    if (GetUser(userName) == null)
        //    {
        //        SecUser newUser = new SecUser();
        //        newUser.UserName = userName;
        //        newUser.Password = password;
        //        newUser.Email = EmailAddress;
        //        newUser.FullName = FullName;
        //        users.Add(newUser);
        //    }
        //    return true;
        //}

        //public bool DeleteUser(long id)
        //{

        //    try
        //    {
        //        var DataList = users.GetAll().Where(x => x.id == id).ToList();
        //        foreach (var item in DataList)
        //        {
        //            users.Delete(item);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return true;
        //    }

        //}

    }
}
