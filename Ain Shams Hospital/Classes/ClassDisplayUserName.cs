using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Classes
{
    public static class ClassDisplayUserName
    {
        public static string user;
        public static void getusername (string email)
        {
            user = email;
        }
    }
}
