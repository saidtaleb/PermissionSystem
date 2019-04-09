using PermissionSystem.Business.Context;
using PermissionSystem.Business.Entities;
using PermissionSystem.Business.Enum;
using PermissionSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PermissionSystem.Business.Outils.Password;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace PermissionSystem.Business.Repositories.Account
{
    public class AccountRepository : RepositoryBase<User>, IAccountRepository
    {
        private readonly IPasswordCrypt _passwordCrypt;
        private readonly IConfiguration _configuration;

        public AccountRepository(AppInoContext repositoryContext, IPasswordCrypt passwordCrypt, IConfiguration configuration) : base(repositoryContext)
        {
            _passwordCrypt = passwordCrypt;
            _configuration = configuration;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                Create(user);
                await SaveAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginResponseModel> Login(LoginModel loginModel)
        {
            try
            {
                var existUsername = await AppInoContext.Users.Where(x => x.Username == loginModel.Username).CountAsync() > 0;
                if (existUsername)
                {
                    var existUser = await AppInoContext.Users.Where(x => x.Username == loginModel.Username && _passwordCrypt.VerifyPassword(x.Password, loginModel.Username)).FirstOrDefaultAsync();

                    if (existUser != null)
                    {
                        return new LoginResponseModel()
                        {
                            Token = GetToken(existUser.Id.ToString()),
                            Statut = StatutResponseLogin.SUCCESS
                        };
                    }
                    else
                    {
                        return new LoginResponseModel()
                        {
                            Token = "",
                            Statut = StatutResponseLogin.PASSWORD_INCORRECT
                        };
                    }
                }
                else
                {
                    return new LoginResponseModel()
                    {
                        Token = "",
                        Statut = StatutResponseLogin.COMPTE_DOES_NOT_EXIST
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetToken(string IdUser)
        {
            try
            {
                //symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("securityKey").Value));

                //signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                //add claims
                var claims = new List<Claim>();
                claims.Add(new Claim("Id", IdUser));

                //create token
                var token = new JwtSecurityToken(
                        issuer: "smesk.in",
                        audience: "readers",
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials,
                        claims: claims
                    );

                //return token
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
