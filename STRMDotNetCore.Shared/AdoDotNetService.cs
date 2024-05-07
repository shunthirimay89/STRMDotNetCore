using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace STRMDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query,  params AdoDotNetParameter[]? parameters ) 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand command = new SqlCommand(query, connection);
            if(parameters is not null && parameters.Length > 0)
            {

                foreach (var item in parameters) 
                {
                    command.Parameters.AddWithValue(item.Name,item.Value);
                }

              //  command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list=JsonConvert.DeserializeObject<List<T>>(json)!;

            return list;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Name, item.Value);
                }

                //  command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json)!;

            return list[0];
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Name, item.Value);
                }

                //  command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            var result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

    }

    public class AdoDotNetParameter 
    {
        public AdoDotNetParameter() { }

        public AdoDotNetParameter(string name, object value) 
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
