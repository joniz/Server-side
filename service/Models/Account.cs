using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
    public class Account
    {
        [Display(Name = "userName")]
        public string userName { get; set; }
        [Display(Name = "passWord")]
        public string passWord { get; set; }
        public string[] roles { get; set; }

    }
}
