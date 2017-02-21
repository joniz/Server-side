using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Models;
namespace service.Mockups
{
    class administratorMockup
    {
        public static List<Administrator> _administratorList = new List<Administrator>
        {
            new Administrator {_admId = 1, _admUserName = "olofAdmin", _admPassWord = "Hej" }
        };


    }
}
