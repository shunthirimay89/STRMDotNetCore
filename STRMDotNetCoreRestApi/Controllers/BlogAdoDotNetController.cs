using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using STRMDotNetCore.RestApi.Models;
using STRMDotNetCore.RestApi.Services;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace STRMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()

        {
            string query = "select* from tbl_Blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection open.");


            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            //List<BlogModel> list = new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows) 
            //{

            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);

            //    list.Add(blog);
            //}

            List<BlogModel> list = dt.AsEnumerable().Select(dr => new BlogModel
            {

                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            string query = "select* from tbl_Blog where BlogId= @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return NotFound("No Data Found");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
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
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
           
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "saving successful" : "saving fail";
            
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogAuthor] = @BlogAuthor
                                  ,[BlogTitle] = @BlogTitle
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId]=@BlogId"
            ;

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@BlogId", id);
            command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Updating successful" : "updating failed";
            Console.WriteLine(message);
            return Ok(message);
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchBlog(int id, BlogModel blog)
        //{

        //    string condition = string.Empty;
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    if (!string.IsNullOrEmpty(blog.BlogAuthor))

        //    {
        //        condition += "[BlogAuthor] = @BlogAuthor, ";
        //        parameters.Add(new SqlParameter("@BlogAuthor", blog.BlogAuthor));
        //    }

        //    if (!string.IsNullOrEmpty(blog.BlogTitle))

        //    {
        //        condition += "[BlogTitle] = @BlogTitle ,";
        //        parameters.Add(new SqlParameter("@BlogTitle", blog.BlogTitle));
        //    }
        //    if (!string.IsNullOrEmpty(blog.BlogContent))

        //    {
        //        condition += "[BlogContent] = @BlogContent ,";
        //        parameters.Add(new SqlParameter("@BlogContent", blog.BlogContent));
        //    }

        //    if (condition.Length == 0)
        //    {
        //        return NotFound("No Data Found");
        //    }
        //    condition = condition.Substring(0, condition.Length - 2);

        //    string query = $@"UPDATE [dbo].[Tbl_Blog]
        //                                   SET {condition}
        //                                 WHERE [BlogId]=@BlogId";
        //    parameters.Add(new SqlParameter("@BlogId", id));


        //    SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        //    sqlConnection.Open();

        //    SqlCommand command = new SqlCommand(query, sqlConnection);
        //    command.Parameters.AddRange(parameters.ToArray());
        //    int result = command.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    string message = result > 0 ? "Updating successful" : "Updating failed";
        //    Console.WriteLine(message);
        //    return Ok(message);
        //}

        [HttpPatch("{id}")]
        public IActionResult PatchBlog1(int id, BlogModel blog)
        {
            string condition = string.Empty;

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;

                if (!string.IsNullOrEmpty(blog.BlogAuthor))
                {
                    condition += "[BlogAuthor] = @BlogAuthor, ";
                    command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
                }

                if (!string.IsNullOrEmpty(blog.BlogTitle))
                {
                    condition += "[BlogTitle] = @BlogTitle, ";
                    command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                }

                if (!string.IsNullOrEmpty(blog.BlogContent))
                {
                    condition += "[BlogContent] = @BlogContent, ";
                    command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
                }

                if (condition.Length == 0)
                {
                    return NotFound("No Data Found");
                }

                condition = condition.Substring(0, condition.Length - 2); 

                string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET {condition}
                         WHERE [BlogId] = @BlogId";

                command.CommandText = query;
                command.Parameters.AddWithValue("@BlogId", id);

                int result = command.ExecuteNonQuery();

                string message = result > 0 ? "Updating successful" : "Updating failed";
                Console.WriteLine(message);
                return Ok(message);
            
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE [BlogId]=@BlogId";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@BlogId", id);

            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Deleting successful" : "Deleting failed";
            Console.WriteLine(message);
            return Ok(message);
        }
    }
}
