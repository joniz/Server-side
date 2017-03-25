using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Models
{
   public class AccountModel
    {


        private List<Account> listAccounts = new List<Account>();

        public AccountModel()
        {
            listAccounts.Add(new Account { userName = "acc1", passWord = "123", roles = new string[] {"megaAdmin", "admin"} });
            listAccounts.Add(new Account { userName = "acc2", passWord = "123", roles = new string[] { "admin" } });
        }
        public Account find(string userName)
        {
            return listAccounts.Where(acc => acc.userName.Equals(userName)).FirstOrDefault();
        }
        public Account logIn(string userName, string passWord)
        {
            return listAccounts.Where(acc => acc.userName.Equals(userName) && acc.passWord.Equals(passWord)).FirstOrDefault();
        }
    }
}
