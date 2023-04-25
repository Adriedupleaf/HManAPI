using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HManAPI.BusinessLogic.Interfaces;

namespace HManAPI.BusinessLogic
{
    public class BussinesLogic
    {
        public ISessionBL GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
