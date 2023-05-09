using BloggAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggController : ControllerBase
    {
        // GET: api/<BloggController>
        [HttpGet]
        public List<Blogg> Get()
        {
            var db = new DBConnection();
            var bloggs = db.GetAllBloggs();
            return bloggs;
        }

        // GET api/<BloggController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var db = new DBConnection();
            var blogg = db.GetBloggById(id);
            if(blogg == null)
            {
                return NotFound();
            }

            return Ok (blogg);
        }


        // POST api/<BloggController>
        [HttpPost]
        public void Post([FromBody] Blogg blogg)
        {
            var db = new DBConnection();
            db.SaveBlogg(blogg);
        }

        // PUT api/<BloggController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Blogg blogg)
        {
            var db = new DBConnection();
            db.UpdateBlogg(id, blogg);
        }


        // DELETE api/<BloggController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var db = new DBConnection();

            db.DeleteBloggById(id);
        }
    }
}
