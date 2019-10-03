using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private MainContext _dbContext;
        public AccountController(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getUser")]
        public PersonBaseModel GetUser(string username, string password)
        {
            PersonBaseModel account = _dbContext.Students
                 .SingleOrDefault(a => a.UserName.ToLower() == username.ToLower() && a.Password == password);
            if (account == null) 
            {
                account = _dbContext.Teachers
               .SingleOrDefault(a => a.UserName.ToLower() == username.ToLower() && a.Password == password);
               if(account!=null) account.IsTeacher = true;
            }
            return account;
        }

    }
}
