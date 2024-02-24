using Microsoft.AspNetCore.Mvc;
using multiUserStore.Data;
using multiUserStore.Models.Categories;
using System.Collections.Generic;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace multiUserStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatgegoryController : ControllerBase
    {
        private readonly GlobalDbContext _context;
        public CatgegoryController(GlobalDbContext context)
        {
            _context = context;
        }
        // GET: api/<CatgegoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            IEnumerable <Category> categories = _context.Category.ToList();

            return categories;
        }

        // GET api/<CatgegoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Category>  Get(int id)
        {
            var category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CatgegoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
              Category NewCategory = new Category { name  = value ,  CreatedDate = DateTime.UtcNow };
            _context.Category.Add(NewCategory);
           _context.SaveChanges();
        }

        // PUT api/<CatgegoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var category = _context.Category.Find(id);
            if (category != null)
            {
                 category.name = value;
                _context.SaveChanges();
            }
        }

        // DELETE api/<CatgegoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _context.Category.Find(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();

            }

        }
    }
}
