using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Account_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool create(string newAccount)
        {
            return true;
        }

        [HttpGet]
        public string get()
        {
            return "hoppakee";
        }

        [HttpPut]
        public string update(string updatedAccount)
        {
            return "updated";
        }

        [HttpDelete]
        public bool delete(string updatedAccount)
        {
            return true;
        }

    }
}
