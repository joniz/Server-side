using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using repository.EntityModel;
using AutoMapper;
using repository;




namespace service.Models
{
    public class Account
    {
        [Display(Name = "userName")]
        public string Username { get; set; }
        [Display(Name = "passWord")]
        public string Password { get; set; }
        public string Rank { get; set; }
        public string Salt { get; set; }

        static private EAccount e_Account = new EAccount();

        static public List<Account> getAccountList()
        {
            return Mapper.Map<List<ACCOUNT>, List<Account>>(e_Account.getAccountList()); 
        }

        public Account find(string userName)
        {
            return new Account();//listAccounts.Where(acc => acc.Username.Equals(userName)).FirstOrDefault();
        }
        public Account logIn(string userName, string passWord)
        {
            return new Account(); //listAccounts.Where(acc => acc.Username.Equals(userName) && acc.Password.Equals(passWord)).FirstOrDefault();
        }
        static public Account getAccount(string userName)
        {
            return Mapper.Map<Account>(e_Account.getAccountByUserName(userName));
                
        }
        static public void editAccount(Account accObj)
        {
            e_Account.editAccount(Mapper.Map<ACCOUNT>(accObj));
            
        }
        static public bool logInAccount(Account accObj)
        {
            return e_Account.logInAccount(Mapper.Map<ACCOUNT>(accObj));
        }
       




    }
}
