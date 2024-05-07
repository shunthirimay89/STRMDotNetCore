﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STRMDotNetCore.RestApi.Models;
using STRMDotNetCore.RestApi.Services;
using STRMDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;

namespace STRMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";

            List<BlogModel> list = _dapperService.Query<BlogModel>(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            //string query = "select * from Tbl_Blog where BlogId=@BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            //BlogModel? item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            var item = findById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Createblog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogAuthor]
                                   ,[BlogTitle]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogAuthor
                                   ,@BlogTitle
                                   ,@BlogContent)";
            
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "saving successful" : "saving fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {

            var item = findById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogAuthor] = @BlogAuthor
                                  ,[BlogTitle] = @BlogTitle
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId]=@BlogId";

           
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = findById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogAuthor))

            {
                condition += "[BlogAuthor] = @BlogAuthor ,";
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))

            {
                condition += "[BlogTitle] = @BlogTitle ,";
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))

            {
                condition += "[BlogContent] = @BlogContent ,";
            }

            if (condition.Length == 0)
            {
                return NotFound("No Data Found");
            }
            condition = condition.Substring(0, condition.Length - 2);

            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                               SET {condition}
                             WHERE [BlogId]=@BlogId";

            
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = findById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE [BlogId]=@BlogId";

            
            int result = _dapperService.Execute(query, item);
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            return Ok(message);
        }

        private BlogModel? findById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            
            BlogModel? item = _dapperService.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}
