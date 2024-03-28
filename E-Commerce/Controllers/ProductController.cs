using ApplicationLayer.ApplicationConstants;
using ApplicationLayer.Common;
using ApplicationLayer.Dto.Category;
using ApplicationLayer.Dto.Product;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        protected APIResponse _apiResponse;


       public ProductController(IProductService productService) {


            _productService = productService;
             _apiResponse = new APIResponse();
        
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <ActionResult<APIResponse>> Get ()
        {
            try
            {


                var products = await _productService.GetAllAsync();
                _apiResponse.StatusCodes = HttpStatusCode.OK;
                _apiResponse.Issuccess = true;
                _apiResponse.Result = products;

            }
            catch (Exception)
            {

                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;
            }

            return Ok (_apiResponse);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <ActionResult<APIResponse>> Create(CreateProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.StatusCodes = HttpStatusCode.BadRequest;
                    _apiResponse.Issuccess = false;
                   
                    _apiResponse.AddError(ModelState.ToString());



                }

             var addedEntity  =  await _productService.CreateAsync(dto);
             _apiResponse.StatusCodes = HttpStatusCode.Created;
             _apiResponse.Issuccess = true;
             _apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;






            }
            catch (Exception)
            {
                _apiResponse.StatusCodes = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationFailed;
                
            }

            return Ok (_apiResponse);





        }

        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<APIResponse>> GetByid(int id)
        {
            try
            {



                var uniqueData = await _productService.GetByIdAsync(id);

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

                var gottenEntity = await _productService.GetByIdAsync(id);

                if (gottenEntity == null)
                {

                    _apiResponse.StatusCodes = HttpStatusCode.NotFound;
                    _apiResponse.Issuccess = false;
                    _apiResponse.DisplayMessage = CommonMessage.SystemError;




                }

                await _productService.DeleteAsync(id);
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

        public async Task<ActionResult<APIResponse>> Update([FromBody] UpdateProductDto dto)

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



                await _productService.UpdateAsync(dto);
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

