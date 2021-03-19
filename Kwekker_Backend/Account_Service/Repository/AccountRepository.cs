using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account_Service.DataAccess;
using Account_Service.Interfaces;
using Account_Service.Models;

namespace Account_Service.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public bool create(Account account)
        {
            try
            {
                using (var context = _context)
                {
                    context.Account.Add(account);
                    context.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            
            return true;
        }

        public Account get(Account account)
        {
            Account acc;
            try
            {
                using (var context = _context)
                {
                    acc = _context.Account
                        .Single(a => a.email == account.email && a.password == account.password);

                }
                return acc;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool checkEmail(string email)
        {
            bool result = false;
            try
            {
                using (var context = _context)
                {
                    var account = _context.Account
                        .Single(a => a.email == email);

                    if(account.ID > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public bool update(Account account)
        {
            try
            {
                using (var context = _context)
                {
                    var acc = _context.Account
                        .Single(a => a.ID == account.ID);
                    acc.email = account.email;
                    acc.password = account.password;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool delete(Account account)
        {
            try
            {
                using (var context = _context)
                {
                    var acc = _context.Account
                        .Single(a => a.ID == account.ID && a.email == account.email && a.password == account.password);

                    context.Account.Remove(acc);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
