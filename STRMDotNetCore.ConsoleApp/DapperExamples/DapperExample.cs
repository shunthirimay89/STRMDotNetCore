using Dapper;
using STRMDotNetCore.ConsoleApp.Dtos;
using STRMDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            // Read();
            //  Edit(1);
            //  Edit(11);
            // Create("TestAuthor","TestTitle", "TestContent");
            // Update(2,"Author 2","Title 2","Content 2");
            Delete(1002);


        }

        public void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> list = db.Query<BlogDto>("select * from Tbl_Blog").ToList();

            foreach (BlogDto item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------");
            }
        }
        public void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            BlogDto? item = db.Query<BlogDto>("select * from Tbl_Blog where BlogId=@BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {

                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("------------------");


        }
        public void Create(string author, string title, string content)
        {
            var item = new BlogDto
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogAuthor]
                                   ,[BlogTitle]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogAuthor
                                   ,@BlogTitle
                                   ,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "saving successful" : "saving fail";
            Console.WriteLine(message);

        }
        public void Update(int id, string author, string title, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogAuthor] = @BlogAuthor
                                  ,[BlogTitle] = @BlogTitle
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId]=@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {

            var item = new BlogDto
            {
                BlogId = id,

            };
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE [BlogId]=@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            Console.WriteLine(message);
        }

    }
}
