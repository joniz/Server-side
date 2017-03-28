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
        private Account account;
        public CustomPrincipal(Account account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.Username);
        }

        public IIdentity Identity{ get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            foreach(var roli in roles)
            {
                if(roli == "megaAdmin" && this.account.Rank > 1)
                {
                    return true;
                }else if (roli == "admin" && this.account.Rank == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
