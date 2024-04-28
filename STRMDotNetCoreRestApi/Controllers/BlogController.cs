using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using STRMDotNetCoreRestApi.Db;
using STRMDotNetCoreRestApi.Models;

namespace STRMDotNetCoreRestApi.Controllers
{
    //endPoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase

    {
        private  readonly AppDbContext _context;

        public BlogController() {


            _context = new AppDbContext();
        }

        [HttpGet]
        public  IActionResult Read() 

        {
            var list =_context.blogs.ToList();
            return Ok(list);
        }

        [HttpGet ("{id}")]
        public IActionResult Edit(int id)

        {
            var item = _context.blogs.FirstOrDefault(x=> x.BlogId==id);
            if (item is null) {
                return NotFound("No Data Found");
            
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.blogs.Add(blog);
         var result=   _context.SaveChanges();
            string message = result > 0 ? "saving successful" : "saving fail";
            
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }

            item.BlogAuthor = blog.BlogAuthor;
            item.BlogTitle = blog.BlogTitle;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating successful" : "updating fail";
            return Ok(result);

        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) {

                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {

                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {

                item.BlogContent = blog.BlogContent;
            }

           
            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating successful" : "updating fail";
            Console.WriteLine(message);
            return Ok(message);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var item = _context.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");

            }

            _context.blogs.Remove(item);
            var result = _context.SaveChanges();
            string message = result > 0 ? "deleting successful" : "deleting fail";
            Console.WriteLine(message);
            return Ok(message);
        }

         
    }
}
