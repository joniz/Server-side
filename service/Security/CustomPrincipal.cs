﻿using System;
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
        private AccountModel am = new AccountModel();
        public CustomPrincipal(Account userName)
        {
            this.Account = userName;
            this.Identity = new GenericIdentity(userName.userName);
        }

        public IIdentity Identity{ get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.roles.Contains(r));
        }

    }
}
