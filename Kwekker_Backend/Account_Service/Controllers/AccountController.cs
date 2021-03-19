﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Account_Service.DataAccess;
using Account_Service.Models;
using Account_Service.Repository;

namespace Account_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountDbContext _context;
        private AccountRepository accRepository;

        public AccountController(AccountDbContext context, ILogger<AccountController> logger)
        {
            accRepository = new AccountRepository(context);
            _logger = logger;
        }

        

        [HttpPost]
        public string create([FromBody]Account account)
        {

            //Account account = JsonConvert.DeserializeObject<Account>(json);
            if(accRepository.checkEmail(account.email))
            {
                return "Email is already in use";
            }
            else
            {
                if (accRepository.create(account))
                {
                    return "Success!";
                }
                else
                {
                    return "Database error!";
                }
            }
        }

        [HttpGet]
        public string get([FromBody] Account account)
        {
            return "hoppakee";
        }

        [HttpPut]
        public bool update([FromBody] Account account)
        {
            return accRepository.update(account);
        }

        [HttpDelete]
        public bool delete([FromBody] Account account)
        {
            return accRepository.create(account);
        }

    }
}