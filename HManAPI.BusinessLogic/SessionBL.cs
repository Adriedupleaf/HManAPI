using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HManAPI.BusinessLogic.Core;
using HManAPI.BusinessLogic.Interfaces;
using HManAPI.Domain.Entities.User;

namespace HManAPI.BusinessLogic
{
     public class SessionBL : UserApi, ISessionBL
     {
          public ULoginResponse UserLogin(ULoginData data)
          {
               throw new NotImplementedException();
          }

          public ULoginResponse UserRegister(URegisterData data)
          {
               throw new NotImplementedException();
          }
     }
}
