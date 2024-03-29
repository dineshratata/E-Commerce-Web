using ApplicationLayer.Common;
using ApplicationLayer.InputModels;
using ApplicationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        ApplicationUser ApplicationUser;


        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            ApplicationUser = new();
            
        }

        public async Task<IEnumerable<IdentityError>> Register(Register register)
        {
              
            ApplicationUser.FirstName  = register.FirstName;    
            ApplicationUser.LastName = register.LastName;
            ApplicationUser.Email = register.Email;
            ApplicationUser.UserName = register.Email;
            
            

         var result     = await  _userManager.CreateAsync(ApplicationUser,register.Password ); 

            if (result.Succeeded) { 
            
            
            
            }


            return result.Errors;
        }

        


    }
}
