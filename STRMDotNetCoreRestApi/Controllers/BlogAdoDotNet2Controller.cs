using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STRMDotNetCore.RestApi.Models;
using STRMDotNetCore.RestApi.Services;
using STRMDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
namespace STRMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);


        [HttpGet]
        public IActionResult GetBlogs()

        {
            string query = "select* from tbl_Blog";
            List<BlogModel> list = _adoDotNetService.Query<BlogModel>(query);

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            string query = "select* from tbl_Blog where BlogId= @BlogId";
            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId",id);
            //var list = _adoDotNetService.Query<BlogModel>(query, parameters);
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            if (item is null)
            {
                return NotFound("No Data Found");
            }

     
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogAuthor]
                                   ,[BlogTitle]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogAuthor
                                   ,@BlogTitle
                                   ,@BlogContent)";
            

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)

                );

            string message = result > 0 ? "saving successful" : "saving fail";

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogAuthor] = @BlogAuthor
                                  ,[BlogTitle] = @BlogTitle
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId]=@BlogId"
            ;

            
            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)

                );

            string message = result > 0 ? "Updating successful" : "updating failed";
            Console.WriteLine(message);
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog1(int id, BlogModel blog)
        {
            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
            string condition = string.Empty;
            

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += "[BlogAuthor] = @BlogAuthor, ";
                parameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += "[BlogTitle] = @BlogTitle, ";
                parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
                parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            if (condition.Length == 0)
            {
                return NotFound("No Data Found");
            }

            condition = condition.Substring(0, condition.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                      SET {condition}
                      WHERE [BlogId] = @BlogId";

            parameters.Add(new AdoDotNetParameter("@BlogId", id));

            int result = _adoDotNetService.Execute(query, parameters.ToArray());

            string message = result > 0 ? "Updating successful" : "Updating failed";
            Console.WriteLine(message);
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE [BlogId]=@BlogId";
           
            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id)
                );
            string message = result > 0 ? "Deleting successful" : "Deleting failed";
            Console.WriteLine(message);
            return Ok(message);
        }

    }
}
