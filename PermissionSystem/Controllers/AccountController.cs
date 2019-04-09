using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PermissionSystem.Business.Entities;
using PermissionSystem.Business.Models;
using PermissionSystem.Business.Repositories.RepositoryWrapper;

namespace PermissionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IConfiguration _config;

        public AccountController(IRepositoryWrapper repoWrapper, IConfiguration config)
        {
            _repoWrapper = repoWrapper;
            _config = config;
        }

        //[Route("Login")]
        //[HttpGet]
        //public Task<IActionResult> Login(LoginModel loginModel)
        //{
        //    try
        //    {
        //        return Ok(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                return Ok(_repoWrapper.Account.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}