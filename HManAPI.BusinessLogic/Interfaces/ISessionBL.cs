using HManAPI.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManAPI.BusinessLogic.Interfaces
{
     public interface ISessionBL
     {
          ULoginResponse UserLogin(ULoginData data);
          ULoginResponse UserRegister(URegisterData data);
     }
}
