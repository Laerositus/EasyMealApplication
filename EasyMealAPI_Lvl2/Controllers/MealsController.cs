using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EasyMealAPI_Lvl2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private IMealRepository repository;

        public MealsController(IMealRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Retrieves the products collection.
        /// </summary>
        // GET api/v1/products
        [HttpGet]
        public ActionResult<IEnumerable<Meal>> Get()
        {
            return Ok(repository.Meals.ToList());
        }

        /// <summary>
        /// Retrieves the specified product
        /// </summary>
        /// <param name="id"></param> 
        // GET api/v1/products/id
        [HttpGet("{id}")]
        public ActionResult<Meal> Get(int id)
        {
            return repository.Meals
                .Where(p => p.MealID == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates a Product for a given id.
        /// </summary>
        /// <remarks>
        /// Unsupported request.
        /// </remarks>
        /// <param name="id"></param>
        /// <response code="400">A new product cannot be created for a given id</response>
        // POST api/v1/products/id
        [HttpPost("{id}")]
        public IActionResult Post(int id, Meal newMeal)
        {
            return BadRequest();
        }

        /// <summary>
        /// Creates a Product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/products
        ///     {
        ///        "name": "Soccer Ball",
        ///        "description": "FIFA-approved size and weight",
        ///        "price": 19.5,
        ///        "category": "Soccer"
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Product</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the input validation failed.</response>
        // POST api/v1/products
        [HttpPost]
        public IActionResult Post(Meal meal)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {
                repository.SaveMeal(meal);
                result = Ok(meal);
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        // PUT api/v1/products
        [HttpPut]
        public IActionResult Put([FromBody] Meal meal)
        {
            return BadRequest();
        }

        // PUT api/v1/products/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Meal meal)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {
                repository.SaveMeal(meal);
                result = Ok(meal);
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        // DELETE api/v1/products
        [HttpDelete]
        public IActionResult Delete()
        {
            return BadRequest();
        }

        // DELETE api/v1/products/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteMeal(id);
            return Ok();
        }
    }
}
 
