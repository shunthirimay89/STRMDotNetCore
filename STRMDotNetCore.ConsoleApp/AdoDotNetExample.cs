using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace STRMDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder() 
        {
            DataSource = "DESKTOP-J9BO0AP\\MSSQL2019",
            InitialCatalog = "STMDB",
            UserID = "sa",
            Password = "123@ace.com"
        };
        public void Read() 
        {
          
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection open.");

            string query = "select* from tbl_Blog";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            Console.WriteLine("connection close.");

            //dataSet=> datatable
            //datatable=>dataRow
            //dataRow=> datacolumn

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId =>" + dr["BlogId"]);
                Console.WriteLine("BlogAuthor =>" + dr["BlogAuthor"]);
                Console.WriteLine("BlogTitle =>" + dr["BlogTitle"]);
                Console.WriteLine("BlogContent =>" + dr["BlogContent"]);
                Console.WriteLine("___________");
            }
        }
        public void Create(string author, string title, string content)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogAuthor]
                                   ,[BlogTitle]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogAuthor
                                   ,@BlogTitle
                                   ,@BlogContent)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "saving successful" : "saving fail";
            Console.WriteLine(message);
        }
        public void Update(int id, string author, string title,string content) 
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogAuthor] = @BlogAuthor
                                  ,[BlogTitle] = @BlogTitle
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId]=@BlogId";
            SqlCommand command = new SqlCommand(query,sqlConnection);
            command.Parameters.AddWithValue("@BlogId", id);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Updating successful" : "updating failed";
            Console.WriteLine(message);
        }
        public void Delete(int id) 
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE [BlogId]=@BlogId";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@BlogId", id);
           
            int result = command.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Deleting successful" : "Deleting failed";
            Console.WriteLine(message);
        }
    
        public void Edit(int id) 
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection open.");

            string query = "select* from tbl_Blog where BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId",id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            Console.WriteLine("connection close.");

            //dataSet=> datatable
            //datatable=>dataRow
            //dataRow=> datacolumn
            if (dt.Rows.Count == 0) 
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dt.Rows[0];
           
                Console.WriteLine("BlogId =>" + dr["BlogId"]);
                Console.WriteLine("BlogAuthor =>" + dr["BlogAuthor"]);
                Console.WriteLine("BlogTitle =>" + dr["BlogTitle"]);
                Console.WriteLine("BlogContent =>" + dr["BlogContent"]);
                Console.WriteLine("___________");
            
        }
    }
}
