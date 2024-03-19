
using DomainLayer.Models;
using InfrastuctureLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public ActionResult<Category> Get()
        {
                 var _categories   = _dbContext.Category.ToList();

                 return Ok(_categories);





        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public ActionResult Create([FromBody] Category category )
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
            return Ok(category);


        }



        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<Category>GetByid(int id)
        {

                  var categoryDetails  =  _dbContext.Category.FirstOrDefault(x => x.Id == id);


               if(categoryDetails == null)
            {
                return NotFound($"You have Entered Wrong {id} ");

            }
                   
                  return Ok(categoryDetails);
                   


        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult Delete(int id)
        {

                    var dataForRemoval  =  _dbContext.Category.FirstOrDefault(x => x.Id == id);

                     _dbContext.Category.Remove(dataForRemoval);
                     _dbContext.SaveChanges();

                     return Ok("Record Deleted successFully");

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult Update(int id)



        {

            if(id == 0)
            {

                BadRequest("Enter a Valid Number");
            }


            var dataForRemoval = _dbContext.Category.FirstOrDefault(x => x.Id == id);

            _dbContext.Category.Update(dataForRemoval);

            return NoContent();


        }










    }
}
