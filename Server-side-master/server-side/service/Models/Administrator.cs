using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;

namespace service.Models
{
   public class Administrator
    {
        public int _admId { get; set; }
        public string _admUserName { get; set; }
        public string _admPassWord { get; set; }

        public static List<Administrator> getAdministratorList()
        {
            return Mockups.administratorMockup._administratorList;


        }



    }
}
