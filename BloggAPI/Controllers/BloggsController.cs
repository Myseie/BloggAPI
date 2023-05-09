using BloggAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggsController : ControllerBase
    {
        [HttpGet(Name = "GetBloggs")]

        public async Task <IEnumerable<BloggViewModel>> Get()
        {
            var db = new Database();
            var bloggs = await db.GetBloggs();
            
            var viewModel = new List <BloggViewModel>();

            foreach (var blogg in bloggs)
            {
                viewModel.Add(new BloggViewModel(blogg));


            }
            return viewModel;
        }
        [HttpGet("{id}", Name ="GetBloggById")]
        public async Task<BloggViewModel> GetById(string id)
        {
            var db = new Database();
            var blogg = await db.GetBlogg(id);

            var viewModel = new BloggViewModel(blogg);

            return viewModel;

        }

        [HttpPost(Name = "PostBlogg")]
        public async Task<IActionResult> Post (string title, string summary, string content)
        {
            var db = new Database();
            await db.Saveblogg(title, summary, content);

            return Ok();
        }

        [HttpDelete ("{id}", Name = "DeleteBlogg")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var db = new Database();
            await db.DeleteBlogg(id);
            return Ok();

        }

        [HttpPut("{id}", Name = "PutBook")]
        public async Task<IActionResult> PutBlogg(string id, string title, string summary, string content)
        {
            var db = new Database();
            await db.UpdateBlogg(id, title, summary, content);
            return Ok();
        }
    }
}
