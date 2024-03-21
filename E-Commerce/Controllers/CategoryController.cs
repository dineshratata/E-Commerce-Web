using ApplicationLayer.Dto.Category;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;



namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;



        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task <ActionResult> Get()
        {


           var categories = await _categoryService.GetAllAsync();

            return Ok(categories);




        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task <ActionResult> Create([FromBody] CreateCategoryDto dto)
        {


            var addedEntity = await _categoryService.CreateAsync(dto);

              return Ok(addedEntity);

          




        }



        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task <ActionResult> GetByid (int id)
        {
                

            var gottenentity = await _categoryService.GetByIdAsync(id);
                   
            if(gottenentity == null)
            {


                return BadRequest($"You have Entered {id} is Wrong");

            }

            return Ok(gottenentity);





        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task <ActionResult> Delete(int id)
        {
            if(id == 0)
            {

               return BadRequest();

            }

            var gottenEntity = await _categoryService.GetByIdAsync(id);


            if (gottenEntity == null)
            {
                return NotFound();
                    
            }



            await _categoryService.DeleteAsync(id);

            return NoContent();




        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <ActionResult> Update([FromBody] UpdateCategoryDto dto)



        {

            if(!ModelState.IsValid)
            {

                BadRequest();

            }


            await _categoryService.UpdateAsync(dto);

            return NoContent();


        }










    }
}
