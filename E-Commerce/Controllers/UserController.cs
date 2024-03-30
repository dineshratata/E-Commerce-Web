using ApplicationLayer.ApplicationConstants;
using ApplicationLayer.Common;
using ApplicationLayer.InputModels;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private APIResponse _apiResponse;

        public UserController(IAuthService authservice)
        {
            _authService = authservice;
            _apiResponse = new APIResponse();
        }




        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> Register(Register register)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    _apiResponse.AddError(ModelState.ToString());
                    _apiResponse.DisplayMessage = CommonMessage.RegisterFail;
                    return _apiResponse;    
                }



                var user = await _authService.Register(register);


                _apiResponse.StatusCodes = HttpStatusCode.Created;
                _apiResponse.DisplayMessage = CommonMessage.RegisterSuccess;
                _apiResponse.Issuccess = true;
                


            }
            catch (Exception)
            {

                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                
                _apiResponse.AddError(CommonMessage.SystemError);
            }

            return Ok(_apiResponse);
        }



        [HttpPost]
        [Route("Login")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> Login(Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.AddError(ModelState.ToString());
                    _apiResponse.DisplayMessage = CommonMessage.RegisterFail;
                    return _apiResponse;



                }




                var user = await _authService.Login(login);


                if (user is string)
                {

                    _apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                    _apiResponse.DisplayMessage = CommonMessage.LoginFail;
                    _apiResponse.Result = user;
                    return _apiResponse;
                   

                }



                _apiResponse.StatusCodes = HttpStatusCode.OK;
                _apiResponse.DisplayMessage = CommonMessage.LoginSuccess;
                _apiResponse.Issuccess = true;



            }
            catch (Exception)
            {

                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;

                _apiResponse.AddError(CommonMessage.SystemError);
            }

            return Ok(_apiResponse);
        }



    }
}
