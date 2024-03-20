
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
        private readonly  ICategoryRepository _categoryRepository;



        public CategoryController( ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task <ActionResult> Get()
        {


           var categories = await _categoryRepository.GetAllAsync();

            return Ok(categories);




        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task <ActionResult> Create([FromBody] Category category )
        {
        

              var  addedEntity = await _categoryRepository.CreateAsync(category);

              return Ok(addedEntity);

            
            if ( addedEntity != null )
            {

                return Ok("Created Operation  Successfully");

            }




        }



        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<Category>GetByid(int id)
        {


            var gottenentity = _categoryRepository.GetByIdAsync(x=>x.Id == id);
                   
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

           var gottenEntity = await _categoryRepository.GetByIdAsync(x=>x.Id==id);


            if (gottenEntity == null)
            {
                return NotFound();
                    
            }



            await _categoryRepository.DeleteAsync(gottenEntity);

            return NoContent();




        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <ActionResult> Update([FromBody] Category category)



        {

            if(!ModelState.IsValid)
            {

                BadRequest();

            }


            await _categoryRepository.UpdateAsync(category);

            return NoContent();


        }










    }
}
