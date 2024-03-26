using ApplicationLayer.ApplicationConstants;
using ApplicationLayer.Common;
using ApplicationLayer.Dto.Category;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using Azure.Core;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;



namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        protected APIResponse _apiResponse;



        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _apiResponse = new();


        }



        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet]
        public async Task<ActionResult> Get()

        {

            try
            {
                var categories = await _categoryService.GetAllAsync();
                _apiResponse.StatusCodes = HttpStatusCode.OK;
                _apiResponse.Issuccess = true;
                _apiResponse.Result = categories;





            }
            catch (Exception)
            {  
                
                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;



            }



            return Ok(_apiResponse);

        }





        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto)

        {
            try
            {
                //if (!ModelState.IsValid)
                //{

                //    _apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                //    _apiResponse.AddError(ModelState.ToString());





                //}
                //var addedEntity = await _categoryService.CreateAsync(dto);
                //_apiResponse.Result = addedEntity;
                //_apiResponse.StatusCodes = HttpStatusCode.Created;
                //_apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;

                var adde    = await _categoryService.CreateAsync(dto);
                
                



            }
            catch (Exception)
            {
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationFailed;
                _apiResponse.AddError(CommonMessage.SystemError);





            }


            return Ok(_apiResponse);
        }



        [HttpGet]
        [Route("Details")]


        public async Task<ActionResult> GetByid(int id)
        {

            try
            {



                var uniqueData = await _categoryService.GetByIdAsync(id);

                if (uniqueData == null)
                {
                    _apiResponse.StatusCodes = HttpStatusCode.NotFound;
                    _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;


                }
                _apiResponse.StatusCodes = HttpStatusCode.OK;
                _apiResponse.Result = uniqueData;


            }
            catch (Exception)
            {
                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                _apiResponse.AddError(CommonMessage.SystemError);

            }






            return Ok(_apiResponse);

        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult<APIResponse>> Delete(int id)
        {

            try
            {

                if (id == 0)
                {
                    _apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                    _apiResponse.Issuccess = false;
                    _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;


                }

                var gottenEntity = await _categoryService.GetByIdAsync(id);

                if (gottenEntity == null)
                {

                    _apiResponse.StatusCodes = HttpStatusCode.NotFound;
                    _apiResponse.Issuccess = false;
                    _apiResponse.DisplayMessage = CommonMessage.SystemError;




                }

                await _categoryService.DeleteAsync(id);
                _apiResponse.StatusCodes = HttpStatusCode.OK;
                _apiResponse.DisplayMessage = CommonMessage.DeleteOperationSuccess;






            }
            catch (Exception)
            {

                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                _apiResponse.AddError(ModelState.ToString());

            }





            return Ok(_apiResponse);


        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult> Update([FromBody] UpdateCategoryDto dto)

        {
            try
            {
                if (!ModelState.IsValid)

                {
                    //_apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                    //_apiResponse.Issuccess = false;
                    //_apiResponse.AddError(ModelState.ToString());
                    return Ok(_apiResponse.badrequest(HttpStatusCode.BadRequest));





                }



                if (dto.Id == 0)
                {
                    //_apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                    //_apiResponse.Issuccess = false;
                    //_apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    //return Ok(_apiResponse);

                    return Ok(_apiResponse.badrequest(HttpStatusCode.BadRequest));

                }



                await _categoryService.UpdateAsync(dto);
                    _apiResponse.StatusCodes = HttpStatusCode.NoContent;
                    _apiResponse.Issuccess = true;
                    _apiResponse.DisplayMessage = CommonMessage.UpdateOperationSuccess;

                

            }
            catch (Exception)
            {
                //_apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                //_apiResponse.Issuccess = false;
                //_apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                //_apiResponse.AddError(ModelState.ToString());

                return Ok(_apiResponse.badrequest(HttpStatusCode.InternalServerError));



            }




            return Ok(_apiResponse);
        }
    }
}