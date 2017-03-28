using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using service.Models;

namespace service.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account Username)
        {
            this.Account = Username;
            this.Identity = new GenericIdentity(Username.Username);
        }

        public IIdentity Identity{ get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            foreach(var roli in roles)
            {
                if(roli == "megaAdmin" && this.Account.Rank > 1)
                {
                    return true;
                }else if (roli == "admin" && this.Account.Rank == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
