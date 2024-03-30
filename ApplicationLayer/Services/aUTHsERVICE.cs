using ApplicationLayer.Common;
using ApplicationLayer.InputModels;
using ApplicationLayer.ServiceRegistration;
using ApplicationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AuthService : IAuthService
    {    
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManger;
        private ApplicationUser _applicationUser;



        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManger)
        {
            _userManager = userManager;
            _applicationUser = new();
            _signManger = signManger;
            
        }

        

        public async Task<IEnumerable<IdentityError>> Register(Register register)
        {

            _applicationUser.FirstName  = register.FirstName;
            _applicationUser.LastName = register.LastName;
            _applicationUser.Email = register.Email;
            _applicationUser.UserName = register.Email;
            
            

         var result     = await  _userManager.CreateAsync(_applicationUser, register.Password ); 

            if (result.Succeeded) { 
            
            
            
            }


            return result.Errors;
        }



        public async Task<object> Login(Login login)
        {
            var Applicationuser = await _userManager.FindByEmailAsync(login.Email);


            if (Applicationuser == null)
            {

                return "Enter Valid Email";

            }


          var result  = await _signManger.PasswordSignInAsync(Applicationuser, login.Password, isPersistent: true,lockoutOnFailure:true);

          var isavalidCredentials = await _userManager.CheckPasswordAsync(Applicationuser, login.Password);

            if(result.Succeeded)
            {

                return true;

            }


            if (result.IsLockedOut)
            {

                return "Your Account Is Locked Contact Admin";


            }


            if(isavalidCredentials==false)
            {
                return "Your Password Is InCorrect";

            }


            return result;
            
        }



    }
}
