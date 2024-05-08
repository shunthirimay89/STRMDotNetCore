using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace STRMDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _blBlog;

        public BlogController() 
        {
            _blBlog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()

        {
            var list = _blBlog.GetBlogs();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)

        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _blBlog.CreateBlog(blog);
            string message = result > 0 ? "saving successful" : "saving fail";

            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }

            var result= _blBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating successful" : "updating fail";
            return Ok(result);

        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }
          
            var result = _blBlog.patchBlog(id,blog);
            string message = result > 0 ? "Updating successful" : "updating fail";
            Console.WriteLine(message);
            return Ok(message);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            var result =_blBlog.DeleteBlog(id);
            string message = result > 0 ? "deleting successful" : "deleting fail";
            Console.WriteLine(message);
            return Ok(message);
        }
    }
}
